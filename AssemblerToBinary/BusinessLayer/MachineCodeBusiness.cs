using DataLayer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MachineCodeBusiness
    {
        // Metoda vraca masinski kod unetog assembler koda
        public List<string> GetMachineCode(List<string> code)
        {
            List<string> machineCode = new List<string>();

            SymbolBusiness symbolBusiness = new SymbolBusiness();
            List<Symbol> symbolTable = symbolBusiness.GetSymbolTable(code);

            InstructionBusiness instructionBusiness = new InstructionBusiness();
            List<Instruction> commands = instructionBusiness.GetAllInstructions("commands.txt");
            List<Instruction> destination = instructionBusiness.GetAllInstructions("destination.txt");
            List<Instruction> jumps = instructionBusiness.GetAllInstructions("jumps.txt");

            foreach (string line in code)
                if (IsTypeA(line))
                    machineCode.Add(HandleTypeA(line, symbolTable));
                else if (line[0] == '(') continue;
                else
                    machineCode.Add(HandleTypeC(line, commands, destination, jumps));


            return machineCode;
        }

        // Metoda proverava da li je instrukcija tipa A
        private bool IsTypeA(string line) => line[0] == '@' ? true : false;

        // Metoda koja vrsi prevodjenje instrukcije
        // tipa A u njen binarni reprezent
        private string HandleTypeA(string line, List<Symbol> symbolTable)
        {
            string machineCode = "";
            line = line.Replace("@", String.Empty);
            if (int.TryParse(line, out int n))
                machineCode = Convert.ToString(n, 2);
            else
            {
                foreach (Symbol symbol in symbolTable)
                    if(symbol.Name == line)
                    {
                        machineCode = Convert.ToString(symbol.Address, 2);
                        break;
                    }
            }

            string zeros = "0";
            for (int i = 0; i < (15 - machineCode.Length); i++)
                zeros += '0';
            return zeros + machineCode;
        }

        // Metoda koja vrsi prevodjenje instrukcije
        // tipa C u njen binarni reprezent
        private string HandleTypeC(string line, List<Instruction> commands, List<Instruction> destinations, List<Instruction> jumps)
        {
            string machineCode = "111";
            
            if (line.Contains("="))
            {
            string[] parts = line.Split('=');
                machineCode += ABit(parts[1]) 
                            + CompBits(parts[1], commands)
                            + DestBits(parts[0], destinations)
                            + JumpBits(parts[1], jumps);
            }
            else
            {
                string[] parts = line.Split(';');
                machineCode += ABit(parts[0])
                            + CompBits(parts[0], commands)
                            + DestBits(parts[1], destinations)
                            + JumpBits(parts[1], jumps);
            }

            return machineCode;
        }

        // Instrukcija koja postavnja vrednost 
        // A bita u instrukciji tipa C
        private string ABit(string line)
        {
            if (line.Contains("M"))
                return "1";

            return "0";
        }

        // Instrukcija koja postavnja vrednost 
        // COMP bitova u instrukciji tipa C
        private string CompBits(string line, List<Instruction> commands)
        {
            foreach (Instruction command in commands)
                if (line == command.Name)
                    return command.BinaryRepresent;

            return "CompBitsError";
        }

        // Instrukcija koja postavnja vrednost 
        // DEST bitova u instrukciji tipa C
        private string DestBits(string line, List<Instruction> destinations)
        {
            foreach (Instruction destination in destinations)
                if (line == destination.Name)
                    return destination.BinaryRepresent;
            return "000";
        }

        // Instrukcija koja postavnja vrednost 
        // JUMP bitova u instrukciji tipa C
        private string JumpBits(string line, List<Instruction> jumps)
        {
            foreach (Instruction jump in jumps)
                if (line == jump.Name)
                    return jump.BinaryRepresent;
            return "000";
        }
    }
}
