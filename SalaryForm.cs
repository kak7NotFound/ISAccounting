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
            textBox1.Text = "";
            textBox2.Text = "";
            using (var reader = Program.database.GetReader(
                       $"select salary, premium from Salaries where name = '{comboBox1.Text}' and date = '{comboBox2.Text}'"))
            {
                if (!reader.Read())
                {
                    Program.database.ExecuteNonQuery(
                        $"insert into Salaries (name, salary, premium, date) values ('{comboBox1.Text}', null, null, '{comboBox2.Text}')");
                    return;
                }
                else
                {
                    if (reader.IsDBNull(0)) return;
                    textBox1.Text = reader.GetString(0);
                    if (reader.IsDBNull(1)) return;
                    textBox2.Text = reader.GetString(1);
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" | comboBox2.Text == "" | textBox1.Text == "")
            {
                button3.Enabled = false;
                button1.Enabled = false;
                return;
            }
            else
            {
                button3.Enabled = true;
                button1.Enabled = true;
            }
        }
        
        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" | comboBox2.Text == "" | textBox2.Text == "")
            {
                button2.Enabled = false;
                return;
            }
            else
            {
                button2.Enabled = true;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Program.database.ExecuteNonQuery(
                $"update Salaries set salary = '{textBox1.Text}' where name = '{comboBox1.Text}' and date = '{comboBox2.Text}'");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Program.database.ExecuteNonQuery(
                $"update Salaries set premium = '{textBox2.Text}' where name = '{comboBox1.Text}' and date = '{comboBox2.Text}'");
        }
    }
}