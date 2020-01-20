using DataLayer;
using DataLayer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class InstructionBusiness
    {
        // Metoda koja iz Data Layera povlaci listu svih instrukcija,
        // i zatom je prosledjuje dalje
        public List<Instruction> GetAllInstructions(string fileName)
        {
            InstructionRepository instructionRepository = new InstructionRepository();
            List<Instruction> instructions = new List<Instruction>();
            instructions = instructionRepository.GetAllInstructions(fileName);

            return instructions;
        }

    }
}
