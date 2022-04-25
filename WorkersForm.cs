using System;
using System.Windows.Forms;

namespace ISAccounting
{
    public partial class WorkersForm : Form
    {
        public static bool open = false;
        public WorkersForm()
        {
            InitializeComponent();
            refreshListBox();
        }

        private void refreshListBox()
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

        private void WorkersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            open = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.database.ExecuteNonQuery($"insert into Workers (name, position, salary, phoneNumber) VALUES ('{textBox1.Text}', '{textBox2.Text}', {numericUpDown1.Value}, '{textBox3.Text}')");
            refreshListBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.database.ExecuteNonQuery($"delete from Workers where name = '{comboBox1.Text}'");
            comboBox1.Text = "";
            refreshListBox();
        }
    }
}