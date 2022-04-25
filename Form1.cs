using System;
using System.Windows.Forms;

namespace ISAccounting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Program.database = new DataBase();
            // todo System.Diagnostics.Process.Start(@"C:\Users\kaks\Desktop\a.docx");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DocsForm.open) return;
            DocsForm.open = true;
            new DocsForm().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SalaryForm.open) return;
            SalaryForm.open = true;
            new SalaryForm().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (WorkersForm.open) return;
            WorkersForm.open = true;
            new WorkersForm().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ClientsForm.open) return;
            ClientsForm.open = true;
            new ClientsForm().Show();
        }
    }
}