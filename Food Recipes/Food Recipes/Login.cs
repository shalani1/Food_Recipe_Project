using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food_Recipes
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if((txtUsername.Text == "admin") && (txtPassword.Text == "1234"))
            {
                AdminDashboard dash = new AdminDashboard();
                dash.MdiParent = this.ParentForm;
                dash.Dock = DockStyle.Fill;
                dash.Show();
               /* Admin admin = new Admin();
                admin.MdiParent = this.ParentForm;
                admin.Dock = DockStyle.Fill;
                admin.Show();*/

            


            }
            else
            {
                MessageBox.Show("Username or Password Incorrect!");
                txtUsername.Text = "";
                txtPassword.Text = "";
            }
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            Main frm = new Main();
            frm.panelTopBar.Visible = false;


        }
    }
}
