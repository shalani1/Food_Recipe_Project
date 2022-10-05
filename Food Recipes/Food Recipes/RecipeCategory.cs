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
    public partial class RecipeCategory : Form
    {
        SqlConnection cs = new SqlConnection("Data Source=SHALANI\\SQLEXPRESS;Initial Catalog=FoodRecipes;User ID=sa;Password=Sql#Server");
        SqlDataAdapter da = new SqlDataAdapter();

        List<string> CatName = new List<string>();
        List<string> CatId = new List<string>();
        List<Image> Imgs = new List<Image>();
        List<int> ID = new List<int>();

       public int catCount,clickedCatID;

        public RecipeCategory()
        {
            InitializeComponent();
        }

        private void category2_Load(object sender, EventArgs e)
        {
            CatCount();
         if (catCount == 0)
         {
             txtNoResults.Visible = true;
         }
         int rows = catCount / 4;
         int remain = catCount % 4;
         int height = rows + remain;

         category2.Height = category2.Height * height;
      
             showcategories();
            category2.CategoryCount = catCount;
            category2.CategoryName = CatName;
            category2.Img = Imgs;
            category2.CategoryID = ID;
        }

        private void category2_Clicked(object sender, EventArgs e)
        {
            Category c = (Category)sender;
            clickedCatID = c.clickedCategory;

            if (clickedCatID != 0)
            {
                RecipeList recipe = new RecipeList();
                recipe.clickedCategoryID = c.clickedCategory;
                recipe.MdiParent = this.ParentForm;
                recipe.Dock = DockStyle.Fill;
                recipe.Show();
            }
        }


        private void picBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void showcategories()        //Load all recipe categories
        {
            da.SelectCommand = new SqlCommand("SELECT * FROM RecipeCategories", cs);
            cs.Open();
            try
            {
                SqlDataReader dr = da.SelectCommand.ExecuteReader();
                while (dr.Read())
                {
                    CatName.Add(Convert.ToString(dr["RecipeCategoryName"]));
                    CatId.Add(Convert.ToString(dr["RecipeCategoryID"]));
                    byte[] imageBytes = (byte[])dr[2];
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

            for (int x = 0; x < catCount; x++)
            {
                int id = Convert.ToInt32(CatId[x]);
                ID.Add(id);
            }
        }

        public void CatCount()      //Get all recipe category count
        {
            da.SelectCommand = new SqlCommand("SELECT COUNT(RecipeCategoryID) FROM RecipeCategories", cs);
            cs.Open();
            try
            {
                catCount = Convert.ToInt32(da.SelectCommand.ExecuteScalar());
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
