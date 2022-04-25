using System;
using System.IO;
using System.Windows.Forms;

namespace ISAccounting
{
    public partial class DocsForm : Form
    {
        public static bool open = false;
        public static string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        public static DirectoryInfo path = new DirectoryInfo(strExeFilePath.Substring(0, strExeFilePath.Length-16) + @"docs"); //Assuming Test is your Folder

        public DocsForm()
        {
            InitializeComponent();
            refreshDatagrid();
        }

        public void refreshDatagrid()
        {
            dataGridView1.Rows.Clear();
            using (var reader = Program.database.GetReader("select * from Docs"))
            {
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                }
            }
        }


        private void DocsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            open = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("\"" +path + @"\" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "\"");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new CreateFileForm(this, path.ToString()).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.database.ExecuteNonQuery($"delete from Docs where title = '{dataGridView1.CurrentRow.Cells[1].Value.ToString()}'");
            File.Delete(path + @"\" + dataGridView1.CurrentRow.Cells[1].Value.ToString());
            refreshDatagrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
         new ChangeFieldForm(this).Show();   
        }
    }
}