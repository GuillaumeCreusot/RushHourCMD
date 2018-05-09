using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    public static class WidgetUtility
    {
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

        public static string Resize(string content, int nbCol)
        {
            string result = "";

            string[] cols = content.Split('\n');

            //enleve le surplus
            for (int i = 0; i < cols.Length; i++)
            {
                if(cols[i].Length >= nbCol)
                {
                    cols[i] = cols[i].Substring(0, nbCol);
                }
            }

            //ajoute des especes
            for (int i = 0; i < cols.Length; i++)
            {
                cols[i] += new string(' ', nbCol - cols[i].Length);
                result += cols[i] + "\n";
            }

            return result.Substring(0, result.Length-1);
        }
    }
}
