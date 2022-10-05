namespace Food_Recipes
{
    partial class AdminCategoryAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblNumOfCat = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblmsgImage = new System.Windows.Forms.Label();
            this.lblmsgCatName = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvCategory = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pbCatImage = new System.Windows.Forms.PictureBox();
            this.txtCatName = new System.Windows.Forms.TextBox();
            this.txtCatId = new System.Windows.Forms.TextBox();
            this.lblCatImage = new System.Windows.Forms.Label();
            this.lblCatName = new System.Windows.Forms.Label();
            this.lblCatId = new System.Windows.Forms.Label();
            this.lblRecipeCategory = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCatImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.lblNumOfCat);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblmsgImage);
            this.panel1.Controls.Add(this.lblmsgCatName);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.dgvCategory);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnInsert);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.pbCatImage);
            this.panel1.Controls.Add(this.txtCatName);
            this.panel1.Controls.Add(this.txtCatId);
            this.panel1.Controls.Add(this.lblCatImage);
            this.panel1.Controls.Add(this.lblCatName);
            this.panel1.Controls.Add(this.lblCatId);
            this.panel1.Controls.Add(this.lblRecipeCategory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 595);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Maroon;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack.Location = new System.Drawing.Point(2, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(83, 33);
            this.btnBack.TabIndex = 20;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblNumOfCat
            // 
            this.lblNumOfCat.AutoSize = true;
            this.lblNumOfCat.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNumOfCat.Location = new System.Drawing.Point(1069, 107);
            this.lblNumOfCat.Name = "lblNumOfCat";
            this.lblNumOfCat.Size = new System.Drawing.Size(0, 17);
            this.lblNumOfCat.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(973, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = " Categories :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(480, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Search";
            // 
            // lblmsgImage
            // 
            this.lblmsgImage.AutoSize = true;
            this.lblmsgImage.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblmsgImage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblmsgImage.Location = new System.Drawing.Point(137, 469);
            this.lblmsgImage.Name = "lblmsgImage";
            this.lblmsgImage.Size = new System.Drawing.Size(0, 17);
            this.lblmsgImage.TabIndex = 15;
            // 
            // lblmsgCatName
            // 
            this.lblmsgCatName.AutoSize = true;
            this.lblmsgCatName.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsgCatName.ForeColor = System.Drawing.Color.Red;
            this.lblmsgCatName.Location = new System.Drawing.Point(146, 258);
            this.lblmsgCatName.Name = "lblmsgCatName";
            this.lblmsgCatName.Size = new System.Drawing.Size(0, 15);
            this.lblmsgCatName.TabIndex = 14;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Maroon;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdate.Location = new System.Drawing.Point(217, 497);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(83, 33);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtSearch.Location = new System.Drawing.Point(534, 95);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(326, 25);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgvCategory
            // 
            this.dgvCategory.AllowUserToAddRows = false;
            this.dgvCategory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCategory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCategory.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategory.Location = new System.Drawing.Point(483, 130);
            this.dgvCategory.Name = "dgvCategory";
            this.dgvCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategory.Size = new System.Drawing.Size(589, 453);
            this.dgvCategory.TabIndex = 10;
            this.dgvCategory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategory_CellContentClick);
            this.dgvCategory.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCategory_DataBindingComplete);
            this.dgvCategory.Click += new System.EventHandler(this.dgvCategory_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Maroon;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.Location = new System.Drawing.Point(306, 497);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 33);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cansel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.Maroon;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnInsert.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInsert.Location = new System.Drawing.Point(132, 497);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(83, 33);
            this.btnInsert.TabIndex = 8;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.IndianRed;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBrowse.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBrowse.Location = new System.Drawing.Point(328, 417);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(68, 26);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // pbCatImage
            // 
            this.pbCatImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCatImage.Location = new System.Drawing.Point(138, 188);
            this.pbCatImage.Name = "pbCatImage";
            this.pbCatImage.Size = new System.Drawing.Size(258, 219);
            this.pbCatImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCatImage.TabIndex = 6;
            this.pbCatImage.TabStop = false;
            // 
            // txtCatName
            // 
            this.txtCatName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.txtCatName.Location = new System.Drawing.Point(140, 133);
            this.txtCatName.Name = "txtCatName";
            this.txtCatName.Size = new System.Drawing.Size(256, 24);
            this.txtCatName.TabIndex = 5;
            // 
            // txtCatId
            // 
            this.txtCatId.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.txtCatId.Location = new System.Drawing.Point(140, 104);
            this.txtCatId.Name = "txtCatId";
            this.txtCatId.Size = new System.Drawing.Size(256, 24);
            this.txtCatId.TabIndex = 4;
            // 
            // lblCatImage
            // 
            this.lblCatImage.AutoSize = true;
            this.lblCatImage.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.lblCatImage.Location = new System.Drawing.Point(86, 201);
            this.lblCatImage.Name = "lblCatImage";
            this.lblCatImage.Size = new System.Drawing.Size(46, 17);
            this.lblCatImage.TabIndex = 3;
            this.lblCatImage.Text = "Image";
            // 
            // lblCatName
            // 
            this.lblCatName.AutoSize = true;
            this.lblCatName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.lblCatName.Location = new System.Drawing.Point(29, 136);
            this.lblCatName.Name = "lblCatName";
            this.lblCatName.Size = new System.Drawing.Size(103, 17);
            this.lblCatName.TabIndex = 2;
            this.lblCatName.Text = "Category Name";
            // 
            // lblCatId
            // 
            this.lblCatId.AutoSize = true;
            this.lblCatId.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F);
            this.lblCatId.Location = new System.Drawing.Point(53, 103);
            this.lblCatId.Name = "lblCatId";
            this.lblCatId.Size = new System.Drawing.Size(79, 17);
            this.lblCatId.TabIndex = 1;
            this.lblCatId.Text = "Category Id";
            // 
            // lblRecipeCategory
            // 
            this.lblRecipeCategory.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRecipeCategory.AutoSize = true;
            this.lblRecipeCategory.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblRecipeCategory.Location = new System.Drawing.Point(464, 0);
            this.lblRecipeCategory.Name = "lblRecipeCategory";
            this.lblRecipeCategory.Size = new System.Drawing.Size(249, 38);
            this.lblRecipeCategory.TabIndex = 0;
            this.lblRecipeCategory.Text = "Recipe Categories";
            // 
            // AdminCategoryAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 595);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminCategoryAdd";
            this.Text = "AdminCategoryAdd";
            this.Load += new System.EventHandler(this.AdminCategoryAdd_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCatImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblmsgImage;
        private System.Windows.Forms.Label lblmsgCatName;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvCategory;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox pbCatImage;
        private System.Windows.Forms.TextBox txtCatName;
        private System.Windows.Forms.TextBox txtCatId;
        private System.Windows.Forms.Label lblCatImage;
        private System.Windows.Forms.Label lblCatName;
        private System.Windows.Forms.Label lblCatId;
        private System.Windows.Forms.Label lblRecipeCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumOfCat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBack;
    }
}