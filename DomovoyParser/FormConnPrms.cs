using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace DomovoyParser
{
    public struct ConnectionParams
    {
        public string strIpRadioModule;
        public string strDbFilename;
        public string strDumpDirectory;
        public string strDumpPrefix;
        public string strRParam;
        public bool bUseRetranslator;
        public bool bUseTcp;
        public string strRetranslatorAddr;
        public string strMeterAddr;
        public int iReadRecordsCount;
        public string strRDSLibPath;

        public string strResultConnectionString;
        public string strResultDumpFilename;
        public string strResultLogFilename;
    }

    public partial class FormConnPrms : Form
    {
        public FormConnPrms()
        {
            InitializeComponent();

            pathToRdsUtil = AppDomain.CurrentDomain.BaseDirectory + BatchConnection.FolderNameLib + "\\" + "rdslib.exe";
            defaultDumpsDirectory = AppDomain.CurrentDomain.BaseDirectory + BatchConnection.FolderNameLib + "\\" + BatchConnection.FolderNameDump;

            FillConnectionSettingsStructure(ref connectionParams, true);

            RefreshConnectionSettingsFields(connectionParams);

            defaultConnectionParams = connectionParams;
            AreConnectionParamsPrestine = true;

            ofd1.Filter = "База данных firebird (*.gdb)|*.gdb";
            fbd.Description = "Выберите дирректорию, в которой будут храниться файлы дампа:";
        }


        OpenFileDialog ofd1 = new OpenFileDialog();                     //для открытия файла базы данных
        FolderBrowserDialog fbd = new FolderBrowserDialog();            //для уточнения дирректории файла дампа

        string pathToRdsUtil = "";
        string defaultDumpsDirectory;

        public ConnectionParams connectionParams;
        public ConnectionParams defaultConnectionParams;

        bool _areConnectionParamsPrestine;
        bool AreConnectionParamsPrestine
        {
            get { return _areConnectionParamsPrestine; }
            set
            {
                if (value == true)
                    btnRestoreDefaultConnSettings.Enabled = false;
                else
                    btnRestoreDefaultConnSettings.Enabled = true;
            }
        }

        bool _useRetranslator;
        public bool UseRetranslator
        {
            get { return _useRetranslator; }
            set
            {
                _useRetranslator = value;
                if (_useRetranslator)
                    tbRetranslatorAddress.Enabled = true;
                else
                    tbRetranslatorAddress.Enabled = false;
            }
        }

        bool _useTCP;
        public bool UseTCP
        {
            get { return _useTCP; }
            set
            {
                _useTCP = value;
                if (_useTCP)
                    rbTCPMode.Checked = true;
                else
                    rbCOMMode.Checked = true;
            }
        }


        public void FillConnectionSettingsStructure(ref ConnectionParams conPrms, bool setWithDefault = false)
        {
            if (setWithDefault)
            {
                conPrms.strIpRadioModule = "192.168.0.20";
                conPrms.strMeterAddr = "9a0f50";
                conPrms.strDbFilename = AppDomain.CurrentDomain.BaseDirectory + BatchConnection.FolderNameLib + "\\4rmd.gdb";
                conPrms.strDumpDirectory = defaultDumpsDirectory;
                conPrms.strDumpPrefix = "dump";
                conPrms.bUseRetranslator = true;
                conPrms.strRetranslatorAddr = "00FD450800FF4220";
                conPrms.strRParam = "4220";
                conPrms.iReadRecordsCount = 10;
                conPrms.strRDSLibPath = pathToRdsUtil;
                conPrms.bUseTcp = true;
            }
        }

        public void RefreshConnectionSettingsFields(ConnectionParams conPrms)
        {
            tbDBFileName.Text = conPrms.strDbFilename;
            tbDumpDirectory.Text = conPrms.strDumpDirectory;
            tbDumpPrefix.Text = conPrms.strDumpPrefix;
            tbRadioModuleIp.Text = conPrms.strIpRadioModule;
            tbRetranslatorAddress.Text = conPrms.strRetranslatorAddr;

            cbRetranslatorMode.Checked = conPrms.bUseRetranslator;
            UseRetranslator = connectionParams.bUseRetranslator;
            UseTCP = connectionParams.bUseTcp;

            tbRParam.Text = conPrms.strRParam;
            tbMeterAddress.Text = conPrms.strMeterAddr;

            numReadRecordsCount.Value = conPrms.iReadRecordsCount;
        }

        private void connectionParams_Changed(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                TextBox tb = (TextBox)sender;
                switch (tb.Tag.ToString())
                {
                    case "ipradio": { connectionParams.strIpRadioModule = tb.Text; break; }
                    case "dbfilename": { connectionParams.strDbFilename = tb.Text; break; }
                    case "dumpdirectory": { connectionParams.strDumpDirectory = tb.Text; break; }
                    case "dumpprefix": { connectionParams.strDumpPrefix = tb.Text; break; }
                    case "retranslatoraddr": { connectionParams.strRetranslatorAddr = tb.Text; break; }
                    case "meteraddr": { connectionParams.strMeterAddr = tb.Text; break; }
                    case "meteraddrr": { connectionParams.strRParam = tb.Text; break; }
                }
            }
            else if (sender.GetType() == typeof(CheckBox))
            {
                CheckBox cb = (CheckBox)sender;
                switch (cb.Tag.ToString())
                {
                    case "useretranslator":
                        {

                            UseRetranslator = ((CheckBox)sender).Checked;
                            connectionParams.bUseRetranslator = cb.Checked;

                            if (!UseRetranslator)
                                connectionParams.strRParam = "4508";
                            else
                                connectionParams.strRParam = "4220";
                            tbRParam.Text = connectionParams.strRParam;
                            break;
                        }
                }
            }
            else if (sender.GetType() == typeof(NumericUpDown))
            {
                NumericUpDown num = (NumericUpDown)sender;
                switch (num.Tag.ToString())
                {
                    case "numrecords": { connectionParams.iReadRecordsCount = (int)num.Value; break; }
                }
            }
            else if (sender.GetType() == typeof(RadioButton))
            {
                RadioButton rb = (RadioButton)sender;
                switch (rb.Tag.ToString())
                {
                    case "commode": { connectionParams.bUseTcp = false; break; }
                    case "tcpmode": { connectionParams.bUseTcp = true; break; }
                }
            }

            //if (connectionParams.Equals(defaultConnectionParams))
            //    AreConnectionParamsPrestine = true;
            //else
            //    AreConnectionParamsPrestine = false;

            //RefreshConnectionSettingsFields(connectionParams);
            createConnectionString(ref connectionParams);
        }

        private void btnOpenDBFile_Click(object sender, EventArgs e)
        {
            ofd1.InitialDirectory = connectionParams.strDbFilename;
            if (ofd1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                connectionParams.strDbFilename = ofd1.FileName;
                RefreshConnectionSettingsFields(connectionParams);
            }
        }
        private void btnSpecifyDumpFileDirectory_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                connectionParams.strDumpDirectory = fbd.SelectedPath;
                RefreshConnectionSettingsFields(connectionParams);
            }
        }

        private void btnRestoreDefaultConnSettings_Click(object sender, EventArgs e)
        {
            connectionParams = defaultConnectionParams;
            RefreshConnectionSettingsFields(connectionParams);
        }


        string tmpDumpFileName;
        string tmpLogFileName;

        private void createConnectionString(ref ConnectionParams conPrms)
        {
            tmpDumpFileName = connectionParams.strDumpDirectory + DateTime.Now.Date.ToShortDateString() + "_" + connectionParams.strMeterAddr + "_" + connectionParams.strDumpPrefix + ".dat";
            tmpLogFileName = defaultDumpsDirectory + DateTime.Now.Date.ToShortDateString() + "_" + connectionParams.strMeterAddr + "_" + "_log.txt";
            string retranslatorAddrStr = connectionParams.bUseRetranslator ? String.Format(" -m{0}", connectionParams.strRetranslatorAddr) : "";

            string connectionProtocol = conPrms.bUseTcp ? "-ptype=inet,host=" + conPrms.strIpRadioModule : "-ptype=serial,port=" + conPrms.strIpRadioModule;

            string tmpCmd = String.Format("{0} \"{1}\" -o\"127.0.0.1:{2}\" -f\"{3}\" -s0 -c30 -n{4}{5} -r{6} -D100 -a{7} -M2  2> \"{8}\"",
                "\"" + pathToRdsUtil + "\"", connectionProtocol, connectionParams.strDbFilename, tmpDumpFileName, connectionParams.iReadRecordsCount.ToString(),
                retranslatorAddrStr, connectionParams.strRParam, connectionParams.strMeterAddr, tmpLogFileName);
            rtbConnectionStr.Text = tmpCmd;

            conPrms.strResultConnectionString = tmpCmd;
            conPrms.strResultDumpFilename = tmpDumpFileName;
            conPrms.strResultLogFilename = tmpLogFileName;

            if (conPrms.strResultConnectionString == defaultConnectionParams.strResultConnectionString)
                AreConnectionParamsPrestine = true;
            else
                AreConnectionParamsPrestine = false;
        }


        private void FormConnPrms_Load(object sender, EventArgs e)
        {

        }

        SaveFileDialog sfd = new SaveFileDialog();
        private void btnExportBat_Click(object sender, EventArgs e)
        {
            sfd.Filter = "Batch файл (*.bat)|*.bat";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(connectionParams.strResultConnectionString);
                sw.Flush();
                sw.Close();
                fs.Close();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

        }
    }


}
