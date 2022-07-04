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
    public partial class ApiDialog : Form
    {
        public ApiDialog()
        {
            InitializeComponent();
        }
        // Show method
        public void Show()
        {
            // Set key to text field by default
            keyInput.Text = Manager.GetRegistryKey(KeyType.APIKEY);
            keyInput.Focus();

            // Get button selection
            if (ShowDialog() == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(keyInput.Text))
                {
                    Manager.SetRegistryKey(KeyType.APIKEY, String.Empty);
                }
                Manager.SetRegistryKey(KeyType.APIKEY, keyInput.Text);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open website on link click
            System.Diagnostics.Process.Start("https://shodan.io");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
