namespace AssemblerToBinary
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBoxAssembler = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonLoadFile = new System.Windows.Forms.Button();
            this.listBoxMachineCode = new System.Windows.Forms.ListBox();
            this.listBoxSymbolTable = new System.Windows.Forms.ListBox();
            this.buttonMachineCode = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelAssembler = new System.Windows.Forms.Label();
            this.labelMachineCode = new System.Windows.Forms.Label();
            this.labelSymbolTable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxAssembler
            // 
            this.listBoxAssembler.FormattingEnabled = true;
            this.listBoxAssembler.ItemHeight = 16;
            this.listBoxAssembler.Location = new System.Drawing.Point(16, 42);
            this.listBoxAssembler.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxAssembler.Name = "listBoxAssembler";
            this.listBoxAssembler.Size = new System.Drawing.Size(235, 484);
            this.listBoxAssembler.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "asm";
            this.openFileDialog1.FileName = "*.asm";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.Location = new System.Drawing.Point(16, 534);
            this.buttonLoadFile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(235, 28);
            this.buttonLoadFile.TabIndex = 2;
            this.buttonLoadFile.Text = "Load File";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // listBoxMachineCode
            // 
            this.listBoxMachineCode.FormattingEnabled = true;
            this.listBoxMachineCode.ItemHeight = 16;
            this.listBoxMachineCode.Location = new System.Drawing.Point(287, 42);
            this.listBoxMachineCode.Name = "listBoxMachineCode";
            this.listBoxMachineCode.Size = new System.Drawing.Size(235, 484);
            this.listBoxMachineCode.TabIndex = 3;
            // 
            // listBoxSymbolTable
            // 
            this.listBoxSymbolTable.FormattingEnabled = true;
            this.listBoxSymbolTable.ItemHeight = 16;
            this.listBoxSymbolTable.Location = new System.Drawing.Point(558, 42);
            this.listBoxSymbolTable.Name = "listBoxSymbolTable";
            this.listBoxSymbolTable.Size = new System.Drawing.Size(235, 484);
            this.listBoxSymbolTable.TabIndex = 4;
            // 
            // buttonMachineCode
            // 
            this.buttonMachineCode.Location = new System.Drawing.Point(287, 534);
            this.buttonMachineCode.Name = "buttonMachineCode";
            this.buttonMachineCode.Size = new System.Drawing.Size(235, 28);
            this.buttonMachineCode.TabIndex = 5;
            this.buttonMachineCode.Text = "Generate Machine Code";
            this.buttonMachineCode.UseVisualStyleBackColor = true;
            this.buttonMachineCode.Click += new System.EventHandler(this.buttonMachineCode_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelAssembler
            // 
            this.labelAssembler.AutoSize = true;
            this.labelAssembler.Location = new System.Drawing.Point(13, 21);
            this.labelAssembler.Name = "labelAssembler";
            this.labelAssembler.Size = new System.Drawing.Size(113, 17);
            this.labelAssembler.TabIndex = 6;
            this.labelAssembler.Text = "Hack assembler:";
            // 
            // labelMachineCode
            // 
            this.labelMachineCode.AutoSize = true;
            this.labelMachineCode.Location = new System.Drawing.Point(284, 21);
            this.labelMachineCode.Name = "labelMachineCode";
            this.labelMachineCode.Size = new System.Drawing.Size(100, 17);
            this.labelMachineCode.TabIndex = 7;
            this.labelMachineCode.Text = "Machine code:";
            // 
            // labelSymbolTable
            // 
            this.labelSymbolTable.AutoSize = true;
            this.labelSymbolTable.Location = new System.Drawing.Point(555, 21);
            this.labelSymbolTable.Name = "labelSymbolTable";
            this.labelSymbolTable.Size = new System.Drawing.Size(93, 17);
            this.labelSymbolTable.TabIndex = 8;
            this.labelSymbolTable.Text = "Symbol table:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 574);
            this.Controls.Add(this.labelSymbolTable);
            this.Controls.Add(this.labelMachineCode);
            this.Controls.Add(this.labelAssembler);
            this.Controls.Add(this.buttonMachineCode);
            this.Controls.Add(this.listBoxSymbolTable);
            this.Controls.Add(this.listBoxMachineCode);
            this.Controls.Add(this.buttonLoadFile);
            this.Controls.Add(this.listBoxAssembler);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "HACK assembler to machine code";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxAssembler;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonLoadFile;
        private System.Windows.Forms.ListBox listBoxMachineCode;
        private System.Windows.Forms.ListBox listBoxSymbolTable;
        private System.Windows.Forms.Button buttonMachineCode;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelAssembler;
        private System.Windows.Forms.Label labelMachineCode;
        private System.Windows.Forms.Label labelSymbolTable;
    }
}

