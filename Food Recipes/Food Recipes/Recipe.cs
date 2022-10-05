using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food_Recipes
{
    public partial class Recipe : UserControl
    {
        public delegate void ClickedHandler(object sender, EventArgs e);
        public event ClickedHandler Clicked;

        List<int> RectangleStartWidth = new List<int>();
        List<int> RectangleStartHeight = new List<int>();
        int rectangleWidth=1050;
       int rectangleHeight =150;
       int rectangleRange = 170;
        int recipe;

        public Recipe()
        {
            InitializeComponent();
        }

       #region Properties

        [Category("Custom Props")]
        private List<int> recipesId;
        public List<int> RecipesId
        {
            get { return recipesId; }
            set
            {
                recipesId = value;
            }
        }

        [Category("Custom Props")]
        private int recipesCount;
        public int RecipesCount
        {
            get { return recipesCount; }
            set { recipesCount = value; }
        }

        [Category("Custom Props")]
        public List<string> recipesName;
        public List<string> RecipesName
        {
            get { return recipesName; }
            set { recipesName = value; }
        }

        [Category("Custom Props")]
        public List<Image> img;
        public List<Image> Img
        {
            get { return img; }
            set { img = value; }
        }

        [Category("Custom Props")]
        public List<string> duration;
        public List<string> Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        [Category("Custom Props")]
        public List<string> description;
        public List<string> Description
        {
            get { return description; }
            set { description = value; }
        }

        [Category("Custom Props")]
        public int indexY;
        public int IndexY
        {
            get { return indexY; }
            set { indexY = value; }
        }

        [Category("Custom Props")]
        public int indexX;
        public int IndexX
        {
            get { return indexX; }
            set { indexX = value; }
        }


        [Category("Custom Props")]
        public int clickedRecipe;
        public int ClickedRecipe
        {
            get { return clickedRecipe; }
            set { clickedRecipe = value; }
        }

        #endregion

        private void Recipe_Paint(object sender, PaintEventArgs e)
        {
         recipe = recipesCount;
         int topPadding = 30;      
         int leftPadding = 40;

            Graphics g = e.Graphics;

            if (recipesName != null)
            {
                for (int x = 0; x < recipe; x = x + 1)
                {

               RectangleF rectF2 = new RectangleF(leftPadding, topPadding, rectangleWidth, rectangleHeight);
               {
                   g.DrawRectangle(new Pen(Color.Black), Rectangle.Round(rectF2));

               }
                    g.FillRectangle(Brushes.LightSalmon, new Rectangle(leftPadding + 1, topPadding + 1, rectangleWidth - 1, rectangleHeight - 1));
                    g.DrawString(recipesName[x], new Font("Comic Sans MS", 15, FontStyle.Bold), Brushes.Black, leftPadding + 200, topPadding + 15);
                    g.DrawString("Duration: " + duration[x], new Font("Comic Sans MS", 11), Brushes.Black, leftPadding + 850, topPadding + 15);
                    RectangleF rectF = new RectangleF(leftPadding + 200, topPadding + 80, 600, 50);
                    {
                        g.DrawString(description[x], new Font("Comic Sans MS", 13), Brushes.Black, rectF);
                    }
                    g.DrawImage(img[x], leftPadding + 5, topPadding + 5, rectangleWidth -900, rectangleHeight - 10);

                    RectangleStartWidth.Add(leftPadding);
                    RectangleStartHeight.Add(topPadding);

                    topPadding = topPadding + rectangleRange;
                }
            }
        }

        private void Recipe_MouseClick(object sender, MouseEventArgs e)
        {
            indexX = (int)(e.X);
            indexY = (int)(e.Y);

            int startwidth,startHeight,endWidth,endHeight;
          
            int x = 0;

            do
            {
                startwidth = RectangleStartWidth[x];
                startHeight = RectangleStartHeight[x];
                endWidth = RectangleStartWidth[x] + rectangleWidth;
                endHeight = RectangleStartHeight[x] + rectangleHeight;

                if (indexX < endWidth && indexX > startwidth)
                {
                    if (indexY < endHeight && indexY > startHeight)
                    {
                        clickedRecipe = recipesId[x];
                        Clicked(this, null);
                    }
                }
                x++;
            } while (x < recipesCount);   
        }

        private void Recipe_Load(object sender, EventArgs e)
        {

        }
    }
}
