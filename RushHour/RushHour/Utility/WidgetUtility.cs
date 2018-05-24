using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    public static class WidgetUtility
    {
        /// <summary>
        /// Gets the size of a given content
        /// </summary>
        public static int[] DimContent(string content)
        {
            string[] cols = content.Split('\n');
            int nbColMax = 0;
            foreach (string col in cols)
            {
                if (col.Length > nbColMax)
                {
                    nbColMax = col.Length;
                }
            }

            return new int[] { cols.Length, nbColMax };
        }

        /// <summary>
        /// resizes the content to the wanted dimension
        /// </summary>
        public static string Resize(string content, int nbCol)
        {
            string result = "";

            string[] cols = content.Split('\n');

            //remove excess
            for (int i = 0; i < cols.Length; i++)
            {
                if(cols[i].Length >= nbCol)
                {
                    cols[i] = cols[i].Substring(0, nbCol);
                }
            }

            //add spaces
            for (int i = 0; i < cols.Length; i++)
            {
                cols[i] += new string(' ', nbCol - cols[i].Length);
                result += cols[i] + "\n";
            }

            return result.Substring(0, result.Length-1);
        }

        /// <summary>
        /// repeats a char multiple times
        /// </summary>
        public static string Repeat(char car, int nb)
        {
            return new string(car, nb);
        } 
    }
}
