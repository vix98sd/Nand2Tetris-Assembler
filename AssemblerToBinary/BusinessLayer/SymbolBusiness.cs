using DataLayer;
using DataLayer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class SymbolBusiness
    {
        // Metoda koja vraca simbole ugradjene u sam jezik
        public List<Symbol> GetBuitInSymbols()
        {
            SymbolRepository symbolRepository = new SymbolRepository();
            List<Symbol> builtInSymbols = symbolRepository.GetBuiltInSymbols();

            return builtInSymbols;
        }

        // Metoda vraca tabelu sa simbolima koji su ugradjeni 
        // u sam jezik i koji su dodati putem koda
        public List<Symbol> GetSymbolTable(List<string> code)
        {
            AssemblerCodeBusiness assemblerCodeBusiness = new AssemblerCodeBusiness();
            code = assemblerCodeBusiness.GetTrimmedCode(code);
            List<Symbol> symbolTable = AddLabels(code);
            symbolTable = AddVariables(code, symbolTable);

            return symbolTable;
        }

        // Metoda vrsi dodavanje labela u tabelu simbola
        private List<Symbol> AddLabels(List<string> code)
        {
            List<Symbol> symbolTable = GetBuitInSymbols();
            AssemblerCodeBusiness assemblerCodeBusiness = new AssemblerCodeBusiness();

            int numberOfLabels = 0;
            for (int i = 0; i < code.Count; i++)
            {
                if (code[i].Contains('('))
                {
                    string label = code[i].Replace("(", String.Empty);
                    label = label.Replace(")", String.Empty);

                    bool doesExsists = false;
                    foreach (Symbol s in symbolTable)
                        if (s.Name.Equals(label))
                        {
                            doesExsists = true;
                            break;
                        }

                    if (!doesExsists)
                    {
                        Symbol symbol = new Symbol();
                        symbol.Name = label;
                        symbol.Address = i + 1 - numberOfLabels;

                        symbolTable.Add(symbol);
                        numberOfLabels++;
                    }

                }
            }
            return symbolTable;
        }

        // Metoda vrsi dodavanje varijabli u tabelu simbola
        private List<Symbol> AddVariables(List<string> code, List<Symbol> symbolTable)
        {
            int numberOfVars = 0;
            foreach (string line in code)
            {
                if (line.Contains('@'))
                {
                    string variable = line.Replace("@", String.Empty);

                    if (!int.TryParse(variable, out int n))
                    {
                        bool doesExsists = false;
                        foreach (Symbol s in symbolTable)
                            if (s.Name.Equals(variable))
                            {
                                doesExsists = true;
                                break;
                            }
                        if (!doesExsists)
                        {
                            Symbol symbol = new Symbol();
                            symbol.Name = variable;
                            symbol.Address = 16 + numberOfVars;

                            symbolTable.Add(symbol);
                            numberOfVars++;
                        }
                    }

                }
            }

            return symbolTable;
        }

        // Metoda vrsi sortiranje tabele simbola po vrednosti adrese
        private List<Symbol> SortTable(List<Symbol> symbolTable)
        {
            for(int i = 0; i < symbolTable.Count - 1; i++)
                for(int j = i; j < symbolTable.Count; j++)
                    if(symbolTable[i].Address > symbolTable[j].Address)
                    {
                        Symbol tmp = symbolTable[i];
                        symbolTable[i] = symbolTable[j];
                        symbolTable[j] = tmp; 
                    }

            return symbolTable;
        }
    }
}
