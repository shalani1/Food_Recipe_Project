namespace Food_Recipes
{
    partial class RecipeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecipeList));
            this.txtNoResults = new System.Windows.Forms.Label();
            this.picBack = new System.Windows.Forms.PictureBox();
            this.recipe2 = new Food_Recipes.Recipe();
            this.recipe1 = new Food_Recipes.Recipe();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNoResults
            // 
            this.txtNoResults.AutoSize = true;
            this.txtNoResults.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoResults.Location = new System.Drawing.Point(180, 76);
            this.txtNoResults.Name = "txtNoResults";
            this.txtNoResults.Size = new System.Drawing.Size(336, 38);
            this.txtNoResults.TabIndex = 2;
            this.txtNoResults.Text = "Oops! No Results Found.";
            this.txtNoResults.Visible = false;
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
            // recipe2
            // 
            this.recipe2.AutoSize = true;
            this.recipe2.BackColor = System.Drawing.Color.White;
            this.recipe2.ClickedRecipe = 0;
            this.recipe2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.recipe2.Description = null;
            this.recipe2.Duration = null;
            this.recipe2.Img = null;
            this.recipe2.IndexX = 0;
            this.recipe2.IndexY = 0;
            this.recipe2.Location = new System.Drawing.Point(0, 0);
            this.recipe2.MinimumSize = new System.Drawing.Size(1100, 200);
            this.recipe2.Name = "recipe2";
            this.recipe2.RecipesCount = 0;
            this.recipe2.RecipesId = null;
            this.recipe2.RecipesName = null;
            this.recipe2.Size = new System.Drawing.Size(1100, 200);
            this.recipe2.TabIndex = 1;
            this.recipe2.Clicked += new Food_Recipes.Recipe.ClickedHandler(this.recipe2_Clicked);
            this.recipe2.Load += new System.EventHandler(this.recipe2_Load);
            // 
            // recipe1
            // 
            this.recipe1.AutoScroll = true;
            this.recipe1.AutoSize = true;
            this.recipe1.BackColor = System.Drawing.Color.White;
            this.recipe1.ClickedRecipe = 0;
            this.recipe1.Description = null;
            this.recipe1.Duration = null;
            this.recipe1.Img = null;
            this.recipe1.IndexX = 0;
            this.recipe1.IndexY = 0;
            this.recipe1.Location = new System.Drawing.Point(1, -10);
            this.recipe1.Name = "recipe1";
            this.recipe1.RecipesCount = 0;
            this.recipe1.RecipesId = null;
            this.recipe1.RecipesName = null;
            this.recipe1.Size = new System.Drawing.Size(780, 0);
            this.recipe1.TabIndex = 0;
            // 
            // RecipeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(774, 797);
            this.ControlBox = false;
            this.Controls.Add(this.picBack);
            this.Controls.Add(this.txtNoResults);
            this.Controls.Add(this.recipe2);
            this.Controls.Add(this.recipe1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecipeList";
            this.Text = "RecipeList";
            this.Load += new System.EventHandler(this.RecipeList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Recipe recipe1;
        private Recipe recipe2;
        private System.Windows.Forms.Label txtNoResults;
        private System.Windows.Forms.PictureBox picBack;
    }
}