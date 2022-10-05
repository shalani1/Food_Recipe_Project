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
    public partial class RecipeList : Form
    {
        SqlConnection cs = new SqlConnection("Data Source=SHALANI\\SQLEXPRESS;Initial Catalog=FoodRecipes;User ID=sa;Password=Sql#Server");
        SqlDataAdapter da = new SqlDataAdapter();

        List<string> recipeName = new List<string>();
        List<string> recipeId = new List<string>();
        List<string> duration = new List<string>();
        List<string> description = new List<string>();
        List<Image> Imgs = new List<Image>();
        List<int> ID = new List<int>();
        int recipeCount;
        public int clickedCategoryID, clickedRecipeID;
        string id, name, reci, dura, serve, facts;
        public Image im;

        public RecipeList()
        {
            InitializeComponent();
        }

        private void RecipeList_Load(object sender, EventArgs e)
        {
            ShowRecipelist();
            RecipeCount();
        }



        private void recipe2_Load(object sender, EventArgs e)
        {
            RecipeCount();
            ShowRecipelist();
            if (recipeCount == 0)
            {
                txtNoResults.Visible = true;
            }
            recipe2.Height = recipe2.Height * recipeCount;

            recipe2.RecipesCount = recipeCount;
            recipe2.RecipesName = recipeName;
            recipe2.Img = Imgs;
            recipe2.Duration = duration;
            recipe2.RecipesId = ID;
            recipe2.Description = description;
        }

        private void recipe2_Clicked(object sender, EventArgs e)
        {
            Recipe c = (Recipe)sender;
            clickedRecipeID = c.clickedRecipe;
            ShowRecipeDetails();
            RecipeDetails details = new RecipeDetails();
            details.lblName.Text = name;
            details.lblDuration.Text = dura;
            details.txtRecipe.Text = reci;
            details.lblServCount.Text = serve;
            details.txtFacts.Text = facts;
            details.picFood.Image = im;
            details.txtId.Text = id;
            details.MdiParent = this.ParentForm;
            details.Dock = DockStyle.Fill;
            details.Show();
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowRecipelist()        //show categorized recipes
        {
            string categoryID = clickedCategoryID.ToString();
            da.SelectCommand = new SqlCommand("SELECT RecipeID,RecipeName,Duration,Image,Descriptions FROM Recipes WHERE RecipeCategoryID=@categoryid", cs);     //=====
            da.SelectCommand.Parameters.Add("@categoryid", SqlDbType.VarChar).Value = clickedCategoryID.ToString();
            cs.Open();
            try
            {
                SqlDataReader dr = da.SelectCommand.ExecuteReader();
                while (dr.Read())
                {
                    recipeId.Add(Convert.ToString(dr["RecipeID"]));
                    recipeName.Add(Convert.ToString(dr["RecipeName"]));
                    description.Add(Convert.ToString(dr["Descriptions"]));
                    duration.Add(Convert.ToString(dr["Duration"]));
                    byte[] imageBytes = (byte[])dr[3];
                    MemoryStream ms = new MemoryStream(imageBytes);
                    ms.Seek(0, SeekOrigin.Begin);
                    Image img = Image.FromStream(ms);
                    Imgs.Add(img);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please try again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                cs.Close();
            }

            for (int x = 0; x < recipeCount; x++)
            {
                int id = Convert.ToInt32(recipeId[x]);
                ID.Add(id);
            }
        }

        private void RecipeCount()      //Get recipe count according to the clicked recipe category
        {
            string categoryID = clickedCategoryID.ToString();
            da.SelectCommand = new SqlCommand("SELECT COUNT(RecipeID) FROM Recipes WHERE RecipeCategoryID=@categoryid", cs);
            da.SelectCommand.Parameters.Add("@categoryid", SqlDbType.VarChar).Value = clickedCategoryID.ToString();
            cs.Open();
            recipeCount = Convert.ToInt32(da.SelectCommand.ExecuteScalar());
            cs.Close();
        }

        public void ShowRecipeDetails()     //get all details of clicked recipe
        {
            string categoryID = clickedRecipeID.ToString();
            da.SelectCommand = new SqlCommand("SELECT RecipeID,RecipeName,Servings,Facts,Recipe,Duration,Image FROM Recipes WHERE RecipeID=@recipeid", cs);     //=====
            da.SelectCommand.Parameters.Add("@recipeid", SqlDbType.VarChar).Value = clickedRecipeID.ToString();
            cs.Open();
            try
            {
                SqlDataReader dr = da.SelectCommand.ExecuteReader();
            if (dr.Read())
            {
                id = dr.GetValue(0).ToString();
                name = dr.GetValue(1).ToString();
                reci = dr.GetValue(4).ToString();
                serve = dr.GetValue(2).ToString();
                facts = dr.GetValue(3).ToString();
                dura = dr.GetValue(5).ToString();
                byte[] imageBytes = (byte[])dr[6];
                MemoryStream ms = new MemoryStream(imageBytes);
                ms.Seek(0, SeekOrigin.Begin);
                Image im = Image.FromStream(ms);
            }
            }
            catch (Exception)
            {
                MessageBox.Show("Please try again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
            cs.Close();
            }
        }
    }
}
