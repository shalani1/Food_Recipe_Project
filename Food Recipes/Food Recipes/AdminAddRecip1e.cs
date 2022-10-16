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
    public partial class AdminAddRecipe : Form
    {
        SqlConnection cs = new SqlConnection("Data Source=CT;Initial Catalog=FoodRecipes;User ID=sa;Password=Sql#Server");
        SqlDataAdapter da = new SqlDataAdapter();

        string imagelocation;
        int catId;

        public AdminAddRecipe()
        {
            InitializeComponent();
            txtRecipeID.Visible = false;
            lblRecipeId.Visible = false;
            showCategories();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((txtRecipeName.Text == "") && (txtDuration.Text == "") && (txtServings.Text == "") && (txtFacts.Text == "") && (richtxtDescription.Text == "") && (richtxtRecipe.Text == ""))
            {
                MessageBox.Show("Please fill all the field");
            }
            else
            {
                //convert selected  image to binary
                byte[] images = null;

                if (imagelocation == "")//validate empty picture box
                {
                    MessageBox.Show("Please attach image");
                }
                else
                {
                    FileStream stream = new FileStream(imagelocation, FileMode.Open, FileAccess.Read);

                    BinaryReader br = new BinaryReader(stream);
                    images = br.ReadBytes((int)stream.Length);
                    da.InsertCommand = new SqlCommand("INSERT INTO Recipes(RecipeName, Recipe, Duration, Image, Descriptions, Servings, Facts, RecipeCategoryID, Bookmarks) Values (@RecipeName, @Recipe, @Duration, @Image, @Descriptions, @Servings, @Facts, @RecipeCategoryID, 0)", cs);
                    da.InsertCommand.Parameters.Add("@RecipeName", SqlDbType.NVarChar).Value = txtRecipeName.Text.Trim();
                    da.InsertCommand.Parameters.Add("@Recipe", SqlDbType.NVarChar).Value = richtxtRecipe.Text.Trim();
                    da.InsertCommand.Parameters.Add("@Duration", SqlDbType.NVarChar).Value = txtDuration.Text.Trim();
                    da.InsertCommand.Parameters.Add("@Image", SqlDbType.Image).Value = images;
                    da.InsertCommand.Parameters.Add("@Descriptions", SqlDbType.VarChar).Value = richtxtDescription.Text.Trim();
                    da.InsertCommand.Parameters.Add("@Servings", SqlDbType.Int).Value = txtServings.Text.Trim();
                    da.InsertCommand.Parameters.Add("@Facts", SqlDbType.NVarChar).Value = txtFacts.Text.Trim();
                    da.InsertCommand.Parameters.Add("@RecipeCategoryID", SqlDbType.Int).Value = catId;

                    cs.Open();
                    try
                    {
                        da.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Insert Successfully!");
                        ClearField();
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show(".jpg, .jped, png are the allowed Image type!");
                    } 
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
                imagelocation = img.FileName.ToString();

                //display selected image to the picture box
                pbAddRecipe.ImageLocation = imagelocation;
            }
        }

        private void btnProcedure_Click(object sender, EventArgs e)
        {
            //Open Word File in the text box
            using (OpenFileDialog ofd = new OpenFileDialog() { ValidateNames = true, Multiselect = false, Filter = "Choose Files (*doc)|*docx" })
            {
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearField();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            AdminRecipeList list = new AdminRecipeList();
            list.MdiParent = this.ParentForm;
            list.Dock = DockStyle.Fill;
            list.Show();
        }

        //show categorie's name in the drop down box
        private void showCategories()
        {
            da.SelectCommand = new SqlCommand("SELECT * FROM RecipeCategories", cs);
            cs.Open();
            SqlDataReader dr = da.SelectCommand.ExecuteReader();

            while (dr.Read())
            {
                cmbCategory.Items.Add(dr["RecipeCategoryName"]);
            }
            cs.Close();

            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //Get selected category id
        private void GetCategoryId()
        {
            string categoryName = cmbCategory.SelectedItem.ToString();

            da.SelectCommand = new SqlCommand("SELECT RecipeCategoryID FROM RecipeCategories WHERE RecipeCategoryName = @categoryname", cs);
            da.SelectCommand.Parameters.Add("@categoryname", SqlDbType.NVarChar).Value = cmbCategory.SelectedItem.ToString();

            cs.Open();
            da.SelectCommand.ExecuteNonQuery();

            SqlDataReader dr = da.SelectCommand.ExecuteReader();
            while (dr.Read())
            {
                string x = dr.GetValue(0).ToString();
                catId = int.Parse(x);
            }

            cs.Close();
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
            pbAddRecipe.Image = null;
        }

        private void cmbCategory_Validating(object sender, CancelEventArgs e)
        {
            GetCategoryId();
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
