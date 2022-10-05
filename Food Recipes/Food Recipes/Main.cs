using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food_Recipes
{
    public partial class Main : Form
    {
        SqlConnection cs = new SqlConnection("Data Source=SHALANI\\SQLEXPRESS;Initial Catalog=FoodRecipes;User ID=sa;Password=Sql#Server");
        SqlDataAdapter da = new SqlDataAdapter();

        List<string> recipe = new List<string>();
        List<string> recipeId = new List<string>();
        List<int> ID = new List<int>();     
     
        public Main()
        {
            InitializeComponent();
        }
     
        private void btnHome_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnHome.Height;
            SidePanel.Top = btnHome.Top;
            Home home = new Home();
            home.MdiParent = this;
            home.Dock = DockStyle.Fill;
            home.Show();
        }

        private void btnCat_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnCat.Height;
            SidePanel.Top = btnCat.Top;
           RecipeCategory cat = new RecipeCategory();
           cat.MdiParent = this;
           cat.Dock = DockStyle.Fill;
           cat.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
               
            }
            else
            {
                SearchedRecipes rep = new SearchedRecipes(this.txtSearch.Text.Trim());
                rep.MdiParent = this;
                rep.Dock = DockStyle.Fill;
                rep.Show();             
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.MdiParent = this;
            log.Dock = DockStyle.Fill;
            log.Show();
      
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SidePanel.Height = btnHome.Height;
            SidePanel.Top = btnHome.Top;
            Home home = new Home();
            home.MdiParent = this;
            home.Dock = DockStyle.Fill;
            home.Show();
        }

        private void btnFavour_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnFavour.Height;
            SidePanel.Top = btnFavour.Top;
            Favourites favour = new Favourites();
            favour.MdiParent = this;
            favour.Dock = DockStyle.Fill;
            favour.Show();
        }

        private void lblName_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnHome.Height;
            SidePanel.Top = btnHome.Top;
            Home home = new Home();
            home.MdiParent = this;
            home.Dock = DockStyle.Fill;
            home.Show();
        }

        private void picLogo_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnHome.Height;
            SidePanel.Top = btnHome.Top;
            Home home = new Home();
            home.MdiParent = this;
            home.Dock = DockStyle.Fill;
            home.Show();
        }

        private void panelLogo_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnHome.Height;
            SidePanel.Top = btnHome.Top;
            Home home = new Home();
            home.MdiParent = this;
            home.Dock = DockStyle.Fill;
            home.Show();
        }

        private void btnRecipe_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnRecipe.Height;
            SidePanel.Top = btnRecipe.Top;
            AllRecipeList recipe = new AllRecipeList();
            recipe.MdiParent = this;
            recipe.Dock = DockStyle.Fill;
            recipe.clickedMenu = true;
            recipe.Show();       
        }

        private void SidePanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
