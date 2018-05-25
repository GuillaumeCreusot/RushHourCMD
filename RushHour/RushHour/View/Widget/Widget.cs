using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    /// <summary>
    /// Widget
    /// </summary>
    class Widget
    {
        /// <summary>
        /// widget's span
        /// </summary>
        private int[] span;

        /// <summary>
        /// maximum widget's span
        /// </summary>
        private int[] spanMax;    

        /// <summary>
        /// color with which the color pattern is initialised
        /// </summary>
        public ConsoleColor BasicColor { get; set; }

        /// <summary>
        /// widget's name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// WidgetManager in which this widget is contained
        /// </summary>
        public WidgetsManager Master { get; set; }

        /// <summary>
        /// color for each character of content
        /// </summary>
        private ConsoleColor[,] colorPattern;
        public ConsoleColor[,] ColorPattern
        {
            get
            {
                return colorPattern;
            }
            protected set
            {
                colorPattern = value;
            }
        }

        /// <summary>
        /// number columns of content
        /// </summary>
        public int ColumnSpan
        {
            set
            {
                span[1] = value;
            }
            get
            {
                return span[1];
            }
        }

        /// <summary>
        /// number of rows of content
        /// </summary>
        public int RowSpan
        {
            set
            {
                span[0] = value;
            }
            get
            {
                return span[0];
            }
        }

        /// <summary>
        /// maximum number of columns of content
        /// </summary>
        public int ColumnSpanMax
        {
            get
            {
                return spanMax[1];
            }
        }

        /// <summary>
        /// maximum number of rows of content
        /// </summary>
        public int RowSpanMax
        {
            get
            {
                return spanMax[0];
            }
        }

        /// <summary>
        /// content which will be shown on screen
        /// </summary>
        private string content = "";
        public virtual string Content
        {
            get
            {
                return content;
            }
            protected set
            {
                //span
                int[] dim = WidgetUtility.DimContent(value);

                if (dim[0] > RowSpanMax)
                {
                    throw new Exception($"Le contenu du widget {Name} depasse en hauteur");
                }
                if (dim[1] > ColumnSpanMax)
                {
                    throw new Exception($"Le contenu du widget {Name} depasse en largeur");
                }

                ColumnSpan = dim[1];
                RowSpan = dim[0];

                // make all rows even
                content = WidgetUtility.Resize(value, dim[1]);

                //color
                colorPattern = new ConsoleColor[dim[0], dim[1]];

                for(int i = 0; i < colorPattern.GetLength(0); i++)
                {
                    for(int j = 0; j < colorPattern.GetLength(1); j++)
                    {
                        colorPattern[i, j] = BasicColor;
                    }
                }
            }
        }

        /// <summary>
        /// position of widget on widget manager
        /// </summary>
        private int[] position;
        public int[] Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        /// <summary>
        /// Pattern which deletes exactly the content of this widget on the screen
        /// </summary>
        public string DeletePattern
        {
            get
            {
                string result = "";
                for (int i = 0; i < RowSpan ; i++)
                {
                    for(int j = 0; j < ColumnSpan ; j++)
                    {
                        if(content[j + i * (ColumnSpan+1)] == '\u0000')
                        {
                            result += '\u0000';
                        }
                        else
                        {
                            result += " ";
                        }
                    }
                    if(i != RowSpan - 1)
                    {
                        result += "\n";
                    }
                    
                }

                return result;
            }
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">widget's name</param>
        public Widget(string name, int rowSpanMax, int columnSpanMax)
        {
            span = new int[2];
            spanMax = new int[] { rowSpanMax, columnSpanMax };
            position = new int[2];
            Name = name;
            BasicColor = ConsoleColor.White;
        }

        /// <summary>
        /// delete widget's content
        /// </summary>
        public void DeleteContent()
        {
            Content = DeletePattern;
        }

    }
}
