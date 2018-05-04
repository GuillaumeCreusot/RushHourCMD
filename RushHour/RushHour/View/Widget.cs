using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class Widget
    {
        private Widget master;
        private string name;
        private int[] span;
        private string content = "";
        private int[] position;

        public Widget Master { get; private set; }
        public string Name { get; private set; }
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

        public string Content
        {
            get
            {
                return content;
            }
            protected set
            {
                content = value;

                //span
                int nbCol = 0;
                while (nbCol < value.Length && value[nbCol] != '\n')
                {
                    nbCol++;
                }
                ColumnSpan = nbCol;
                RowSpan = value.Length / (ColumnSpan + 1);
            }
        }

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

        public Widget(string name)
        {
            span = new int[2];
            position = new int[2];
            Name = name;

            //Debug
            Content = "Content";
        }
    }
}
