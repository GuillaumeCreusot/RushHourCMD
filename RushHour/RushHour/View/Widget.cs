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
                return "Content";
            }
        }

        public Widget(string name)
        {
            span = new int[2];
            Name = name;
        }
    }
}
