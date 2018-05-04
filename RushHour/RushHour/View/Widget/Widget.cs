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
        private string content = "";
        private int[] position;

        /// <summary>
        /// Nom du widget
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// WidgetManager dans lequel ce widget est inclus
        /// </summary>
        public WidgetsManager Master { get; protected set; }

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
        /// Contenue du widget 
        /// </summary>
        public string Content
        {
            get
            {
                return content;
            }
            protected set
            {
                content = "";

                //span
                string[] cols = value.Split('\n');
                int nbColMax = 0;
                foreach(string col in cols)
                {
                    if(col.Length > nbColMax)
                    {
                        nbColMax = col.Length;
                    }
                }
                ColumnSpan = nbColMax;
                RowSpan = value.Length / (ColumnSpan + 1);

                //ligne meme nombre d element
                for(int i = 0; i < cols.Length; i++)
                {
                    cols[i] += new string(' ', nbColMax - cols[i].Length);
                    content += cols[i] + "\n";
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
                for (int i = 0; i < RowSpan; i++)
                {
                    result += new string(' ', ColumnSpan) + "\n";
                }

                return result  + new string(' ', ColumnSpan);
            }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="name">nom du widget</param>
        public Widget(string name)
        {
            span = new int[2];
            position = new int[2];
            Name = name;
        }

        public void DeleteContent()
        {
            Content = DeletePattern;
        }
    }
}
