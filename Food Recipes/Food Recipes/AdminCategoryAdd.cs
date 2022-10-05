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
    public partial class AdminCategoryAdd : Form
    {
        SqlConnection cs = new SqlConnection("Data Source=SHALANI\\SQLEXPRESS;Initial Catalog=FoodRecipes;User ID=sa;Password=Sql#Server");
        SqlDataAdapter da = new SqlDataAdapter();
        string imageLocation = "";
        bool checkCatname;
        int catCount = 0;
       
        public AdminCategoryAdd()
        {
            InitializeComponent();
            lblCatId.Visible = false;
            txtCatId.Visible = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            CheckExistName();

            if (txtCatName.Text.Trim() == "")
            {
                MessageBox.Show("Please fill all the field!");
                //lblmsgCatName.Text = "* Please fill category name!";
            }
            else
            {
                if (checkCatname == true)
                {
                    MessageBox.Show("This category already exist!");
                    txtCatName.Clear();
                }
                else
                {

                    //convert selected  image to binary
                    byte[] images = null;

                    if (imageLocation == "")//validate empty picture box
                    {
                        MessageBox.Show("Please choose image!");
                        // lblmsgImage.Text = "* Please choose image! ";
                    }
                    else
                    {
                        FileStream stream = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);

                        BinaryReader br = new BinaryReader(stream);
                        images = br.ReadBytes((int)stream.Length);


                        //lblmsgCatName.Visible = false;
                        //lblmsgCatName.Visible = false;
                        da.InsertCommand = new SqlCommand("INSERT INTO RecipeCategories(RecipeCategoryName, Image) VALUES (@catname, @images)", cs);
                        da.InsertCommand.Parameters.Add("@catname", SqlDbType.NVarChar).Value = txtCatName.Text.Trim();
                        da.InsertCommand.Parameters.Add("@images", SqlDbType.Image).Value = images;

                        cs.Open();
                        try
                        {
                            da.InsertCommand.ExecuteNonQuery();
                            MessageBox.Show("Successfully inserted!!!");
                            // FieldClear();
                            ClearField();
                            AutoRefreshGridView();
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
                pbCatImage.ImageLocation = imageLocation;
            }
        }

        //load data to the table
        public void AutoRefreshGridView()
        {
            da.SelectCommand = new SqlCommand("SELECT RecipeCategoryID, RecipeCategoryName,Image FROM RecipeCategories ", cs);
            DataTable dt = new DataTable();
            da.Fill(dt);

            //Count Number of Categories
            dgvCategory.DataSource = dt;
            dataGrideViewRowCount();
            this.dgvCategory.DefaultCellStyle.Font = new Font(" Microsoft JhengHei", 11);
        //  this.dgvCategory.DefaultCellStyle.hea
        //this.dgvCategory.DefaultCellStyle.SelectionBackColor = Color.DarkOrange;



        //make row  height 
        dgvCategory.RowTemplate.Height = 150;
            //dgvCategory.AllowUserToAddRows = false;

            //load data to the table
            dgvCategory.DataSource = dt;

            //stretch image in colum
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol = (DataGridViewImageColumn)dgvCategory.Columns[2];
            imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //auto make size of column 
            dgvCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
          
          

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //search category from table
            string searchQuery = "";
            if (txtSearch.Text != string.Empty)
                searchQuery += "[RecipeCategoryName] like '%" + txtSearch.Text.Trim() + "%' and ";
            searchQuery += "1 = 1";
            (dgvCategory.DataSource as DataTable).DefaultView.RowFilter = searchQuery;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CheckExistName();

            //checkCatname();
            if (txtCatName.Text.Trim() == "")
            {
                MessageBox.Show("Please fill all the field!");
                //lblmsgCatName.Text = "* Please fill category name!";
            }
            else
            {
                    
                    MemoryStream ms = new MemoryStream();
                    pbCatImage.Image.Save(ms, pbCatImage.Image.RawFormat);
                    byte[] imgUpdate = ms.ToArray();

                    //lblmsgCatName.Visible = false;
                    //lblmsgCatName.Visible = false;
                    da.UpdateCommand = new SqlCommand("UPDATE RecipeCategories SET RecipeCategoryName =@catname, Image = @images WHERE RecipeCategoryID = '" + txtCatId.Text + "'", cs);
                    da.UpdateCommand.Parameters.Add("@catname", SqlDbType.NVarChar).Value = txtCatName.Text.Trim();
                    da.UpdateCommand.Parameters.Add("@images", SqlDbType.Image).Value = imgUpdate;

                    cs.Open();
                try
                {
                    da.UpdateCommand.ExecuteNonQuery();
                    MessageBox.Show("Successfully Udated!!!");
                    // FieldClear();
                    ClearField();
                    AutoRefreshGridView();
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

        private void dgvCategory_Click(object sender, EventArgs e)
        {
            // when click row, show data in the text
            byte[] img = (byte[])dgvCategory.CurrentRow.Cells[2].Value;
            MemoryStream ms = new MemoryStream(img);
            pbCatImage.Image = Image.FromStream(ms);
            txtCatId.Text = dgvCategory.CurrentRow.Cells[0].Value.ToString();
            txtCatName.Text = dgvCategory.CurrentRow.Cells[1].Value.ToString();
        }

        private void AdminCategoryAdd_Load(object sender, EventArgs e)
        {
            AutoRefreshGridView();
            this.dgvCategory.Columns[0].Visible = false;
            //dgvCategory.HeaderStyle.BackColor = Color.DeepSkyBlue;
        }

        public void ClearField()
        {
            txtCatId.Text = "";
            txtCatName.Text = "";
            pbCatImage.Image = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCatId.Text = "";
            txtCatName.Text = "";
            pbCatImage.Image = null;
        }

        //Avoid Duplicate Category Name
        public void CheckExistName()
        {
            string ctegoryname = txtCatName.Text;
            da.SelectCommand = new SqlCommand("SELECT RecipeCategoryName FROM RecipeCategories WHERE RecipeCategoryName = @catname",cs);
            da.SelectCommand.Parameters.Add("@catname", SqlDbType.NVarChar).Value = txtCatName.Text.Trim();
            cs.Open();
            try
            {
                SqlDataReader dr = da.SelectCommand.ExecuteReader();
                if (dr.Read() == true)
                {
                    checkCatname = true;
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

        //Count Number of Categories
        public void dataGrideViewRowCount()
        {
            int rowcount = dgvCategory.Rows.Count;
            lblNumOfCat.Text = rowcount.ToString();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
           
           
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvCategory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
