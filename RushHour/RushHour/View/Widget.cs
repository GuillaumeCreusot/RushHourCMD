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

        public Widget Master { get; private set; }
        public string Name { get; private set; }

        public string Content
        {
            get
            {
                return "Content";
            }
        }
    }
}
