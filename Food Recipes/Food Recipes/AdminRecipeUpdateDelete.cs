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
using System.IO;

namespace Food_Recipes
{
    public partial class AdminRecipeUpdateDelete : Form
    {
        SqlConnection cs = new SqlConnection("Data Source=SHALANI\\SQLEXPRESS;Initial Catalog=FoodRecipes;User ID=sa;Password=Sql#Server");
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        string imageLocation;
        string catId;
        int categoryid;
        int CAT;
        bool checkRecipeName;

        public AdminRecipeUpdateDelete()
        {
            InitializeComponent();
            //get seleted recipe id from recipe list table
            txtRecipeID.Text = AdminRecipeList.SetValueForRecipeId;
            try
            {
                CAT = Convert.ToInt32(txtRecipeID.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please try again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //// cmbCategory.Text = adminre
            lblRecipeId.Visible = false;
            txtRecipeID.Visible = false;
        }

        private void AdminRecipeUpdateDelete_Load(object sender, EventArgs e)
        {
            showCategory();
            RecipeDetails();
        }

        public void RecipeDetails()
        {
            da.SelectCommand = new SqlCommand("SELECT R.RecipeName, R.Recipe, R.Duration, R.Image, R.Descriptions, R.Servings, R.Facts, C.RecipeCategoryName FROM Recipes R INNER JOIN RecipeCategories C ON R.RecipeCategoryID = C.RecipeCategoryID WHERE R.RecipeID = " + CAT, cs);
            cs.Open();
            try
            {
                SqlDataReader dr = da.SelectCommand.ExecuteReader();

                //da.Fill(ds);

                if (dr.Read())
                {
                    //txtRecipeID.Text = dr.GetInt32(0).ToString();
                    txtRecipeName.Text = dr.GetValue(0).ToString();
                    richtxtRecipe.Text = dr.GetValue(1).ToString();
                    txtDuration.Text = dr.GetValue(2).ToString();

                    byte[] imageBytes = (byte[])dr[3];
                    MemoryStream ms = new MemoryStream(imageBytes);
                    //ms.Seek(0, SeekOrigin.Begin);
                    Image imgs = System.Drawing.Image.FromStream(ms);
                    pbUpdate.Image = imgs;

                    richtxtDescription.Text = dr.GetValue(4).ToString();
                    txtServings.Text = dr.GetValue(5).ToString();
                    txtFacts.Text = dr.GetValue(6).ToString();
                    string catid = dr.GetValue(7).ToString();
                    cmbCategory.Text = catid;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void showCategory()
        {
            //get and how category name
            da.SelectCommand = new SqlCommand("SELECT * FROM RecipeCategories", cs);
            cs.Open();
            try
            {
                SqlDataReader dr = da.SelectCommand.ExecuteReader();

                while (dr.Read())
                {
                    cmbCategory.Items.Add(dr["RecipeCategoryName"]);
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
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void GetCategoryId()
        {
            string catid = cmbCategory.SelectedItem.ToString();
            da.SelectCommand = new SqlCommand("SELECT RecipeCategoryID FROM RecipeCategories WHERE RecipeCategoryName = @category", cs);
            da.SelectCommand.Parameters.Add("@category", SqlDbType.VarChar).Value = cmbCategory.SelectedItem.ToString();
            cs.Open();
            try
            {

                SqlDataReader dr = da.SelectCommand.ExecuteReader();
                while (dr.Read())
                {
                    string x = dr.GetValue(0).ToString();
                    categoryid = int.Parse(x);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            GetCategoryId();

            if ((txtRecipeName.Text == "") && (txtDuration.Text == "") && (txtServings.Text == "") && (txtFacts.Text == "") && (richtxtDescription.Text == "") && (richtxtRecipe.Text == ""))
            {
                MessageBox.Show("Please fill all the field");
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                pbUpdate.Image.Save(ms, pbUpdate.Image.RawFormat);
                byte[] imgUpdate = ms.ToArray();

                //SqlDataAdapter da = new SqlDataAdapter();
                da.UpdateCommand = new SqlCommand("UPDATE Recipes SET RecipeName=@RecipeName, Recipe=@Recipe, Duration=@Duration, Image=@Image, Descriptions=@Descriptions, Servings=@Servings, Facts=@Facts, RecipeCategoryID=@RecipeCategoryID, Bookmarks=0 WHERE RecipeID= " + CAT, cs);
                //da.UpdateCommand.Parameters.Add("@RecipeID", SqlDbType.Int).Value = txtRecipeID.Text.Trim();
                da.UpdateCommand.Parameters.Add("@RecipeName", SqlDbType.NVarChar).Value = txtRecipeName.Text.Trim();
                da.UpdateCommand.Parameters.Add("@Recipe", SqlDbType.NVarChar).Value = richtxtRecipe.Text.Trim();
                da.UpdateCommand.Parameters.Add("@Duration", SqlDbType.NVarChar).Value = txtDuration.Text.Trim();
                da.UpdateCommand.Parameters.Add("@Image", SqlDbType.Image).Value = imgUpdate;
                da.UpdateCommand.Parameters.Add("@Descriptions", SqlDbType.VarChar).Value = richtxtDescription.Text.Trim();
                da.UpdateCommand.Parameters.Add("@Servings", SqlDbType.Int).Value = txtServings.Text.Trim();
                da.UpdateCommand.Parameters.Add("@Facts", SqlDbType.NVarChar).Value = txtFacts.Text.Trim();
                da.UpdateCommand.Parameters.Add("@RecipeCategoryID", SqlDbType.Int).Value = categoryid;

                cs.Open();
                try
                {
                    da.UpdateCommand.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully!");
                    ClearField();
                    this.Close();
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //select image
            OpenFileDialog img = new OpenFileDialog();
            img.Filter = "Choose Image (*.JPG;*.PNG;*.JPEG)|*.jpg;*.jpeg;* .png*";
            if (img.ShowDialog() == DialogResult.OK)
            {
                imageLocation = img.FileName.ToString();

                //display selected image to the picture box
                pbUpdate.ImageLocation = imageLocation;
            }
        }

        private void btnProcedure_Click(object sender, EventArgs e)
        {
            //Open Word File in the text box
            using (OpenFileDialog ofd = new OpenFileDialog() { ValidateNames = true, Multiselect = false, Filter = "Choose Files (*doc)|*docx" })
            {
                //Stream myStream;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    object readOnly = false;
                    object visible = true;
                    object save = false;
                    object fileName = ofd.FileName;
                    object newTemplate = false;
                    object docType = 0;
                    object missing = Type.Missing;
                    Microsoft.Office.Interop.Word.Document document;
                    Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application() { Visible = false };
                    document = application.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                    document.ActiveWindow.Selection.WholeStory();
                    document.ActiveWindow.Selection.Copy();
                    IDataObject dataObject = Clipboard.GetDataObject();
                    richtxtRecipe.Rtf = dataObject.GetData(DataFormats.Rtf).ToString();
                    application.Quit(ref missing, ref missing, ref missing);
                }
            }
        }

        public void ClearField()
        {
            txtRecipeID.Text = "";
            txtRecipeName.Text = "";
            txtDuration.Text = "";
            txtFacts.Text = "";
            txtServings.Text = "";
            richtxtDescription.Text = "";
            richtxtRecipe.Text = "";
            pbUpdate.Image = null;
        }

        private void cmbCategory_Validating(object sender, CancelEventArgs e)
        {
            GetCategoryId();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            da.DeleteCommand = new SqlCommand("DELETE FROM Recipes WHERE RecipeID = " + CAT, cs);
            cs.Open();
            try
            {
                da.DeleteCommand.ExecuteNonQuery();
            MessageBox.Show("Deleted Successfuly!");
            this.Close();
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

       
        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
