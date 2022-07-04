using minecraft_tool_standalone.Minecraft;
using minecraft_tool_standalone.Reg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minecraft_tool_standalone.Forms.Dialog
{
    public partial class SelectGameDialog : Form
    {
        public SelectGameDialog()
        {
            InitializeComponent();

            // Set default path
            gamePathBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\";
        }

        public void Show()
        {
            // Get button selection
            if (ShowDialog() == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(gamePathBox.Text))
                {
                    Manager.SetRegistryKey(KeyType.GAMEPATH, String.Empty);
                }
                Manager.SetRegistryKey(KeyType.GAMEPATH, gamePathBox.Text);
            }

            // return dialog
            //return ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // New file browser
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = gamePathBox.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                gamePathBox.Text = folderBrowserDialog1.SelectedPath;
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SelectGameDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
