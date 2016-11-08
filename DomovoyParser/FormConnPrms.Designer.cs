namespace DomovoyParser
{
    partial class FormConnPrms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConnPrms));
            this.btnSpecifyDumpFileDirectory = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbRParam = new System.Windows.Forms.TextBox();
            this.tbDumpPrefix = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnRestoreDefaultConnSettings = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.numReadRecordsCount = new System.Windows.Forms.NumericUpDown();
            this.btnOpenDBFile = new System.Windows.Forms.Button();
            this.tbDumpDirectory = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDBFileName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRadioModuleIp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMeterAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbRetranslatorMode = new System.Windows.Forms.CheckBox();
            this.tbRetranslatorAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbConnectionStr = new System.Windows.Forms.RichTextBox();
            this.btnExportBat = new System.Windows.Forms.Button();
            this.rbTCPMode = new System.Windows.Forms.RadioButton();
            this.rbCOMMode = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numReadRecordsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSpecifyDumpFileDirectory
            // 
            this.btnSpecifyDumpFileDirectory.FlatAppearance.BorderSize = 0;
            this.btnSpecifyDumpFileDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpecifyDumpFileDirectory.Image = ((System.Drawing.Image)(resources.GetObject("btnSpecifyDumpFileDirectory.Image")));
            this.btnSpecifyDumpFileDirectory.Location = new System.Drawing.Point(214, 103);
            this.btnSpecifyDumpFileDirectory.Name = "btnSpecifyDumpFileDirectory";
            this.btnSpecifyDumpFileDirectory.Size = new System.Drawing.Size(23, 19);
            this.btnSpecifyDumpFileDirectory.TabIndex = 45;
            this.btnSpecifyDumpFileDirectory.UseVisualStyleBackColor = true;
            this.btnSpecifyDumpFileDirectory.Click += new System.EventHandler(this.btnSpecifyDumpFileDirectory_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(174, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Параметр (-r):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(148, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 43;
            // 
            // tbRParam
            // 
            this.tbRParam.Location = new System.Drawing.Point(175, 187);
            this.tbRParam.Name = "tbRParam";
            this.tbRParam.Size = new System.Drawing.Size(157, 20);
            this.tbRParam.TabIndex = 42;
            this.tbRParam.Tag = "meteraddrr";
            this.tbRParam.TextChanged += new System.EventHandler(this.connectionParams_Changed);
            // 
            // tbDumpPrefix
            // 
            this.tbDumpPrefix.Location = new System.Drawing.Point(246, 103);
            this.tbDumpPrefix.Name = "tbDumpPrefix";
            this.tbDumpPrefix.Size = new System.Drawing.Size(86, 20);
            this.tbDumpPrefix.TabIndex = 41;
            this.tbDumpPrefix.Tag = "dumpprefix";
            this.tbDumpPrefix.TextChanged += new System.EventHandler(this.connectionParams_Changed);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(243, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Постфикс дампа:";
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.Control;
            this.btnConnect.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnConnect.Location = new System.Drawing.Point(253, 340);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(79, 23);
            this.btnConnect.TabIndex = 39;
            this.btnConnect.Text = "Прочесть";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnRestoreDefaultConnSettings
            // 
            this.btnRestoreDefaultConnSettings.Location = new System.Drawing.Point(12, 340);
            this.btnRestoreDefaultConnSettings.Name = "btnRestoreDefaultConnSettings";
            this.btnRestoreDefaultConnSettings.Size = new System.Drawing.Size(63, 23);
            this.btnRestoreDefaultConnSettings.TabIndex = 38;
            this.btnRestoreDefaultConnSettings.Text = "Сброс";
            this.btnRestoreDefaultConnSettings.UseVisualStyleBackColor = true;
            this.btnRestoreDefaultConnSettings.Click += new System.EventHandler(this.btnRestoreDefaultConnSettings_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(214, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Считываемых записей:";
            // 
            // numReadRecordsCount
            // 
            this.numReadRecordsCount.Location = new System.Drawing.Point(277, 148);
            this.numReadRecordsCount.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numReadRecordsCount.Name = "numReadRecordsCount";
            this.numReadRecordsCount.Size = new System.Drawing.Size(55, 20);
            this.numReadRecordsCount.TabIndex = 36;
            this.numReadRecordsCount.Tag = "numrecords";
            this.numReadRecordsCount.ValueChanged += new System.EventHandler(this.connectionParams_Changed);
            // 
            // btnOpenDBFile
            // 
            this.btnOpenDBFile.FlatAppearance.BorderSize = 0;
            this.btnOpenDBFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDBFile.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenDBFile.Image")));
            this.btnOpenDBFile.Location = new System.Drawing.Point(309, 64);
            this.btnOpenDBFile.Name = "btnOpenDBFile";
            this.btnOpenDBFile.Size = new System.Drawing.Size(23, 19);
            this.btnOpenDBFile.TabIndex = 35;
            this.btnOpenDBFile.UseVisualStyleBackColor = true;
            this.btnOpenDBFile.Click += new System.EventHandler(this.btnOpenDBFile_Click);
            // 
            // tbDumpDirectory
            // 
            this.tbDumpDirectory.Location = new System.Drawing.Point(12, 103);
            this.tbDumpDirectory.Name = "tbDumpDirectory";
            this.tbDumpDirectory.Size = new System.Drawing.Size(202, 20);
            this.tbDumpDirectory.TabIndex = 34;
            this.tbDumpDirectory.Tag = "dumpdirectory";
            this.tbDumpDirectory.TextChanged += new System.EventHandler(this.connectionParams_Changed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Каталог дампа:";
            // 
            // tbDBFileName
            // 
            this.tbDBFileName.Location = new System.Drawing.Point(12, 64);
            this.tbDBFileName.Name = "tbDBFileName";
            this.tbDBFileName.Size = new System.Drawing.Size(294, 20);
            this.tbDBFileName.TabIndex = 32;
            this.tbDBFileName.Tag = "dbfilename";
            this.tbDBFileName.TextChanged += new System.EventHandler(this.connectionParams_Changed);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Файл БД:";
            // 
            // tbRadioModuleIp
            // 
            this.tbRadioModuleIp.Location = new System.Drawing.Point(12, 25);
            this.tbRadioModuleIp.Name = "tbRadioModuleIp";
            this.tbRadioModuleIp.Size = new System.Drawing.Size(135, 20);
            this.tbRadioModuleIp.TabIndex = 30;
            this.tbRadioModuleIp.Tag = "ipradio";
            this.tbRadioModuleIp.TextChanged += new System.EventHandler(this.connectionParams_Changed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "IP или COM адаптера:";
            // 
            // tbMeterAddress
            // 
            this.tbMeterAddress.Location = new System.Drawing.Point(12, 187);
            this.tbMeterAddress.Name = "tbMeterAddress";
            this.tbMeterAddress.Size = new System.Drawing.Size(157, 20);
            this.tbMeterAddress.TabIndex = 28;
            this.tbMeterAddress.Tag = "meteraddr";
            this.tbMeterAddress.TextChanged += new System.EventHandler(this.connectionParams_Changed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Прибор (-a):";
            // 
            // cbRetranslatorMode
            // 
            this.cbRetranslatorMode.AutoSize = true;
            this.cbRetranslatorMode.Location = new System.Drawing.Point(12, 129);
            this.cbRetranslatorMode.Name = "cbRetranslatorMode";
            this.cbRetranslatorMode.Size = new System.Drawing.Size(120, 17);
            this.cbRetranslatorMode.TabIndex = 26;
            this.cbRetranslatorMode.Tag = "useretranslator";
            this.cbRetranslatorMode.Text = "Ретранслятор (-m):";
            this.cbRetranslatorMode.UseVisualStyleBackColor = true;
            this.cbRetranslatorMode.CheckedChanged += new System.EventHandler(this.connectionParams_Changed);
            // 
            // tbRetranslatorAddress
            // 
            this.tbRetranslatorAddress.Location = new System.Drawing.Point(12, 148);
            this.tbRetranslatorAddress.Name = "tbRetranslatorAddress";
            this.tbRetranslatorAddress.Size = new System.Drawing.Size(157, 20);
            this.tbRetranslatorAddress.TabIndex = 25;
            this.tbRetranslatorAddress.Tag = "retranslatoraddr";
            this.tbRetranslatorAddress.TextChanged += new System.EventHandler(this.connectionParams_Changed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Строка подключения:";
            // 
            // rtbConnectionStr
            // 
            this.rtbConnectionStr.Location = new System.Drawing.Point(12, 239);
            this.rtbConnectionStr.Name = "rtbConnectionStr";
            this.rtbConnectionStr.Size = new System.Drawing.Size(320, 95);
            this.rtbConnectionStr.TabIndex = 23;
            this.rtbConnectionStr.Text = "";
            // 
            // btnExportBat
            // 
            this.btnExportBat.Location = new System.Drawing.Point(171, 340);
            this.btnExportBat.Name = "btnExportBat";
            this.btnExportBat.Size = new System.Drawing.Size(79, 23);
            this.btnExportBat.TabIndex = 46;
            this.btnExportBat.Text = "Экспорт";
            this.btnExportBat.UseVisualStyleBackColor = true;
            this.btnExportBat.Click += new System.EventHandler(this.btnExportBat_Click);
            // 
            // rbTCPMode
            // 
            this.rbTCPMode.AutoSize = true;
            this.rbTCPMode.Location = new System.Drawing.Point(165, 26);
            this.rbTCPMode.Name = "rbTCPMode";
            this.rbTCPMode.Size = new System.Drawing.Size(84, 17);
            this.rbTCPMode.TabIndex = 47;
            this.rbTCPMode.TabStop = true;
            this.rbTCPMode.Tag = "tcpmode";
            this.rbTCPMode.Text = "TCP (АРСУ)";
            this.rbTCPMode.UseVisualStyleBackColor = true;
            this.rbTCPMode.CheckedChanged += new System.EventHandler(this.connectionParams_Changed);
            // 
            // rbCOMMode
            // 
            this.rbCOMMode.AutoSize = true;
            this.rbCOMMode.Location = new System.Drawing.Point(250, 26);
            this.rbCOMMode.Name = "rbCOMMode";
            this.rbCOMMode.Size = new System.Drawing.Size(79, 17);
            this.rbCOMMode.TabIndex = 48;
            this.rbCOMMode.TabStop = true;
            this.rbCOMMode.Tag = "commode";
            this.rbCOMMode.Text = "COM (АРС)";
            this.rbCOMMode.UseVisualStyleBackColor = true;
            this.rbCOMMode.CheckedChanged += new System.EventHandler(this.connectionParams_Changed);
            // 
            // FormConnPrms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 373);
            this.Controls.Add(this.rbCOMMode);
            this.Controls.Add(this.rbTCPMode);
            this.Controls.Add(this.btnExportBat);
            this.Controls.Add(this.btnSpecifyDumpFileDirectory);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbRParam);
            this.Controls.Add(this.tbDumpPrefix);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnRestoreDefaultConnSettings);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numReadRecordsCount);
            this.Controls.Add(this.btnOpenDBFile);
            this.Controls.Add(this.tbDumpDirectory);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbDBFileName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbRadioModuleIp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMeterAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbRetranslatorMode);
            this.Controls.Add(this.tbRetranslatorAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbConnectionStr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormConnPrms";
            this.Text = "Параметры соединения";
            this.Load += new System.EventHandler(this.FormConnPrms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numReadRecordsCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSpecifyDumpFileDirectory;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbRParam;
        private System.Windows.Forms.TextBox tbDumpPrefix;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnRestoreDefaultConnSettings;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numReadRecordsCount;
        private System.Windows.Forms.Button btnOpenDBFile;
        private System.Windows.Forms.TextBox tbDumpDirectory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbDBFileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbRadioModuleIp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMeterAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbRetranslatorMode;
        private System.Windows.Forms.TextBox tbRetranslatorAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbConnectionStr;
        private System.Windows.Forms.Button btnExportBat;
        private System.Windows.Forms.RadioButton rbTCPMode;
        private System.Windows.Forms.RadioButton rbCOMMode;
    }
}