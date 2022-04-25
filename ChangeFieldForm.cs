using System;
using System.IO;
using System.Windows.Forms;

namespace ISAccounting
{
    public partial class ChangeFieldForm : Form
    {
        
        public DocsForm df;
        public ChangeFieldForm(DocsForm df_)
        {
            df = df_;
            InitializeComponent();

            textBox1.Text = df.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = df.dataGridView1.CurrentRow.Cells[0].Value.ToString();

            using (var reader = Program.database.GetReader("select name from Clients"))
            {
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(0));
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Program.database.ExecuteNonQuery($"update Docs set sender = '{comboBox1.Text}', title = '{textBox1.Text}' where sender = '{df.dataGridView1.CurrentRow.Cells[0].Value.ToString()}' and title = '{df.dataGridView1.CurrentRow.Cells[1].Value.ToString()}'");
            File.Move(DocsForm.path + "\\" + df.dataGridView1.CurrentRow.Cells[1].Value.ToString(), DocsForm.path + "\\" + textBox1.Text);
            df.refreshDatagrid();
            Close();
        }
    }
}