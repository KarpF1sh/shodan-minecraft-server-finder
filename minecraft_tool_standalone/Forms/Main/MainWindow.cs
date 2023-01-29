using System;
using System.Collections.Generic;
using System.Windows.Forms;
using minecraft_tool_standalone.Forms.Main;
using minecraft_tool_standalone.Minecraft;
using minecraft_tool_standalone.Shodan;
using minecraft_tool_standalone.Forms.Dialog;
using minecraft_tool_standalone.Reg;
using System.Net.Http;
using System.IO;
using fNbt;
using minecraft_tool_standalone.FileHandler;

namespace minecraft_tool_standalone
{
    public partial class MainForm : Form
    {
        private List<Server> servers = new List<Server>();
        private bool queryModified;
        private string datFileOriginal;
        private string datFileBackup;
        public MainForm()
        {
            InitializeComponent();

            serverListView.MouseDoubleClick += new MouseEventHandler(serverListView_MouseDoubleClick);
            
            // Add event listener for keypresses
            this.KeyDown += window_KeyDown;
            this.Load += new EventHandler(MainForm_Load);
        }
        // Double click event
        private void serverListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Set to clipboard
            Clipboard.SetText(serverListView.SelectedItems[0].SubItems[1].Text + ":" + serverListView.SelectedItems[0].SubItems[2].Text);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // for keyboard shortcuts
            KeyPreview = true;

            // Set default focus to button
            FindButton.Focus();

            // Show Key dialog on startup if it's not set
            if (Manager.GetRegistryKey(KeyType.APIKEY) == String.Empty)
            {
                // Set key from dialog
                new ApiDialog().Show();
            }

            // Clean backups
            DatFileHandler.FileBackup();

            // Set country picker data source
            countryBox.DataSource = CountryLister.getCountries();
        }

        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Clean backups
            DatFileHandler.FileClean();
        }

        private async void FindButton_Click(object sender, EventArgs e)
        {
            // New query
            Query query = new Query(
                // Get short country code
                CountryLister.GetCode(countryBox.Text),
                versionBox.Text,
                onlineButton.Checked,
                noOnlineButton.Checked,
                // Include advanced options if checked
                advancedToggle.Checked ? advancedBox.Text : String.Empty,
                page: (int) pageSelector.Value);

            // Disable buttons during search
            FindButton.Enabled = false;
            mainMenuStrip.Enabled = false;
            // Disable the page selector
            pageSelector.Enabled = false;

            // If the query has been modified
            if (queryModified)
            {
                // Reset the page selector value
                pageSelector.Value = 1;
                queryModified = false;
            }

            // Start animation
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;

            try
            {
                // Create finder instance and get servers
                servers = await ShodanQuery.SearchAsync(query);
            } catch (HttpRequestException ex)
            {
                // Error with shodan!
                MessageBox.Show(ex.Message, "Error with shodan!");
            } catch (ArgumentException msg)
            {
                // Error with key!
                MessageBox.Show(msg.Message, "Error with key!");
            }

            // Enable buttons
            FindButton.Enabled = true;
            mainMenuStrip.Enabled = true;

            // Stop animation
            toolStripProgressBar1.Style = ProgressBarStyle.Continuous;

            // Enable the page selector
            pageSelector.Enabled = true;
            pageCount.Text = ShodanQuery.pages > 100 ? ">100" : ShodanQuery.pages.ToString();
            pageSelector.Maximum = ShodanQuery.pages == 0 ? 1 : ShodanQuery.pages;

            // Clear old data
            serverListView.Items.Clear();

            // Bad iterator int
            int i = 1;

            //ListViewItem lvi = new ListViewItem(shodanResults);
            foreach (var server in servers)
            {

                // If server is modded and we don't want to see it
                if (server.Modded && showModdedButton.Checked == false)
                {
                    continue;
                }

                // Add data to listView
                serverListView.Items.Add(new ListViewItem(new string[]
                {   // Server data
                        i.ToString(),
                        server.Ip,
                        server.Port,
                        server.Version,
                        server.Desc,
                        server.Online + "/" + server.Max
                }));

                // Increment
                i++;
            }

            // If results found enable exporting
            if (servers.Count > 0)
            {
                // Enable export menu item
                exportToolStripMenuItem.Enabled = true;
                importToMcButton.Enabled = true;
            }
            else { exportToolStripMenuItem.Enabled = false; }
        }

        private void onlineButton_CheckedChanged(object sender, EventArgs e)
        {
            // Disable other button if checked
            noOnlineButton.Enabled = !onlineButton.Checked;

            // Inform changes
            queryModified = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Disable other button if checked
            onlineButton.Enabled = !noOnlineButton.Checked;

            // Inform changes
            queryModified = true;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            // Open website on link click
            System.Diagnostics.Process.Start("https://lohiv.com");
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            // Toggle Advanced arguments based on toggle
            advancedBox.Enabled = advancedToggle.Checked;
        }

        private void setKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set key from dialog
            new ApiDialog().Show();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show Export dialog
            new ExportDialog().Show(servers);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 box = new AboutBox1();
            box.ShowDialog();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            // If not assigned show dialog
            if (Manager.GetRegistryKey(KeyType.GAMEPATH) == String.Empty)
            {
                // Show game folder dialog
                new SelectGameDialog().Show();
            }

            try
            {
                // New list and compound for servers
                NbtCompound compound = new NbtCompound("");
                NbtList serverList = new NbtList("servers");

                // Bad iterator int
                int i = 1;

                // Loop through found servers
                foreach (Server server in servers)
                {
                    // If server is modded and we don't want to see it
                    if (server.Modded && showModdedButton.Checked == false)
                    {
                        continue;
                    }

                    // Create new nbt compound to hold the server info
                    serverList.Add(new NbtCompound() {
                            new NbtString("ip", server.Ip),
                                new NbtString("name", "McTool IP: " + i.ToString())});
                    i++;
                }

                // Add servers to final compound
                compound.Add(serverList);

                // Save file
                NbtFile serverFile = new NbtFile(compound);
                DatFileHandler.WriteFile(serverFile);

                //serverFile.SaveToFile(datFileOriginal, NbtCompression.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error importing server list");
            }
        }


        private void window_KeyDown(object sender, KeyEventArgs e)
        {
            // Search on enter
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Enter)
            {
                FindButton_Click(sender, e);
            }

            // Shift + enter for import
            if (e.Shift && e.KeyCode == Keys.Enter)
            {
                if (importToMcButton.Enabled)
                {
                    importButton_Click(sender, e);
                }
            }

            // Control + e for export
            if (e.Control && e.KeyCode == Keys.E)
            {
                if (exportToolStripMenuItem.Enabled)
                {
                    exportToolStripMenuItem_Click(sender, e);
                }
            }

            // Control + shift + r for restore
            // Ooh secret :O
            if (e.Control && e.Control && e.KeyCode == Keys.R)
            {
                if (exportToolStripMenuItem.Enabled)
                {
                    DatFileHandler.FileClean();
                }
            }
        }

        private void setGamePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show game path selector
            new SelectGameDialog().Show();
        }

        private void showModdedButton_CheckedChanged(object sender, EventArgs e)
        {
            // Inform changes
            queryModified = true;
        }

        private void countryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Inform changes
            queryModified = true;
        }

        private void advancedBox_TextChanged(object sender, EventArgs e)
        {
            // Inform changes
            queryModified = true;
        }

        private void versionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Inform changes
            queryModified = true;
        }

        private void testButton_Click(object sender, EventArgs e)
        {
        }
    }
}
