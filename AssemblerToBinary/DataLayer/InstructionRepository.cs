using DataLayer.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class InstructionRepository
    {
        public List<Instruction> GetAllInstructions(string fileName)
        {
            // Vrsi se kreiranje putanje do fajla u kome se nalaze sve
            // instrukcije zajedno sa njihovim binarnim reprezentima
            // Format upisa je INSTR;REPRESENT

            List<Instruction> instructions = new List<Instruction>();
            string path = System.IO.Directory.GetCurrentDirectory();
            path = System.IO.Directory.GetParent(path).ToString();
            path = System.IO.Directory.GetParent(path).ToString();
            path = System.IO.Directory.GetParent(path).ToString();
            path += @"\DataLayer\" + fileName;

            // Citanje instrukcija iz fajla

            using (StreamReader file = new StreamReader(path)){
                string name;
                while ((name = file.ReadLine()) != null)
                {
                    Instruction instruction = new Instruction();
                    string[] parts = name.Split(';');
                    instruction.Name = parts[0];
                    instruction.BinaryRepresent = parts[1];
                    instructions.Add(instruction);
                }
            }

            return instructions;
        }
    }
}
