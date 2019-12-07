using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AssemblerCodeRepository
    {
        // Metoda koja vrsi citanje svih redova unutar izabranog fajla
        // a zatim vraca procitani kod
        public List<string> GetCode(string path)
        {
            List<string> code = new List<string>();

            using (StreamReader file = new StreamReader(path))
            {
                string codeLine;
                while ((codeLine = file.ReadLine()) != null)
                {
                    code.Add(codeLine);
                }
            }

            return code;
        }

    }
}
