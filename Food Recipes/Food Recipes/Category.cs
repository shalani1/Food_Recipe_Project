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
    public partial class Category : UserControl
    {
        public delegate void ClickedHandler(object sender, EventArgs e);
        public event ClickedHandler Clicked;

        List<int> RectangleStartWidth = new List<int>();
        List<int> RectangleStartHeight = new List<int>();
        int rectangleWidth = 230;
        int rectangleRange = 260;
        int cat;

        public Category()
        {
            InitializeComponent();      
        }

        #region Properties

        [Category("Custom Props")]
        public List<int> categoryId;
        public List<int> CategoryID
        {
            get { return categoryId; }
            set
            {
                categoryId = value;
                if (Clicked != null)
                {
                    Clicked(this, null);
                }
            }
        }

        [Category("Custom Props")]
        public int categoryCount;
        public int CategoryCount
        {
            get { return categoryCount; }
            set { categoryCount = value;}
        }

        [Category("Custom Props")]
       public List<string> categoryName;
        public List<string> CategoryName
        {
            get { return categoryName; }
            set { categoryName = value;}
        }

        [Category("Custom Props")]
       public List<Image> img;
        public List<Image> Img
        {
            get { return img; }
            set { img = value;}
        }

        [Category("Custom Props")]
        public int indexX;
        public int IndexX
        {
            get { return indexX; }
            set { indexX = value; }
        }
        [Category("Custom Props")]
        public int indexY;
        public int IndexY
        {
            get { return indexY; }
            set { indexY = value; }
        }

        [Category("Custom Props")]
        public int clickedCategory;
        public int ClickedCategory
        {
            get { return clickedCategory; }
            set { clickedCategory = value; }
        }

        #endregion
    
        private void Category_Load(object sender, EventArgs e)
        {
            cat = categoryCount; 
        }

        private void Category_Paint(object sender, PaintEventArgs e)
        {         
          cat = categoryCount;

           int topPadding = 20;
           int leftPadding = 80;      
            int count = 0;
          
            Graphics g = e.Graphics;
            if(categoryName!=null)
            {
                for (int x = 0; x < cat; x = x + 1) 
                {
                    if (count == 4)
                    {
                        count = 0;
                        topPadding = topPadding + rectangleRange;
                    }

                    g.DrawRectangle(new Pen(Color.Black), (count * rectangleRange) + leftPadding, topPadding, rectangleWidth, rectangleWidth);
                    g.FillRectangle(Brushes.Chocolate, new Rectangle((count * rectangleRange) + leftPadding, topPadding, rectangleWidth, rectangleWidth));
                    g.DrawString(categoryName[x], new Font("Comic Sans MS", 20, FontStyle.Bold), Brushes.Black, (count * rectangleRange) + leftPadding + 60, topPadding);
                     g.DrawImage(img[x], count * rectangleRange+100, topPadding+40, rectangleWidth-40, rectangleWidth-60);
                     RectangleStartWidth.Add(count * rectangleRange + 100);
                     RectangleStartHeight.Add(topPadding+40);

                    count++;
                }
            }
        }

        private void Category_Click(object sender, EventArgs e)
        {
           
        }

        private void Category_MouseClick(object sender, MouseEventArgs e)
        {
           indexX = (int)(e.X);
          indexY = (int)(e.Y);

              int startwidth,startHeight,endWidth,endHeight;

            int x=0;

            do
            {
                startwidth = RectangleStartWidth[x];
                startHeight = RectangleStartHeight[x];
                endWidth = RectangleStartWidth[x] + (rectangleWidth - 40);
                endHeight = RectangleStartHeight[x] + (rectangleWidth - 60);

              if (indexX < endWidth && indexX > startwidth)
              {
                  if (indexY < endHeight && indexY > startHeight)
                  {
                      clickedCategory = categoryId[x];
                      Clicked(this, null);
                  }                
              }
                x++;
             }while(x<cat);       
        }
    }
}
