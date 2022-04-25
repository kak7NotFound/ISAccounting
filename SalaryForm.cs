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
            refreshCombobox();

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        public void refreshCombobox()
        {
            comboBox1.Items.Clear();
            using (var reader = Program.database.GetReader("select * from Workers"))
            {
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(0));
                }
            }
        }

        private void SalaryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            open = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var reader = Program.database.GetReader($"select * from Salaries where name = '{comboBox1.Text}'"))
            {
                while (reader.Read())
                {
                    
                }
            }
        }
    }
}