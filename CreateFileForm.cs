using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ISAccounting
{
    public partial class CreateFileForm : Form
    {
        private string path;
        private DocsForm df;
        public CreateFileForm(DocsForm df_, string path_)
        {
            path = path_;
            df = df_;
            InitializeComponent();

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
            File.Create(path + "\\" + textBox1.Text).Close();
            Program.database.ExecuteNonQuery($"insert into Docs (sender, title, type) values ('{comboBox1.Text}', '{textBox1.Text}', 'Другое')");
            df.refreshDatagrid();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {            
            File.Create(path + "\\" + textBox1.Text + ".doc").Close();
            Program.database.ExecuteNonQuery($"insert into Docs (sender, title, type) values ('{comboBox1.Text}', '{textBox1.Text+ ".doc"}', 'Документ')");
            df.refreshDatagrid();
            Close();
        }
    }
}