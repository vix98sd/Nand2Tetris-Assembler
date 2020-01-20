using DataLayer.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SymbolRepository
    {
        // Metoda cita iz fajla simbole koji su vec ugradjeni u HACK assembler
        public List<Symbol> GetBuiltInSymbols()
        {
            List<Symbol> builtInSymbols = new List<Symbol>();

            string path = System.IO.Directory.GetCurrentDirectory();
            path = System.IO.Directory.GetParent(path).ToString();
            path = System.IO.Directory.GetParent(path).ToString();
            path = System.IO.Directory.GetParent(path).ToString();
            path += @"\DataLayer\symbols.txt";

            string line;
            using (StreamReader file = new StreamReader(path))
            {
                while((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    Symbol symbol = new Symbol();
                    symbol.Name = parts[0];
                    symbol.Address = Convert.ToInt16(parts[1]);
                    builtInSymbols.Add(symbol);
                }
            }

                return builtInSymbols;
        }
    }
}
