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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnShowRecipes_Click(object sender, EventArgs e)
        {
            AllRecipeList recipe = new AllRecipeList();
            recipe.MdiParent = this.ParentForm;
            recipe.Dock = DockStyle.Fill;
            recipe.clickedMenu = true;
            recipe.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void picHome_Click(object sender, EventArgs e)
        {

        }
    }
}
