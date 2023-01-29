using minecraft_tool_standalone.Minecraft;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minecraft_tool_standalone.Forms.Dialog
{
    public partial class ExportDialog : Form
    {
        // Holder for servers
        List<Server> Servers;
        public ExportDialog()
        {
            InitializeComponent();
        }
        public DialogResult Show(List<Server> servers)
        {
            this.Servers = servers;
            // return dialog
            return ShowDialog();
        }

        private string[] ExportFormatter(List<Server> servers)
        {
            // List for final export
            List<string> exportString = new List<string>();

            // Bad counter int
            int index = 1;
            foreach (Server server in servers)
            {
                // Generate string to export with magic!
                // This is hard to read I'm sorry :(
                exportString.Add(String.Format("{0}{1}{2}{3}{4}",
                    lineNumberCheck.Checked ? index.ToString() + ": " : String.Empty,
                    ipCheck.Checked ? server.Ip : String.Empty,
                    portCheck.Checked ? ":" + server.Port : String.Empty,
                    descCheck.Checked ? " Description:" + "\"" + server.Desc + "\"" : String.Empty,
                    onlineCheck.Checked ? " Online:" +server.Online + "/" + server.Max : String.Empty));
                index++;
            }
            // Make list to string and return
            return exportString.ToArray();
        }

        private void PreviewTextChange()
        {

            // Enable button only when data is selected
            if (ipCheck.Checked | portCheck.Checked | descCheck.Checked | onlineCheck.Checked | lineNumberCheck.Checked)
            {
                ExportButton.Enabled = true;
            } else
            {
                ExportButton.Enabled = false;
            }

            // Generate string to export with magic!
            previewText.Text = String.Format("{0}{1}{2}{3}{4}",
                lineNumberCheck.Checked ? "1: " : String.Empty,
                ipCheck.Checked ? "123.45.67.890" : String.Empty,
                portCheck.Checked ? ":" + "25565" : String.Empty,
                descCheck.Checked ? " Description:" + "\"Example server\"" : String.Empty,
                onlineCheck.Checked ? " Online:" + "2/24": String.Empty);
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            // Don't export empty files
            if (previewText.Text != "")
            {
                // Set file dialog properties
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Save export";

                // Show dialog
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Write file
                    File.WriteAllLines(saveFileDialog.FileName, ExportFormatter(Servers));
                }
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // Update preview
            PreviewTextChange();
        }
        private void ipCheck_CheckedChanged(object sender, EventArgs e)
        {
            // Update preview
            PreviewTextChange();
            portCheck.Checked = false;
            portCheck.Enabled = ipCheck.Checked;
        }

        private void portCheck_CheckedChanged(object sender, EventArgs e)
        {
            // Update preview
            PreviewTextChange();
        }

        private void descCheck_CheckedChanged(object sender, EventArgs e)
        {
            // Update preview
            PreviewTextChange();
        }

        private void onlineCheck_CheckedChanged(object sender, EventArgs e)
        {
            // Update preview
            PreviewTextChange();
        }

        private void lineNumberCheck_CheckedChanged(object sender, EventArgs e)
        {
            // Update preview
            PreviewTextChange();
        }

        private void ExportDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
