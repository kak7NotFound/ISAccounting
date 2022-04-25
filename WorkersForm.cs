using System.Windows.Forms;

namespace ISAccounting
{
    public partial class WorkersForm : Form
    {
        public static bool open = false;
        public WorkersForm()
        {
            InitializeComponent();
        }

        private void WorkersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            open = false;
        }
    }
}