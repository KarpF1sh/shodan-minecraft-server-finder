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

namespace minecraft_tool_standalone
{
    public partial class MainForm : Form
    {
        private List<Server> servers = new List<Server>();
        private string datFileOriginal;
        private string datFileBackup;
        public MainForm()
        {
            InitializeComponent();

            serverListView.MouseDoubleClick += new MouseEventHandler(serverListView_MouseDoubleClick);
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
            // Set default focus to button
            FindButton.Focus();
            // Show Key dialog on startup if it's not set
            if (Manager.GetRegistryKey(KeyType.APIKEY) == String.Empty)
            {
                // Set key from dialog
                new ApiDialog().Show();
            }

            // Set country picker data source
            countryBox.DataSource = CountryLister.getCountries();
        }

        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Backup server list
            
            if (File.Exists(datFileBackup))
            {
                File.Copy(datFileBackup, datFileOriginal, true);
                File.Delete(datFileBackup);
            }
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
                advancedToggle.Checked ? advancedBox.Text : String.Empty);

            // Disable buttons during search
            FindButton.Enabled = false;
            mainMenuStrip.Enabled = false;
            // Start animation
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            try
            {
                // Create finder instance and get servers
                servers = await ServerFinder.GetServersAsync(query);
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

            // Clear old data
            serverListView.Items.Clear();

            // Bad iterator int
            int i = 1;

            //ListViewItem lvi = new ListViewItem(shodanResults);
            foreach (var server in servers)
            {
                // Add data to listView
                serverListView.Items.Add(new ListViewItem(new string[]
                {   // Server data
                    i.ToString(),
                    server.Ip,
                    server.Port,
                    server.Version,
                    server.Description,
                    server.OnlineCount + "/" + server.MaxPlayers
                }));
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
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Disable other button if checked
            onlineButton.Enabled = !noOnlineButton.Checked;
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

        private void button1_Click(object sender, EventArgs e)
        {

            // Get path string from registry
            string path = Manager.GetRegistryKey(KeyType.GAMEPATH);

            // If not assigned show dialog
            if (path == String.Empty)
            {
                // Show game folder dialog
                new SelectGameDialog().Show();
            }

            if (Manager.GetRegistryKey(KeyType.GAMEPATH) != String.Empty)
            {
                // Backup server list
                datFileOriginal = path + "\\servers.dat";
                datFileBackup = path + "\\servers.dat.mctool";

                if (File.Exists(datFileOriginal))
                {
                    File.Copy(datFileOriginal, datFileBackup, true);
                }

                try
                {
                    // New list and compund for servers
                    var compound = new NbtCompound("");
                    var serverList = new NbtList("servers");

                    // Bad iterator int
                    int i = 0;

                    // Loop through found servers
                    foreach (Server server in servers)
                    {
                        serverList.Add(new NbtCompound() {
                            new NbtString("ip", server.Ip),
                                new NbtString("name", "McTool IP: " + i.ToString())});
                        i++;
                    }

                    // Add servers to minecraft
                    compound.Add(serverList);

                    // Save file
                    var serverFile = new NbtFile(compound);
                    serverFile.SaveToFile(datFileOriginal, NbtCompression.None);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error importing server list");
                }
            }
        }

        private void setGamePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show game path selector
            new SelectGameDialog().Show();
        }
    }
}
