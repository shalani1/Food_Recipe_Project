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
    public partial class SearchedRecipes : Form
    {
        SqlConnection cs = new SqlConnection("Data Source=SHALANI\\SQLEXPRESS;Initial Catalog=FoodRecipes;User ID=sa;Password=Sql#Server");
      
       
        SqlDataAdapter da = new SqlDataAdapter();

        string search;
        int searchCount;

        List<string> recipeName = new List<string>();
        List<string> recipeID = new List<string>();
        List<string> recipes = new List<string>();
        List<string> duration = new List<string>();
        List<Image> Imgs = new List<Image>();
        List<int> searchID = new List<int>();


        string id, name, reci, serve, facts, dura;
        Image im;
  
        public int clickedRecipeID;
          
        public SearchedRecipes()
        {
            InitializeComponent();
           // SQLCONNECTION cs = new SQLCONNECTION();
            //cs.Connection();

        }

        public SearchedRecipes(string word)
        {
            InitializeComponent();
             search= word;
        }

        private void recipe1_Load(object sender, EventArgs e)
        {
            SearchedCount();
            SearchRecipes();
            if (searchCount == 0)
            {
                txtNoResults.Visible = true;
            }
            recipe1.Height = recipe1.Height * searchCount;

            recipe1.RecipesCount = searchCount;
            recipe1.RecipesName = recipeName;
            recipe1.Img = Imgs;
            recipe1.Duration = duration;
            recipe1.RecipesId = searchID;
            recipe1.Description = recipes;          
        }

        
        private void recipe1_Clicked(object sender, EventArgs e)
        {
            Recipe c = (Recipe)sender;
            clickedRecipeID = c.clickedRecipe;

            ShowRecipeDetails();
            RecipeDetails details = new RecipeDetails();
            details.lblName.Text = name;
            details.lblDuration.Text = dura;
            details.picFood.Image = im;
            details.txtRecipe.Text = reci;
            details.lblServCount.Text = serve;
            details.txtFacts.Text = facts;
            details.txtId.Text = id;
            details.MdiParent = this.ParentForm;
            details.Dock = DockStyle.Fill;
            details.Show();  
        }

        
        private void picBack_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void SearchedCount()  //Get count of the recipes that relavent to the searching recipe
        {
            string categoryID = search;
            da.SelectCommand = new SqlCommand("SELECT count(RecipeID) FROM Recipes WHERE Recipe LIKE '%'+@recipeword+'%'", cs);     
            da.SelectCommand.Parameters.Add("@recipeword", SqlDbType.VarChar).Value = search;
            cs.Open();
            try
            {
                searchCount = Convert.ToInt32(da.SelectCommand.ExecuteScalar());
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

        public void SearchRecipes()     //Get recipe list relavent to the searching recipe
        {
            string recipeid = search;
            da.SelectCommand = new SqlCommand("SELECT RecipeID,RecipeName,Description,Duration,Image FROM Recipes WHERE Recipe LIKE '%'+@recipeword+'%'", cs);     
            da.SelectCommand.Parameters.Add("@recipeword", SqlDbType.VarChar).Value = search;
            cs.Open();
            try
            {
                SqlDataReader dr = da.SelectCommand.ExecuteReader();
                while (dr.Read())
                {
                    recipeID.Add(Convert.ToString(dr["RecipeID"]));
                    recipeName.Add(Convert.ToString(dr["RecipeName"]));
                    recipes.Add(Convert.ToString(dr["Description"]));
                    duration.Add(Convert.ToString(dr["Duration"]));
                    byte[] imageBytes = (byte[])dr[4];
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
            for (int x = 0; x < searchCount; x++)
            {
                int id = Convert.ToInt32(recipeID[x]);
                searchID.Add(id);
            }
        }

            public void ShowRecipeDetails()     //show recipe details of clicked recipe
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

            private void SearchedRecipes_Load(object sender, EventArgs e)
            {

            }

        }

    }

