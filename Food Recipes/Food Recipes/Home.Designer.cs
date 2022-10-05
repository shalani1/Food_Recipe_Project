namespace Food_Recipes
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.picHome = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picHome2 = new System.Windows.Forms.PictureBox();
            this.btnShowRecipes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHome2)).BeginInit();
            this.SuspendLayout();
            // 
            // picHome
            // 
            this.picHome.BackColor = System.Drawing.Color.Transparent;
            this.picHome.Image = ((System.Drawing.Image)(resources.GetObject("picHome.Image")));
            this.picHome.Location = new System.Drawing.Point(55, 12);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(671, 743);
            this.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHome.TabIndex = 0;
            this.picHome.TabStop = false;
            this.picHome.Click += new System.EventHandler(this.picHome_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(322, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome to Recipes World";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(642, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(334, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Search, Prepare and Enjoy.....";
            // 
            // picHome2
            // 
            this.picHome2.Image = ((System.Drawing.Image)(resources.GetObject("picHome2.Image")));
            this.picHome2.Location = new System.Drawing.Point(795, 213);
            this.picHome2.Name = "picHome2";
            this.picHome2.Size = new System.Drawing.Size(240, 142);
            this.picHome2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHome2.TabIndex = 2;
            this.picHome2.TabStop = false;
            // 
            // btnShowRecipes
            // 
            this.btnShowRecipes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowRecipes.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowRecipes.Location = new System.Drawing.Point(834, 422);
            this.btnShowRecipes.Name = "btnShowRecipes";
            this.btnShowRecipes.Size = new System.Drawing.Size(188, 42);
            this.btnShowRecipes.TabIndex = 3;
            this.btnShowRecipes.Text = "Go to Recipes >>";
            this.btnShowRecipes.UseVisualStyleBackColor = true;
            this.btnShowRecipes.Click += new System.EventHandler(this.btnShowRecipes_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1084, 595);
            this.ControlBox = false;
            this.Controls.Add(this.btnShowRecipes);
            this.Controls.Add(this.picHome2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picHome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHome2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picHome2;
        private System.Windows.Forms.Button btnShowRecipes;
    }
}