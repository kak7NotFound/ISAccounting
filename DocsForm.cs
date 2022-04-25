using System;
using System.Windows.Forms;

namespace ISAccounting
{
    public partial class DocsForm : Form
    {
        public static bool open = false;

        public DocsForm()
        {
            InitializeComponent();
        }

        private void DocsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            open = false;
        }
    }
}