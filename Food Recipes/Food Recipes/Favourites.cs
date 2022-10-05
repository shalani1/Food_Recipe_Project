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
    public partial class Favourites : Form
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
        public int clickedRecipeID;
        string id, name, reci, dura, serve, facts;
        public Image im;
       string bookmar = "1";
        public Favourites()
        {
            InitializeComponent();
        }

        private void Favourites_Load(object sender, EventArgs e)
        {
            ShowFavouriteRecipelist();
            FavourRecipeCount();
        }

        private void recipe1_Load(object sender, EventArgs e)
        {
            ShowFavouriteRecipelist();
            FavourRecipeCount();

            if (recipeCount == 0)
            {
                txtNoResults.Visible = true;
            }
            recipe1.Height = recipe1.Height * recipeCount;

            recipe1.RecipesCount = recipeCount;
            recipe1.RecipesName = recipeName;
            recipe1.Img = Imgs;
            recipe1.Duration = duration;
            recipe1.RecipesId = ID;
            recipe1.Description = description;
        }

        private void recipe1_Clicked(object sender, EventArgs e)
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
        public void ShowFavouriteRecipelist()       //show bookmarked recipes
        {

            da.SelectCommand = new SqlCommand("SELECT RecipeID,RecipeName,Duration,Image,Descriptions FROM Recipes WHERE Bookmarks='True'", cs);     //=====

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

        private void FavourRecipeCount()        //Get count of bookmarked recipes
        {
            string book = bookmar;
            da.SelectCommand = new SqlCommand("SELECT COUNT(RecipeID) FROM Recipes WHERE Bookmarks='True'", cs);
            cs.Open();
            try
            {
                recipeCount = Convert.ToInt32(da.SelectCommand.ExecuteScalar());
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

        public void ShowRecipeDetails()     //Show details of clicked recipe
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
