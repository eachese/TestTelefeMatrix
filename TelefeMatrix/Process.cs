using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefeMatrix
{
    public class Process
    {
        string[] secuencias = { "AGVNFT", "XJILSB", "CHAOHD", "ERCVTQ", "ASOYAO", "ERMYUA", "TELEFE" };

        public Process()
        {

            var words = new FindWord(secuencias);

            ShowResult(words.Find("JAVA"));
            ShowResult(words.Find("VIACOM"));
            ShowResult(words.Find("TELEFE"));

        }
        public void ShowResult(List<List<int>> results)
        {
            if (results.Count > 0)
            {
                results.Reverse();
                foreach (var c in results)
                {
                    Console.WriteLine("[" + c[0] + "," + c[1] + "]");
                }
            }
            else
            {
                Console.WriteLine("Search not found");
            }
            Console.ReadLine();

        }

       
    }
}

