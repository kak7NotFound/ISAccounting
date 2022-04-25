using System;
using System.IO;
using System.Windows.Forms;

namespace ISAccounting
{
    public partial class DocsForm : Form
    {
        public static bool open = false;
        public static string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        public static DirectoryInfo path = new DirectoryInfo(strExeFilePath.Substring(0, strExeFilePath.Length-16) + @"\docs"); //Assuming Test is your Folder

        public DocsForm()
        {
            InitializeComponent();
            getDocs();
        }

        public void refreshDatagrid()
        {
            
        }
        private void getDocs()
        {
            FileInfo[] Files = path.GetFiles("*.*"); //Getting Text files
            string str = "";
            foreach(FileInfo file in Files )
            {
                Console.Write(file.Name);
            }
        }

        private void DocsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            open = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // todo System.Diagnostics.Process.Start(@"C:\Users\kaks\Desktop\a.docx");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new CreateFileForm(this, path.ToString()).Show();
        }
    }
}