using System;
using System.Windows.Forms;

namespace ISAccounting
{
    public partial class SalaryForm : Form
    {
        public static bool open = false;

        public SalaryForm()
        {
            InitializeComponent();
        }

        private void SalaryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            open = false;
        }
    }
}