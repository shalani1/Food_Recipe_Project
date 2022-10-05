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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            AdminCategoryAdd adminCat = new AdminCategoryAdd();
            adminCat.MdiParent = this.ParentForm;
            adminCat.Dock = DockStyle.Fill;
            adminCat.Show();
        }

        private void btnRecipe_Click(object sender, EventArgs e)
        {

            AdminRecipeList recipeList = new AdminRecipeList();
            recipeList.MdiParent = this.ParentForm;
            recipeList.Dock = DockStyle.Fill;
            recipeList.Show();

            /*Admin admin = new Admin();
            admin.MdiParent = this.ParentForm;
            admin.Dock = DockStyle.Fill;
            admin.Show();*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pbAdminCatBackground_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminRecipeUpdateDelete f=new AdminRecipeUpdateDelete();
            f.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.MdiParent = this.ParentForm;
            home.Dock = DockStyle.Fill;
            home.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
