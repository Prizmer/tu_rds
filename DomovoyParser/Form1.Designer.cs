namespace DomovoyParser
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.grBoxDump = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.openDirTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.инструментыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connPrmsTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.tsLblCurrentFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsLblTotalFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.grBoxBat = new System.Windows.Forms.GroupBox();
            this.btnExecAll = new System.Windows.Forms.Button();
            this.btnShowFile = new System.Windows.Forms.Button();
            this.numBatchFileNum = new System.Windows.Forms.NumericUpDown();
            this.btnExecFile = new System.Windows.Forms.Button();
            this.btnListOpenedFiles = new System.Windows.Forms.Button();
            this.geBoxComm = new System.Windows.Forms.GroupBox();
            this.timerProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numResponseTimeout = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.stopBtn = new System.Windows.Forms.Button();
            this.grBoxDump.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.grBoxBat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBatchFileNum)).BeginInit();
            this.geBoxComm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numResponseTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.Font = new System.Drawing.Font("Arial Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.Location = new System.Drawing.Point(12, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(664, 205);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.DoubleClick += new System.EventHandler(this.richTextBox1_DoubleClick);
            // 
            // grBoxDump
            // 
            this.grBoxDump.Controls.Add(this.button2);
            this.grBoxDump.Location = new System.Drawing.Point(206, 249);
            this.grBoxDump.Name = "grBoxDump";
            this.grBoxDump.Size = new System.Drawing.Size(241, 132);
            this.grBoxDump.TabIndex = 6;
            this.grBoxDump.TabStop = false;
            this.grBoxDump.Text = "Работа с дампом";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(6, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Последняя";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.инструментыToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(685, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTSMI,
            this.openDirTSMI});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            this.файлToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // openTSMI
            // 
            this.openTSMI.Name = "openTSMI";
            this.openTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openTSMI.Size = new System.Drawing.Size(261, 22);
            this.openTSMI.Text = "Открыть";
            this.openTSMI.Click += new System.EventHandler(this.openTSMI_Click);
            // 
            // openDirTSMI
            // 
            this.openDirTSMI.Enabled = false;
            this.openDirTSMI.Name = "openDirTSMI";
            this.openDirTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.openDirTSMI.Size = new System.Drawing.Size(261, 22);
            this.openDirTSMI.Text = "Выбрать дирректорию";
            this.openDirTSMI.Click += new System.EventHandler(this.openDirTSMI_Click);
            // 
            // инструментыToolStripMenuItem
            // 
            this.инструментыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connPrmsTSMI});
            this.инструментыToolStripMenuItem.Name = "инструментыToolStripMenuItem";
            this.инструментыToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.инструментыToolStripMenuItem.Text = "Инструменты";
            // 
            // connPrmsTSMI
            // 
            this.connPrmsTSMI.Name = "connPrmsTSMI";
            this.connPrmsTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.connPrmsTSMI.Size = new System.Drawing.Size(195, 22);
            this.connPrmsTSMI.Text = "Batch генератор";
            this.connPrmsTSMI.Click += new System.EventHandler(this.connPrmsTSMI_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.tsLblCurrentFile,
            this.toolStripStatusLabel2,
            this.tsLblTotalFiles});
            this.statusStrip1.Location = new System.Drawing.Point(0, 390);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(685, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(160, 16);
            // 
            // tsLblCurrentFile
            // 
            this.tsLblCurrentFile.Name = "tsLblCurrentFile";
            this.tsLblCurrentFile.Size = new System.Drawing.Size(13, 17);
            this.tsLblCurrentFile.Text = "0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(18, 17);
            this.toolStripStatusLabel2.Text = "из";
            // 
            // tsLblTotalFiles
            // 
            this.tsLblTotalFiles.Name = "tsLblTotalFiles";
            this.tsLblTotalFiles.Size = new System.Drawing.Size(13, 17);
            this.tsLblTotalFiles.Text = "0";
            // 
            // grBoxBat
            // 
            this.grBoxBat.Controls.Add(this.stopBtn);
            this.grBoxBat.Controls.Add(this.btnExecAll);
            this.grBoxBat.Controls.Add(this.btnShowFile);
            this.grBoxBat.Controls.Add(this.numBatchFileNum);
            this.grBoxBat.Controls.Add(this.btnExecFile);
            this.grBoxBat.Controls.Add(this.btnListOpenedFiles);
            this.grBoxBat.Location = new System.Drawing.Point(12, 249);
            this.grBoxBat.Name = "grBoxBat";
            this.grBoxBat.Size = new System.Drawing.Size(188, 132);
            this.grBoxBat.TabIndex = 12;
            this.grBoxBat.TabStop = false;
            this.grBoxBat.Text = "Работа с *.bat файлами";
            // 
            // btnExecAll
            // 
            this.btnExecAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecAll.Location = new System.Drawing.Point(6, 99);
            this.btnExecAll.Name = "btnExecAll";
            this.btnExecAll.Size = new System.Drawing.Size(107, 23);
            this.btnExecAll.TabIndex = 5;
            this.btnExecAll.Text = "Выполнить все";
            this.btnExecAll.UseVisualStyleBackColor = true;
            this.btnExecAll.Click += new System.EventHandler(this.btnExecAll_Click);
            // 
            // btnShowFile
            // 
            this.btnShowFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowFile.Location = new System.Drawing.Point(6, 45);
            this.btnShowFile.Name = "btnShowFile";
            this.btnShowFile.Size = new System.Drawing.Size(107, 23);
            this.btnShowFile.TabIndex = 4;
            this.btnShowFile.Text = "Вывести файл";
            this.btnShowFile.UseVisualStyleBackColor = true;
            this.btnShowFile.Click += new System.EventHandler(this.btnShowFile_Click);
            // 
            // numBatchFileNum
            // 
            this.numBatchFileNum.Location = new System.Drawing.Point(119, 59);
            this.numBatchFileNum.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numBatchFileNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBatchFileNum.Name = "numBatchFileNum";
            this.numBatchFileNum.Size = new System.Drawing.Size(55, 20);
            this.numBatchFileNum.TabIndex = 3;
            this.numBatchFileNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnExecFile
            // 
            this.btnExecFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecFile.Location = new System.Drawing.Point(6, 72);
            this.btnExecFile.Name = "btnExecFile";
            this.btnExecFile.Size = new System.Drawing.Size(107, 23);
            this.btnExecFile.TabIndex = 2;
            this.btnExecFile.Text = "Выполнить файл";
            this.btnExecFile.UseVisualStyleBackColor = true;
            this.btnExecFile.Click += new System.EventHandler(this.btnExecFile_Click);
            // 
            // btnListOpenedFiles
            // 
            this.btnListOpenedFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListOpenedFiles.Location = new System.Drawing.Point(6, 19);
            this.btnListOpenedFiles.Name = "btnListOpenedFiles";
            this.btnListOpenedFiles.Size = new System.Drawing.Size(168, 23);
            this.btnListOpenedFiles.TabIndex = 0;
            this.btnListOpenedFiles.Text = "Список файлов";
            this.btnListOpenedFiles.UseVisualStyleBackColor = true;
            this.btnListOpenedFiles.Click += new System.EventHandler(this.btnListOpenedFiles_Click);
            // 
            // geBoxComm
            // 
            this.geBoxComm.Controls.Add(this.timerProgressBar);
            this.geBoxComm.Controls.Add(this.label1);
            this.geBoxComm.Controls.Add(this.numericUpDown1);
            this.geBoxComm.Controls.Add(this.numResponseTimeout);
            this.geBoxComm.Controls.Add(this.label2);
            this.geBoxComm.Location = new System.Drawing.Point(453, 249);
            this.geBoxComm.Name = "geBoxComm";
            this.geBoxComm.Size = new System.Drawing.Size(223, 132);
            this.geBoxComm.TabIndex = 13;
            this.geBoxComm.TabStop = false;
            this.geBoxComm.Text = "Общее";
            // 
            // timerProgressBar
            // 
            this.timerProgressBar.Location = new System.Drawing.Point(9, 41);
            this.timerProgressBar.Name = "timerProgressBar";
            this.timerProgressBar.Size = new System.Drawing.Size(203, 18);
            this.timerProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.timerProgressBar.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Эпилог дампа (байт):";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(152, 67);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown1.TabIndex = 14;
            this.numericUpDown1.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // numResponseTimeout
            // 
            this.numResponseTimeout.Location = new System.Drawing.Point(152, 14);
            this.numResponseTimeout.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numResponseTimeout.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numResponseTimeout.Name = "numResponseTimeout";
            this.numResponseTimeout.Size = new System.Drawing.Size(60, 20);
            this.numResponseTimeout.TabIndex = 13;
            this.numResponseTimeout.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ожидание ответа (сек.):";
            // 
            // stopBtn
            // 
            this.stopBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopBtn.Location = new System.Drawing.Point(119, 99);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(55, 23);
            this.stopBtn.TabIndex = 6;
            this.stopBtn.Text = "Стоп";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 412);
            this.Controls.Add(this.geBoxComm);
            this.Controls.Add(this.grBoxBat);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grBoxDump);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ПИ - анализатор файлов дампа";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.grBoxDump.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grBoxBat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numBatchFileNum)).EndInit();
            this.geBoxComm.ResumeLayout(false);
            this.geBoxComm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numResponseTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox grBoxDump;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTSMI;
        private System.Windows.Forms.ToolStripMenuItem инструментыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connPrmsTSMI;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel tsLblCurrentFile;
        private System.Windows.Forms.ToolStripMenuItem openDirTSMI;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsLblTotalFiles;
        private System.Windows.Forms.GroupBox grBoxBat;
        private System.Windows.Forms.NumericUpDown numBatchFileNum;
        private System.Windows.Forms.Button btnExecFile;
        private System.Windows.Forms.Button btnListOpenedFiles;
        private System.Windows.Forms.GroupBox geBoxComm;
        private System.Windows.Forms.NumericUpDown numResponseTimeout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnShowFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnExecAll;
        private System.Windows.Forms.ProgressBar timerProgressBar;
        private System.Windows.Forms.Button stopBtn;
    }
}

