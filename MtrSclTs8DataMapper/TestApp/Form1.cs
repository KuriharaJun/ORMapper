using System;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Form1 : Form
    {
        private ClsDataDao dao = new ClsDataDao();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var list = dao.ExecuteCustomer();

            grid1.DataSource = list;
        }
    }
}
