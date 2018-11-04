using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class MainForm : Form
    {
        string token, type;


        public MainForm()
        {
            InitializeComponent();
        }

        

        private void MainForm_Load(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
            token = form1.GetToken();
            if(token != "null")
            {
                Enabled = true;
                type = form1.GetUserType();
                MainMenu.Visible = true;
                taskLabel.Visible = true;
            }
        }
    }
}
