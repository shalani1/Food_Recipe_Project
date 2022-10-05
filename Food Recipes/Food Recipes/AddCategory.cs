using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Food_Recipes
{
    public partial class AddCategory : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=CT;Initial Catalog=FoodRecipes;User ID=sa;Password=Sql#Server");
        SqlDataAdapter da = new SqlDataAdapter();
        string imageLocation = "";
        bool checkCatname;

        public AddCategory()
        {
            InitializeComponent();
            lblCatId.Visible = false;
            txtCatId.Visible = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtCatName.Text.Trim() == "")
            {
                MessageBox.Show("Please fill all the field!");
                //lblmsgCatName.Text = "* Please fill category name!";
            }
            else
            {
                if (checkCatname == null)
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
                        da.InsertCommand = new SqlCommand("INSERT INTO RecipeCategories(RecipeCategoryName, Image) VALUES (@catname, @images)", con);
                        da.InsertCommand.Parameters.Add("@catname", SqlDbType.NVarChar).Value = txtCatName.Text.Trim();
                        da.InsertCommand.Parameters.Add("@images", SqlDbType.Image).Value = images;

                        con.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Successfully inserted!!!");
                        // FieldClear();
                        ClearField();
                        AutoRefreshGridView();
                        con.Close();
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
            da.SelectCommand = new SqlCommand("SELECT RecipeCategoryID, RecipeCategoryName,Image FROM RecipeCategories ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            //make row  height 
            dgvCategory.RowTemplate.Height = 100;
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
            //checkCatname();
            if (txtCatName.Text.Trim() == "")
            {
                MessageBox.Show("Please fill all the field!");
                //lblmsgCatName.Text = "* Please fill category name!";
            }
            else
            {
                if (checkCatname == null)
                {
                    MessageBox.Show("This category already exist!");
                    txtCatName.Clear();
                }
                else
                {

                    //convert selected  image to binary
                    byte[] images = null;

                    /* if (imageLocation == "")//validate empty picture box
                     {
                         lblmsgImage.Text = "* Please choose image! ";
                     }
                     else
                     {*/
                    FileStream stream = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);

                    BinaryReader br = new BinaryReader(stream);
                    images = br.ReadBytes((int)stream.Length);


                    //lblmsgCatName.Visible = false;
                    //lblmsgCatName.Visible = false;
                    da.UpdateCommand = new SqlCommand("UPDATE RecipeCategories SET RecipeCategoryName =@catname, Image = @images WHERE RecipeCategoryID = '" + txtCatId.Text + "'", con);
                    da.UpdateCommand.Parameters.Add("@catname", SqlDbType.NVarChar).Value = txtCatName.Text.Trim();
                    da.UpdateCommand.Parameters.Add("@images", SqlDbType.Image).Value = images;

                    con.Open();
                    da.UpdateCommand.ExecuteNonQuery();
                    MessageBox.Show("Successfully Udated!!!");
                    // FieldClear();
                    ClearField();
                    AutoRefreshGridView();
                    con.Close();
                }

            }
        }

        private void dgvCategory_ClientSizeChanged(object sender, EventArgs e)
        {

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

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddCategory_Load(object sender, EventArgs e)
        {
            AutoRefreshGridView();
            this.dgvCategory.Columns[0].Visible = false;
        }

        public void ClearField()
        {
            txtCatId.Text = "";
            txtCatName.Text = "";
            pbCatImage.Image = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            AdminDashboard  dash = new AdminDashboard();
            //dash.MdiParent = this.ParentForm;
            // dash.Dock = DockStyle.Fill;
            //this.
            //dash.Show();
           
            //MdiLayout.showControl(dash, panelContainer);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
