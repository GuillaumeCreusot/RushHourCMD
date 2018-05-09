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
        private int[] position;

        private bool change;

        /// <summary>
        /// Nom du widget
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// WidgetManager dans lequel ce widget est inclus
        /// </summary>
        public WidgetsManager Master { get; set; }

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
        public string Content
        {
            get
            {
                return content;
            }
            protected set
            {
                //span
                int[] dim = WidgetUtility.DimContent(value);

                if(dim[0] > RowSpanMax)
                {
                    throw new Exception($"Le contenu du widget {Name} depasse en hauteur");
                }
                if (dim[1] > ColumnSpanMax)
                {
                    throw new Exception($"Le contenu du widget {Name} depasse en largeur");
                }

                Change = true;

                ColumnSpan = dim[1];
                RowSpan = dim[0];

                // uniformisation de la taille des rangs
                content = WidgetUtility.Resize(value, dim[1]);

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
                for (int i = 0; i < RowSpan-1; i++)
                {
                    result += new string(' ', ColumnSpan) + "\n";
                }

                return result  + new string(' ', ColumnSpan);
            }
        }


        public bool Change
        {
            protected set
            {
                change = value;
            }

            get
            {
                return change;
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
        }

        public void DeleteContent()
        {
            Content = DeletePattern;
        }       
    }
}
