using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class WidgetsManager : Widget
    {
        private List<Widget> widgets;
        private List<WidgetsManager> subWidgetsManager;
        private string[,] grid;
        private bool superposition;

        /// <summary>
        /// Les noms des widgets contenus dans le widgetManager
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
        /// Constructeur
        /// </summary>
        /// <param name="name">Nom du Widget</param>
        /// <param name="nbCol">nombre de colonne</param>
        /// <param name="nbRow">nombre de rang</param>
        public WidgetsManager(string name, int nbCol, int nbRow, bool isMain = true, bool superposition = true) : base(name, nbRow, nbCol)
        {
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
        /// Ajouter du widget <paramref name="widget"/> au widget manager 
        /// au rang <paramref name="row"/> et la colonne <paramref name="col"/>
        /// </summary>
        /// <param name="widget">widget à ajouter</param>
        /// <param name="row">rang ou mettre le widget</param>
        /// <param name="col">colonne ou mettre le widget</param>
        public void AddWidget(Widget widget, int row, int col)
        {
            //vérification erreur
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
            //ajout de l'objet widget à widgets
            widgets.Add(widget);
            widget.Master = this;
        }

        public void AddWidgetsManager(WidgetsManager wm, int row, int col)
        {
            AddWidget(wm, row, col);
            subWidgetsManager.Add(wm);
        }

        /// <summary>
        /// Rafraichi tous les widgets
        /// </summary>
        public virtual void RefreshContentOnScreen(bool delete = false)
        {
            RefreshContentOnScreen(this.WidgetNames, delete);
        }

        /// <summary>
        /// Rafraichit les widgets dont le nom est compris dans <paramref name="contentNames"/>
        /// </summary>
        /// <param name="contentNames">noms des widgets à rafraichir</param>
        public virtual void RefreshContentOnScreen(string[] contentNames, bool delete = false)
        {
            Widget currentW;

            foreach(string name in contentNames)
            {
                currentW = FindWidgetWithName(name);
                if(currentW == null)
                {
                    throw new Exception($"le Widget {name} n'existe pas");
                }
                else
                {
                    for(int i = 0 ; i < currentW.RowSpan; i++)
                    {
                        for(int j = 0; j < currentW.ColumnSpan; j++)
                        {
                             Console.CursorLeft = currentW.Position[1] + j + Position[1];
                             Console.CursorTop = currentW.Position[0] + i + Position[0];
                             Console.ForegroundColor = currentW.ColorPattern[i, j];                          
                             if(currentW.Content[j + i * (currentW.ColumnSpan + 1)] != '\u0000')
                                Console.Write(currentW.Content[j + i * (currentW.ColumnSpan + 1)]);
                        }
                    }
                }
            }

            Console.CursorLeft = 0;
            Console.CursorTop = 0;
        }

        public void RefreshContentOnScreen(string name, bool delete = false)
        {
            RefreshContentOnScreen(new string[] { name }, delete);
        }

        /// <summary>
        /// Trouver un widget à l'aide de son nom <paramref name="name"/>
        /// </summary>
        /// <param name="name">nom du widget cherché</param>
        /// <returns>widget cherché ou null si le widget n'existe pas</returns>
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
