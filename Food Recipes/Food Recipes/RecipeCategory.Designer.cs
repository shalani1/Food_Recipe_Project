namespace Food_Recipes
{
    partial class RecipeCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecipeCategory));
            this.txtNoResults = new System.Windows.Forms.Label();
            this.picBack = new System.Windows.Forms.PictureBox();
            this.category2 = new Food_Recipes.Category();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNoResults
            // 
            this.txtNoResults.AutoSize = true;
            this.txtNoResults.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoResults.Location = new System.Drawing.Point(187, 107);
            this.txtNoResults.Name = "txtNoResults";
            this.txtNoResults.Size = new System.Drawing.Size(336, 38);
            this.txtNoResults.TabIndex = 3;
            this.txtNoResults.Text = "Oops! No Results Found.";
            this.txtNoResults.Visible = false;
            // 
            // picBack
            // 
            this.picBack.Image = ((System.Drawing.Image)(resources.GetObject("picBack.Image")));
            this.picBack.Location = new System.Drawing.Point(0, 0);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(47, 27);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBack.TabIndex = 15;
            this.picBack.TabStop = false;
            this.picBack.Click += new System.EventHandler(this.picBack_Click);
            // 
            // category2
            // 
            this.category2.AutoScroll = true;
            this.category2.AutoSize = true;
            this.category2.BackColor = System.Drawing.Color.White;
            this.category2.CategoryCount = 0;
            this.category2.CategoryID = null;
            this.category2.CategoryName = null;
            this.category2.ClickedCategory = 0;
            this.category2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.category2.Img = null;
            this.category2.IndexX = 0;
            this.category2.IndexY = 0;
            this.category2.Location = new System.Drawing.Point(0, 0);
            this.category2.MinimumSize = new System.Drawing.Size(1100, 250);
            this.category2.Name = "category2";
            this.category2.Size = new System.Drawing.Size(1100, 250);
            this.category2.TabIndex = 2;
            this.category2.Clicked += new Food_Recipes.Category.ClickedHandler(this.category2_Clicked);
            this.category2.Load += new System.EventHandler(this.category2_Load);
            // 
            // RecipeCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(774, 789);
            this.ControlBox = false;
            this.Controls.Add(this.picBack);
            this.Controls.Add(this.txtNoResults);
            this.Controls.Add(this.category2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecipeCategory";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Category category2;
        private System.Windows.Forms.Label txtNoResults;
        private System.Windows.Forms.PictureBox picBack;
    }
}