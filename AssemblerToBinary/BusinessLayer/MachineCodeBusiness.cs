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
        // A method that returns instruction in machine language 
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

        // A methot that check if instruction is an A type
        private bool IsTypeA(string line) => line[0] == '@' ? true : false;

        // A method that translates type A
        // instruction in machine language
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

        // A method that translates type C
        // instruction in machine language
        private string HandleTypeC(string line, List<Instruction> commands, List<Instruction> destinations, List<Instruction> jumps)
        {
            string machineCode = "111";
            
            if (line.Contains("=") && line.Contains(";"))
            {
                // C instruction with DEST=COMP;JMP format

                string dest = line.Split('=')[0];
                string comp = line.Split('=')[1].Split(';')[0];
                string jmp = line.Split('=')[1].Split(';')[1];

                machineCode += ABit(comp)
                            + CompBits(comp, commands)
                            + DestBits(dest, destinations)
                            + JumpBits(jmp, jumps);
            }
            else if (line.Contains("="))
            {
                // C instruction with DEST=COMP format

                string[] parts = line.Split('=');

                machineCode += ABit(parts[1]) 
                            + CompBits(parts[1], commands)
                            + DestBits(parts[0], destinations)
                            + JumpBits(parts[1], jumps);
            }
            else if (line.Contains(";"))
            {
                // C instruction with COMP;JMP format

                string[] parts = line.Split(';');

                machineCode += ABit(parts[0])
                            + CompBits(parts[0], commands)
                            + DestBits(parts[1], destinations)
                            + JumpBits(parts[1], jumps);
            }
            else
            {
                // C instruction with COMP format

                machineCode += ABit(line)
                            + CompBits(line, commands)
                            + DestBits(line, destinations)
                            + JumpBits(line, jumps);
            }

            return machineCode;
        }

        // A method that sets A bit
        // in C type instruction
        private string ABit(string line)
        {
            if (line.Contains("M"))
                return "1";

            return "0";
        }

        // A method that sets COMP bits
        // in C type instruction
        private string CompBits(string line, List<Instruction> commands)
        {
            foreach (Instruction command in commands)
                if (line == command.Name)
                    return command.BinaryRepresent;

            return "CompBitsError";
        }

        // A method that sets DEST bits
        // in C type instruction
        private string DestBits(string line, List<Instruction> destinations)
        {
            foreach (Instruction destination in destinations)
                if (line == destination.Name)
                    return destination.BinaryRepresent;
            return "000";
        }

        // A method that sets JUMP bits
        // in C type instruction
        private string JumpBits(string line, List<Instruction> jumps)
        {
            foreach (Instruction jump in jumps)
                if (line == jump.Name)
                    return jump.BinaryRepresent;
            return "000";
        }
    }
}
