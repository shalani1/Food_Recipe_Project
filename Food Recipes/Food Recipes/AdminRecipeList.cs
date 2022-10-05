using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Food_Recipes
{
    public partial class AdminRecipeList : Form
    {
        SqlConnection con = new SqlConnection("Data Source=SHALANI\\SQLEXPRESS;Initial Catalog=FoodRecipes;User ID=sa;Password=Sql#Server");
        SqlDataAdapter da = new SqlDataAdapter();

        public static string SetValueForRecipeId;
        string recipeId;
        string catId;

        public AdminRecipeList()
        {
            InitializeComponent();
        }

        private void AdminRecipeList_Load(object sender, EventArgs e)
        {
            loadGridViewData();
            this.dgvRecipes.Columns[0].Visible = false;
        }

        private void loadGridViewData()
        {
            da.SelectCommand = new SqlCommand("SELECT R.RecipeID as [Recipe ID], R.RecipeName as [Recipe Name], R.Descriptions as [Description], R.Duration as [Duration], C.RecipeCategoryName as [Category], R.Image as [Image] FROM Recipes R JOIN RecipeCategories C ON(R.RecipeCategoryID = C.RecipeCategoryID)", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.dgvRecipes.DefaultCellStyle.Font = new Font(" Microsoft JhengHei", 11);
            //Count Number of Recipies
            dgvRecipes.DataSource = dt;
            dataGrideViewRowCount();

            //make row  height 
            dgvRecipes.RowTemplate.Height = 100;
            //dgvCategory.AllowUserToAddRows = false;

            dgvRecipes.DataSource = dt;

            //stretch image in colum
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol = (DataGridViewImageColumn)dgvRecipes.Columns[5];
            imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //auto make size of column 
            dgvRecipes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        private void dgvRecipes_Click(object sender, EventArgs e)
        {
            //get recipe if from selected row
            try
            {

                recipeId = dgvRecipes.CurrentRow.Cells[0].Value.ToString();
                SetValueForRecipeId = recipeId;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Add first food recipe now!!!");
            }


        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            AdminAddRecipe add = new AdminAddRecipe();
            add.MdiParent = this.ParentForm;
            add.Dock = DockStyle.Fill;
            add.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (recipeId != null)
            {
                //Pass selected value to Update Form
                SetValueForRecipeId = recipeId;

                AdminRecipeUpdateDelete update = new AdminRecipeUpdateDelete();
                update.MdiParent = this.ParentForm;
                update.Dock = DockStyle.Fill;
                update.Show();
            }
            else
            {
                MessageBox.Show("Please Select Recipe!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Count Number of Recipies
        public void dataGrideViewRowCount()
        {
            int rowcount = dgvRecipes.Rows.Count;
            lblNumOfRecipies.Text = rowcount.ToString();
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //search category from table
            string searchQuery = "";
            if (textBox1.Text != string.Empty)
                searchQuery += "[Recipe Name] like '%" + textBox1.Text.Trim() + "%' and ";
            searchQuery += "1 = 1";
            (dgvRecipes.DataSource as DataTable).DefaultView.RowFilter = searchQuery;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            //AdminDashboard dash = new AdminDashboard();
            //dash.MdiParent = this.ParentForm;
            //dash.Dock = DockStyle.Fill;
            //dash.Show();
            /*AdminRecipeList list = new AdminRecipeList();
            list.MdiParent = this.ParentForm;
            list.Dock = DockStyle.Fill;
            list.Show();*/

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadGridViewData();
        }

        private void dgvRecipes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
