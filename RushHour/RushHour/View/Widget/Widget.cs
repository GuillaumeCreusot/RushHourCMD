using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class Widget
    {
        private int[] span;
        private int[] spanMax;
        private string content = "";
        private ConsoleColor[,] colorPattern;
        private int[] position;

        /// <summary>
        /// Corlor with which the color pattern is initialised
        /// </summary>
        public ConsoleColor BasicColor { get; set; }

        /// <summary>
        /// Nom du widget
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// WidgetManager dans lequel ce widget est inclus
        /// </summary>
        public WidgetsManager Master { get; set; }


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
        /// Nombre de colonne occuppé par ce widget
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
        /// nombre de rang occupé par ce widget
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
        /// Nombre de colonne occuppé par ce widget
        /// </summary>
        public int ColumnSpanMax
        {
            get
            {
                return spanMax[1];
            }
        }

        /// <summary>
        /// nombre de rang occupé par ce widget
        /// </summary>
        public int RowSpanMax
        {
            get
            {
                return spanMax[0];
            }
        }

        /// <summary>
        /// Contenu du widget 
        /// </summary>
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

                // uniformisation de la taille des rangs
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
        /// Position du widget dans le widget manager
        /// </summary>
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
        /// Constructeur
        /// </summary>
        /// <param name="name">nom du widget</param>
        public Widget(string name, int rowSpanMax, int columnSpanMax)
        {
            span = new int[2];
            spanMax = new int[] { rowSpanMax, columnSpanMax };
            position = new int[2];
            Name = name;
            BasicColor = ConsoleColor.White;
        }

        public void DeleteContent()
        {
            Content = DeletePattern;
        }

    }
}
