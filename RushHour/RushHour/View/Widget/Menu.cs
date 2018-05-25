using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    /// <summary>
    /// Widget used to show a menu
    /// </summary>
    class Menu : Widget
    {      
        

        /// <summary>
        /// list of items in menu
        /// </summary>
        private string[] items;

        /// <summary>
        /// selector's position on console
        /// </summary>
        private int[,] positionSelecter;

        /// <summary>
        /// selected item in menu
        /// </summary>
        private int selectedItem;
        public int SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if(value >= 0 && value < NbItem)
                {
                    selectedItem = value;
                    UpdateSelecter();
                    Master.RefreshContentOnScreen(this.Name);
                }
            }
        }

        /// <summary>
        /// Number of items in menu
        /// </summary>
        public int NbItem
        {
            get
            {
                return items.Length;
            }
        }

        /// <summary>
        /// permanent text above menu
        /// </summary>
        protected string PermanentText
        {
            set
            {
                Content = value;

                int[] dim = WidgetUtility.DimContent(value);
                
                for(int i = 0; i < NbItem; i++)
                {
                    Content += $"\n{WidgetUtility.Repeat(' ', MargeLeft)}  {items[i]}";
                    positionSelecter[i, 0] = dim[0];
                    positionSelecter[i, 1] = MargeLeft;   
                    dim[0] += 1;
                }

                UpdateSelecter();


            }
        }

        /// <summary>
        /// margin on the console's left side
        /// </summary>
        private int margeLeft;
        public int MargeLeft
        {
            get
            {
                return margeLeft;
            }

            protected set
            {
                margeLeft = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">widget's name</param>
        /// <param name="permanentText">permanent text in menu</param>
        /// <param name="rowSpanMax">maximum number of rows</param>
        /// <param name="columnSpanMax">maximum number of columns</param>
        /// <param name="items">items in menu</param>
        /// <param name="selectedItem">selected item (default = 0)/param>
        /// <param name="margeLeft">margin on the left</param>
        public Menu(string name, string permanentText, int rowSpanMax, int columnSpanMax, string[] items, int selectedItem = 0, int margeLeft = 0) : base(name, rowSpanMax, columnSpanMax)
        {
            this.items = items;
            positionSelecter = new int[NbItem, 2];

            MargeLeft = margeLeft;
            PermanentText = permanentText;
            this.selectedItem = selectedItem;
        }

        /// <summary>
        /// move selector
        /// </summary>
        public void UpdateSelecter()
        {
            for(int i = 0; i < NbItem; i++)
            {
                if(selectedItem == i)
                {
                    string transition = Content.Remove(positionSelecter[i, 1] + positionSelecter[i, 0] * (ColumnSpan + 1), 1);
                    Content = transition.Insert(positionSelecter[i, 1] + positionSelecter[i, 0] * (ColumnSpan + 1), ">");
                }
                else
                {
                    string transition = Content.Remove(positionSelecter[i, 1] + positionSelecter[i, 0] * (ColumnSpan + 1), 1);
                    Content = transition.Insert(positionSelecter[i, 1] + positionSelecter[i, 0] * (ColumnSpan + 1), " ");
                }
            }
        }
    }
}
