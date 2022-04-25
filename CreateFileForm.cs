using System;
using System.IO;
using System.Windows.Forms;

namespace ISAccounting
{
    public partial class CreateFileForm : Form
    {
        private string path;
        public CreateFileForm(DocsForm df, string path_)
        {
            path = path_;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.Create(path + "\\" + textBox1.Text);
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {            
            File.Create(path + "\\" + textBox1.Text + ".doc");
            Close();
        }
    }
}