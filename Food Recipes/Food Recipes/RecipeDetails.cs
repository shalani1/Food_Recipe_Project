using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public partial class RecipeDetails : Form
    {
        SqlConnection cs = new SqlConnection("Data Source=SHALANI\\SQLEXPRESS;Initial Catalog=FoodRecipes;User ID=sa;Password=Sql#Server");
        SqlDataAdapter da = new SqlDataAdapter();

        public int recipeId;
        System.Drawing.Image imgs;
        string bookmark;
        byte[] imageBytes;

        public RecipeDetails()
        {
            InitializeComponent();
        }

        private void RecipeDetails_Load(object sender, EventArgs e)
        {
            txtFacts.Visible = false;
            picUnit.Visible = false;
            ShowRecipeDetails();
            txtId.Visible = false;
            if (bookmark == "True")
            {
                picBookmark.BackColor = Color.Orange;
            }
            else if (bookmark == "False")
            {
                picBookmark.BackColor = Color.White;
            }
        }

        public void ShowRecipeDetails()
        {
            string recipeID = txtId.Text;
            da.SelectCommand = new SqlCommand("SELECT Image,Bookmarks FROM Recipes WHERE RecipeID=@recipeid", cs);
            da.SelectCommand.Parameters.Add("@recipeid", SqlDbType.VarChar).Value = txtId.Text;
            cs.Open();
            SqlDataReader dr = da.SelectCommand.ExecuteReader();
           
                if (dr.Read())
                {
                bookmark = dr.GetValue(1).ToString();
                imageBytes = (byte[])dr[0];
                MemoryStream ms = new MemoryStream(imageBytes);
                ms.Seek(0, SeekOrigin.Begin);
                imgs = System.Drawing.Image.FromStream(ms);
                picFood.Image = imgs;
            }
                cs.Close();
         
        }      

        private void txtRecipe_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(txtRecipe.Text, txtRecipe.Font);
            txtRecipe.Height = size.Height;
            txtRecipe.Width = this.Width;          
        }

        private void RecipeDetails_Click(object sender, EventArgs e)
        {
            txtFacts.Visible = false;
        }

        private void txtFacts_Click(object sender, EventArgs e)
        {
            txtFacts.Visible = false;
        }

        private void picUnit_Click(object sender, EventArgs e)
        {
            picUnit.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            picUnit.Visible = true;
        }

        public void UnBookmaring()
        {
            string recipeID = txtId.Text;
            da.UpdateCommand = new SqlCommand("UPDATE Recipes SET Bookmarks='" + 0 + "' WHERE RecipeID=@recipeid", cs);
            da.UpdateCommand.Parameters.Add("@recipeid", SqlDbType.VarChar).Value = txtId.Text;
            cs.Open();
            da.UpdateCommand.ExecuteNonQuery();
            cs.Close();
            picBookmark.BackColor = Color.White;
        }

        public void Bookmarking()
        {
            da.UpdateCommand = new SqlCommand("UPDATE Recipes SET Bookmarks='" + 1 + "' WHERE RecipeID=@recipeid", cs);
            da.UpdateCommand.Parameters.Add("@recipeid", SqlDbType.VarChar).Value = txtId.Text;
            cs.Open();
            da.UpdateCommand.ExecuteNonQuery();
            cs.Close();
            picBookmark.BackColor = Color.Orange;
        }

        private void picBookmark_Click_1(object sender, EventArgs e)
        {
            ShowRecipeDetails();
            if (bookmark == "True")
            {
                UnBookmaring();
            }
            else if (bookmark == "False")
            {
                Bookmarking();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ShowRecipeDetails();
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));

                        doc.Open();


                        iTextSharp.text.Font nameFont = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 20, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.RED);
                        Paragraph name = new Paragraph(lblName.Text, nameFont);
                        name.Alignment = Element.ALIGN_CENTER;
                        doc.Add(name);

                        iTextSharp.text.Image recipeImage = iTextSharp.text.Image.GetInstance(imageBytes);

                        recipeImage.Alignment = Element.ALIGN_CENTER;
                        recipeImage.ScaleAbsolute(200f, 200f);
                        recipeImage.BorderColor = iTextSharp.text.BaseColor.ORANGE;

                        doc.Add(recipeImage);


                        iTextSharp.text.Font recipeFont = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                        Paragraph recipe = new Paragraph(txtRecipe.Text, recipeFont);
                        doc.Add(recipe);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        doc.Close();
                    }
                }
            }
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picFacts_Click(object sender, EventArgs e)
        {
            txtFacts.Visible = true;
        }

        private void picFood_Click(object sender, EventArgs e)
        {

        }
    }
}
