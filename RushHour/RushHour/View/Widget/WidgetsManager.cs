using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    /// <summary>
    /// Widget wich manages the display of the widgets on screen
    /// </summary>
    class WidgetsManager : Widget
    {
        private List<Widget> widgets;
        private List<WidgetsManager> subWidgetsManager;
        private string[,] grid;
        private bool superposition;

        /// <summary>
        /// names of all widgets which are contained in this manager
        /// </summary>
        public string[] WidgetNames
        {
            get
            {
                string[] result = new string[widgets.Count];

                for(int i = 0; i < widgets.Count; i++)
                {
                    result[i] = widgets[i].Name;
                }

                return result;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">widget's name</param>
        /// <param name="nbCol">number of columns</param>
        /// <param name="nbRow">number of rows</param>
        public WidgetsManager(string name, int nbCol, int nbRow, bool isMain = true, bool superposition = true) : base(name, nbRow, nbCol)
        {
            //cursor invisible
            Console.CursorVisible = false;

            widgets = new List<Widget>();
            subWidgetsManager = new List<WidgetsManager>();
            grid = new string[nbRow, nbCol];
            this.superposition = superposition;

            if (isMain)
            {
                Console.WindowWidth = nbCol;
                Console.WindowHeight = nbRow;
            }
        }

        /// <summary>
        /// Add widget <paramref name="widget"/> to widget manager 
        /// in row <paramref name="row"/> and in column <paramref name="col"/>
        /// </summary>
        /// <param name="widget">widget to add</param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void AddWidget(Widget widget, int row, int col)
        {
            //check error
            if (row + widget.RowSpanMax > grid.GetLength(0))
            {
                throw new Exception("Le Widget sort de la console (rang)");
            }
            if(col + widget.ColumnSpanMax > grid.GetLength(1))
            {
                throw new Exception("Le Widget sort de la console (col)");
            }

            if (!superposition)
            {
                // position
            if (grid[row, col] == null)
                {
                    grid[row, col] = widget.Name;
                    widget.Position = new int[] { row, col };
                }
                else
                {
                    throw new Exception("le Widget est superposé à un autre");
                }

                //span
                for (int i = 0; i < widget.RowSpanMax; i++)
                {
                    for (int j = 0; j < widget.ColumnSpanMax; j++)
                    {
                        grid[row + i, col + j] = widget.Name;
                    }
                }
            }
            else
            {
                widget.Position = new int[] { row, col };
            }
            //add the widget to the list widget
            widgets.Add(widget);
            widget.Master = this;
        }

        /// <summary>
        /// Add a sub widget manager to this widget manager
        /// </summary>
        /// <param name="wm"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void AddWidgetsManager(WidgetsManager wm, int row, int col)
        {
            AddWidget(wm, row, col);
            subWidgetsManager.Add(wm);
        }

        /// <summary>
        /// refresh all widgets on screen
        /// </summary>
        public virtual void RefreshContentOnScreen(bool delete = false)
        {
            RefreshContentOnScreen(this.WidgetNames, delete);
        }

        /// <summary>
        /// refresh all widgets on screen wich are contained in <paramref name="contentNames"/>
        /// </summary>
        /// <param name="contentNames"></param>
        public virtual void RefreshContentOnScreen(string[] contentNames, bool delete = false)
        {
            Widget currentW;
            
            foreach(string name in contentNames)
            {
                //get widgets instance
                currentW = FindWidgetWithName(name);
                if(currentW == null)
                {
                    throw new Exception($"le Widget {name} n'existe pas");
                }
                else
                {
                    //draw character by character
                    for(int i = 0 ; i < currentW.RowSpan; i++)
                    {
                        for(int j = 0; j < currentW.ColumnSpan; j++)
                        {
                            //position cursor
                             Console.CursorLeft = currentW.Position[1] + j + Position[1];
                             Console.CursorTop = currentW.Position[0] + i + Position[0];

                            //color
                             Console.ForegroundColor = currentW.ColorPattern[i, j];      
                            
                            //handle transparent character '\u0000'                    
                             if(currentW.Content[j + i * (currentW.ColumnSpan + 1)] != '\u0000')
                                Console.Write(currentW.Content[j + i * (currentW.ColumnSpan + 1)]);
                        }
                    }
                }
            }

            Console.CursorLeft = 0;
            Console.CursorTop = 0;
        }

        /// <summary>
        /// Refresh content of the widget <paramref name="name"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="delete"></param>
        public void RefreshContentOnScreen(string name, bool delete = false)
        {
            RefreshContentOnScreen(new string[] { name }, delete);
        }

        /// <summary>
        /// find a widget instance named <paramref name="name"/>
        /// </summary>
        /// <param name="name"></param>
        /// <returns>returns null if the widget doesn't exist</returns>
        public Widget FindWidgetWithName(string name)
        {
            int c = 0;
            while((c < widgets.Count && widgets[c].Name != name) || c == widgets.Count)
            {
                c++;
            }

            if(c < widgets.Count)
            {
                return widgets[c];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// find sub widgetmanger instance with <paramref name="name"/>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public WidgetsManager FindSubWidgetManagerWithName(string name)
        {
            int c = 0;
            while ((c < subWidgetsManager.Count && subWidgetsManager[c].Name != name) || c == subWidgetsManager.Count)
            {
                c++;
            }

            if (c < subWidgetsManager.Count)
            {
                return subWidgetsManager[c];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// delete  widget <paramref name="name"/> on the screen
        /// </summary>
        /// <param name="name"></param>
        public void DeleteWidgetOnScreen(string name)
        {
            Widget w = FindWidgetWithName(name);
            if(w != null)
            {
                w.DeleteContent();
                RefreshContentOnScreen(name, true);
            }
            else
            {
                throw new Exception($"Le widget avec le nom {name} n'existe pas");
            }
        }
    }
}
