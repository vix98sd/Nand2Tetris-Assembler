using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AssemblerCodeBusiness
    {
        // Metoda koja uzima citav sadrzaj fajla iz DataLayera

        public List<string> GetCode(string path)
        {
            AssemblerCodeRepository assemblerCodeRepository = new AssemblerCodeRepository();
            return assemblerCodeRepository.GetCode(path);
        }

        // Metoda uklanja komentare i prazne redove iz koda,
        // i ostavlja samo assembler, tj 'clean code'
        public List<string> GetCleanCode(string path)
        {
            List<string> code = GetCode(path);

            for (int i = 0; i < code.Count; i++)
            {
                if (code[i].Contains("//")){
                    string[] parts = code[i].Split('/');
                    code[i] = parts[0];
                }
                if (code[i].Equals(""))
                    code.RemoveAt(i--);

                if (string.IsNullOrWhiteSpace(code[i]))
                    code.RemoveAt(i--);
            }

            return code;
        }


        // Metoda koja vraca kod bez belih znakova
        public List<string> GetTrimmedCode(List<string> code)
        {
            for (int i = 0; i < code.Count; i++)
                code[i] = code[i].Replace(" ", String.Empty);

            return code;
        }
    }
}
