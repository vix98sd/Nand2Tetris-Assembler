using BusinessLayer;
using DataLayer.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssemblerToBinary
{
    public partial class Form1 : Form
    {
        List<string> code;
        List<string> machineCode;
        int index;
        int numberOfLabels;

        public Form1()
        {
            InitializeComponent();
            machineCode = new List<string>();
            code = new List<string>();
            index = 0;
            numberOfLabels = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            listBoxAssembler.Items.Clear();
            listBoxMachineCode.Items.Clear();
            listBoxSymbolTable.Items.Clear();
            index = 0;
            numberOfLabels = 0;

            string path = openFileDialog1.FileName;
            AssemblerCodeBusiness assemblerCodeBusiness = new AssemblerCodeBusiness();
            code = assemblerCodeBusiness.GetCleanCode(path);

            SymbolBusiness symbolBusiness = new SymbolBusiness();
            List<Symbol> symbolTable = symbolBusiness.GetSymbolTable(code);

            int numOfLabels = 0;
            foreach (string codeLine in code)
            {
                if(codeLine[0] != '(')
                    listBoxAssembler.Items.Add(listBoxAssembler.Items.Count + 1 - numOfLabels + "\t" + codeLine);
                else
                {
                    listBoxAssembler.Items.Add("    " + codeLine);
                    numOfLabels++;
                }

            }

            foreach (Symbol s in symbolTable)
                listBoxSymbolTable.Items.Add(listBoxSymbolTable.Items.Count + 1 + "\t" + s.Name + "\t" + s.Address);

            MachineCodeBusiness machineCodeBusiness = new MachineCodeBusiness();
            machineCode = machineCodeBusiness.GetMachineCode(assemblerCodeBusiness.GetTrimmedCode(code));

        }

        private void buttonMachineCode_Click(object sender, EventArgs e)
        {
            listBoxMachineCode.Items.Clear();
            index = 0;
            numberOfLabels = 0;

            if (code.Count == 0)
                return;

            listBoxMachineCode.Items.Clear();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBoxAssembler.SetSelected(index, true);
            if (code[index++][0] == '(')
            {
                numberOfLabels++;
                listBoxMachineCode.SetSelected(index - numberOfLabels - 1, false);
                return;
            }

            listBoxMachineCode.Items.Add(listBoxMachineCode.Items.Count + 1 + "\t" + machineCode[index - numberOfLabels -1]);
            listBoxMachineCode.SetSelected(listBoxMachineCode.Items.Count - 1, true);

            if (listBoxMachineCode.Items.Count == (listBoxAssembler.Items.Count - numberOfLabels))
                timer1.Stop();
        }
    }
}
