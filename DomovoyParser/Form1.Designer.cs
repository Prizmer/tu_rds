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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.grBoxDump = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.openDirTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsExportBtn = new System.Windows.Forms.ToolStripMenuItem();
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
            this.stopBtn = new System.Windows.Forms.Button();
            this.timerProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numResponseTimeout = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReadDaily = new System.Windows.Forms.Button();
            this.btnReadCurrent = new System.Windows.Forms.Button();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbSerial = new System.Windows.Forms.TextBox();
            this.numT = new System.Windows.Forms.NumericUpDown();
            this.numP = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.grBoxDump.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.grBoxBat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBatchFileNum)).BeginInit();
            this.geBoxComm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numResponseTimeout)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
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
            this.richTextBox1.Size = new System.Drawing.Size(660, 81);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.DoubleClick += new System.EventHandler(this.richTextBox1_DoubleClick);
            // 
            // grBoxDump
            // 
            this.grBoxDump.Controls.Add(this.button2);
            this.grBoxDump.Location = new System.Drawing.Point(206, 304);
            this.grBoxDump.Name = "grBoxDump";
            this.grBoxDump.Size = new System.Drawing.Size(111, 132);
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
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTSMI,
            this.openDirTSMI,
            this.toolStripMenuItem1,
            this.tsExportBtn});
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
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(258, 6);
            // 
            // tsExportBtn
            // 
            this.tsExportBtn.Name = "tsExportBtn";
            this.tsExportBtn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsExportBtn.Size = new System.Drawing.Size(261, 22);
            this.tsExportBtn.Text = "Экспорт *.xls";
            this.tsExportBtn.Click += new System.EventHandler(this.tsExportBtn_Click);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 442);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(684, 22);
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
            this.grBoxBat.Controls.Add(this.btnExecAll);
            this.grBoxBat.Controls.Add(this.btnShowFile);
            this.grBoxBat.Controls.Add(this.numBatchFileNum);
            this.grBoxBat.Controls.Add(this.btnExecFile);
            this.grBoxBat.Controls.Add(this.btnListOpenedFiles);
            this.grBoxBat.Location = new System.Drawing.Point(12, 304);
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
            this.btnExecAll.Size = new System.Drawing.Size(176, 23);
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
            this.btnListOpenedFiles.Size = new System.Drawing.Size(176, 23);
            this.btnListOpenedFiles.TabIndex = 0;
            this.btnListOpenedFiles.Text = "Список файлов";
            this.btnListOpenedFiles.UseVisualStyleBackColor = true;
            this.btnListOpenedFiles.Click += new System.EventHandler(this.btnListOpenedFiles_Click);
            // 
            // geBoxComm
            // 
            this.geBoxComm.Controls.Add(this.stopBtn);
            this.geBoxComm.Controls.Add(this.timerProgressBar);
            this.geBoxComm.Controls.Add(this.label1);
            this.geBoxComm.Controls.Add(this.numericUpDown1);
            this.geBoxComm.Controls.Add(this.numResponseTimeout);
            this.geBoxComm.Controls.Add(this.label2);
            this.geBoxComm.Location = new System.Drawing.Point(323, 304);
            this.geBoxComm.Name = "geBoxComm";
            this.geBoxComm.Size = new System.Drawing.Size(223, 132);
            this.geBoxComm.TabIndex = 13;
            this.geBoxComm.TabStop = false;
            this.geBoxComm.Text = "Общее";
            // 
            // stopBtn
            // 
            this.stopBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopBtn.Location = new System.Drawing.Point(152, 99);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(60, 23);
            this.stopBtn.TabIndex = 17;
            this.stopBtn.Text = "Стоп";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
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
            180,
            0,
            0,
            0});
            this.numResponseTimeout.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numResponseTimeout.Name = "numResponseTimeout";
            this.numResponseTimeout.Size = new System.Drawing.Size(60, 20);
            this.numResponseTimeout.TabIndex = 13;
            this.numResponseTimeout.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numResponseTimeout.ValueChanged += new System.EventHandler(this.numResponseTimeout_ValueChanged);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReadDaily);
            this.groupBox1.Controls.Add(this.btnReadCurrent);
            this.groupBox1.Controls.Add(this.tbPass);
            this.groupBox1.Controls.Add(this.tbSerial);
            this.groupBox1.Controls.Add(this.numT);
            this.groupBox1.Controls.Add(this.numP);
            this.groupBox1.Location = new System.Drawing.Point(552, 304);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 132);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ф-ии СО";
            // 
            // btnReadDaily
            // 
            this.btnReadDaily.Location = new System.Drawing.Point(60, 95);
            this.btnReadDaily.Name = "btnReadDaily";
            this.btnReadDaily.Size = new System.Drawing.Size(46, 23);
            this.btnReadDaily.TabIndex = 19;
            this.btnReadDaily.Text = "Сут";
            this.btnReadDaily.UseVisualStyleBackColor = true;
            this.btnReadDaily.Click += new System.EventHandler(this.btnReadDaily_Click);
            // 
            // btnReadCurrent
            // 
            this.btnReadCurrent.Location = new System.Drawing.Point(6, 95);
            this.btnReadCurrent.Name = "btnReadCurrent";
            this.btnReadCurrent.Size = new System.Drawing.Size(51, 23);
            this.btnReadCurrent.TabIndex = 18;
            this.btnReadCurrent.Text = "Тек";
            this.btnReadCurrent.UseVisualStyleBackColor = true;
            this.btnReadCurrent.Click += new System.EventHandler(this.btnReadCurrent_Click);
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(6, 69);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(100, 20);
            this.tbPass.TabIndex = 17;
            this.tbPass.Text = "3";
            this.toolTip1.SetToolTip(this.tbPass, "Пароль: частота опоса в днях");
            // 
            // tbSerial
            // 
            this.tbSerial.Location = new System.Drawing.Point(6, 47);
            this.tbSerial.Name = "tbSerial";
            this.tbSerial.Size = new System.Drawing.Size(100, 20);
            this.tbSerial.TabIndex = 16;
            this.tbSerial.Text = "2260";
            this.toolTip1.SetToolTip(this.tbSerial, "Последние 4 цифры десятичного серийника");
            // 
            // numT
            // 
            this.numT.Location = new System.Drawing.Point(60, 19);
            this.numT.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numT.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numT.Name = "numT";
            this.numT.Size = new System.Drawing.Size(45, 20);
            this.numT.TabIndex = 15;
            this.toolTip1.SetToolTip(this.numT, "Канал");
            this.numT.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numP
            // 
            this.numP.Location = new System.Drawing.Point(6, 19);
            this.numP.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numP.Name = "numP";
            this.numP.Size = new System.Drawing.Size(51, 20);
            this.numP.TabIndex = 14;
            this.toolTip1.SetToolTip(this.numP, "Адрес");
            this.numP.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToOrderColumns = true;
            this.dgv1.AllowUserToResizeColumns = false;
            this.dgv1.AllowUserToResizeRows = false;
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.ColumnHeadersVisible = false;
            this.dgv1.Location = new System.Drawing.Point(12, 114);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.Size = new System.Drawing.Size(660, 184);
            this.dgv1.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 464);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReadDaily;
        private System.Windows.Forms.Button btnReadCurrent;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbSerial;
        private System.Windows.Forms.NumericUpDown numT;
        private System.Windows.Forms.NumericUpDown numP;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsExportBtn;
    }
}

