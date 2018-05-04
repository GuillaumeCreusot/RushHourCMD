using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.View
{
    class Widget
    {
        private Widget master;
        private string name;

        public Widget Master { get => master; private set => master = value; }
        public string Name { get => name; private set => name = value; }

        public string Content
        {
            get
            {
                return "Content";
            }
        }
    }
}
