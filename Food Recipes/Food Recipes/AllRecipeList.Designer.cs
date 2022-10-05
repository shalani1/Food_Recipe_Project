namespace Food_Recipes
{
    partial class AllRecipeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllRecipeList));
            this.txtNoResults = new System.Windows.Forms.Label();
            this.recipe1 = new Food_Recipes.Recipe();
            this.picBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNoResults
            // 
            this.txtNoResults.AutoSize = true;
            this.txtNoResults.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoResults.Location = new System.Drawing.Point(176, 108);
            this.txtNoResults.Name = "txtNoResults";
            this.txtNoResults.Size = new System.Drawing.Size(336, 38);
            this.txtNoResults.TabIndex = 3;
            this.txtNoResults.Text = "Oops! No Results Found.";
            this.txtNoResults.Visible = false;
            // 
            // recipe1
            // 
            this.recipe1.AutoSize = true;
            this.recipe1.BackColor = System.Drawing.Color.White;
            this.recipe1.ClickedRecipe = 0;
            this.recipe1.Description = null;
            this.recipe1.Duration = null;
            this.recipe1.Img = null;
            this.recipe1.IndexX = 0;
            this.recipe1.IndexY = 0;
            this.recipe1.Location = new System.Drawing.Point(0, 0);
            this.recipe1.MinimumSize = new System.Drawing.Size(1100, 175);
            this.recipe1.Name = "recipe1";
            this.recipe1.RecipesCount = 0;
            this.recipe1.RecipesId = null;
            this.recipe1.RecipesName = null;
            this.recipe1.Size = new System.Drawing.Size(1100, 175);
            this.recipe1.TabIndex = 0;
            this.recipe1.Clicked += new Food_Recipes.Recipe.ClickedHandler(this.recipe1_Clicked);
            this.recipe1.Load += new System.EventHandler(this.recipe1_Load);
            // 
            // picBack
            // 
            this.picBack.BackColor = System.Drawing.Color.Transparent;
            this.picBack.Image = ((System.Drawing.Image)(resources.GetObject("picBack.Image")));
            this.picBack.Location = new System.Drawing.Point(0, 0);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(47, 27);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBack.TabIndex = 15;
            this.picBack.TabStop = false;
            this.picBack.Click += new System.EventHandler(this.picBack_Click);
            // 
            // AllRecipeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(774, 383);
            this.ControlBox = false;
            this.Controls.Add(this.picBack);
            this.Controls.Add(this.txtNoResults);
            this.Controls.Add(this.recipe1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AllRecipeList";
            this.Text = "AllRecipeList";
            this.Load += new System.EventHandler(this.AllRecipeList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Recipe recipe1;
        private System.Windows.Forms.Label txtNoResults;
        private System.Windows.Forms.PictureBox picBack;
    }
}