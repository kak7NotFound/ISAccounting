using System;
using System.Windows.Forms;

namespace ISAccounting
{
    public partial class ClientsForm : Form
    {
        public static bool open = false;

        public ClientsForm()
        {
            InitializeComponent();
        }
        
        private void ClientsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            open = false;
        }
    }
}