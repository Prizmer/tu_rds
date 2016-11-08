using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;

namespace DomovoyParser
{
    public partial class Form1 : Form
    {

        public Form1(string openedFilename)
        {
            InitializeComponent();

            InitFreeMode();
            richTextBox1.Text = "Двойной клик для выбора *.dat файла или группы *.bat файлов";

            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Batch файлы (*.bat)|*.bat|Бинарные файлы (*.dat)|*.dat";
            openFileDialog.Multiselect = true;

            folderBrowserDialog.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;
            folderBrowserDialog.Description = "Выберите дирректорию, содержащую файлы *.bat";

            numResponseTimeout.Value = 15;

            BatchConnectionList = new List<BatchConnection>();

            this.Text = formCaptionStringBase;

            BatchConnection.FolderNameLib = "RDS";
            BatchConnection.FolderNameDump = "Dumps";
            BatchConnection.FolderNameLog = BatchConnection.FolderNameDump;

            if (openedFilename.Length > 0)
            {
                if (loadDumpFile(openedFilename))
                    PrintLastRecord((int)numericUpDown1.Value);
            }
        }

        const string DIR_NAME_LIB = "RDS";
        const string RIR_NAME_DUMPS = "Dumps";        

        string formCaptionStringBase = "ПИ-RDS";
        string formCaptionMultiBatchMode = " - набор файлов *.bat";
        string formCaptionDumpReadMode = " - чтение дампа";

        string formCaptionBatExecution = " - ВЫПОЛНЕНИЕ, ЖДИТЕ";

        const byte RecordLength = 32;

        //форма генерации *.bat файла
        FormConnPrms connectionParamForm = new FormConnPrms();

        OpenFileDialog openFileDialog;
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

        FileStream fStreamDump;

        #region Разбор дампа

        public struct Params
        {
            /**   2 bytes   **/
            public float[] Q;    //Q1-Q2
            public float[] T;    //T1-T4
            public float[] M;    //M1-M4
            public float V5;

            /**   1 byte   **/
            public float[] P;    //P1-P4 


            public int[] NC;     //NC1-NC2
            public int TimeMinutes1;
            public int VoltsBattery;
            public int TimeMinutes2;
            public int Reserved;
        };
        public struct MeterInfo
        {
            public string serialNumber;
        };

        private int GiveMeValue(FileStream fs, int valBytesCount)
        {
            try
            {
                int fsPosition = (int)fs.Position;
                byte[] buffer = new byte[fs.Length];
                int bytesRead = fs.Read(buffer, fsPosition, valBytesCount);

                byte[] tmpInt16Buffer = new byte[valBytesCount];
                Array.Copy(buffer, fsPosition, tmpInt16Buffer, 0, valBytesCount);
                //Array.Reverse(tmpInt16Buffer);
                int val = -2;
                if (valBytesCount == 1)
                    return (int)tmpInt16Buffer[0];
                else if (valBytesCount == 2)
                    val = BitConverter.ToInt16(tmpInt16Buffer, 0);

                return val;
            }
            catch (Exception ex)
            {
                return -2;
            }
        }

        private bool GetMeterInfo(FileStream fs, ref MeterInfo mInfo)
        {
            int meterInfoFirstByte = 0x0123;
            mInfo = new MeterInfo();
            fs.Seek(meterInfoFirstByte, SeekOrigin.Begin);

            try
            {
                int fsPosition = (int)fs.Position;
                byte[] buffer = new byte[fs.Length];

                int bytesRead = fs.Read(buffer, fsPosition, 3);

                byte[] tmpSerialBuffer1 = new byte[1];
                byte[] tmpSerialBuffer2 = new byte[2];
                Array.Copy(buffer, fsPosition+2, tmpSerialBuffer1, 0, 1);
                Array.Copy(buffer, fsPosition, tmpSerialBuffer2, 0, 2);
                Int16 serial2 = BitConverter.ToInt16(tmpSerialBuffer2, 0);

                mInfo.serialNumber = BitConverter.ToString(tmpSerialBuffer1) + "-" + serial2.ToString();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        #endregion

        #region Принтеры

        private void PrintLastRecord(int bytesFromTheEnd, bool bClearBefore = true)
        {
            bool doPrint = true;

            if (fStreamDump != null)
            {
                if (bClearBefore) richTextBox1.Clear();
                int lastFileByteIndex = (int)(fStreamDump.Length);
                long lastRecordFirstIndex = lastFileByteIndex - bytesFromTheEnd - RecordLength;
                fStreamDump.Seek((int)lastRecordFirstIndex, SeekOrigin.Begin);

                Params p = new Params();

                richTextBox1.Text += String.Format("***[ S/N: {0} ]***\n", tmpMeterInfo.serialNumber);

                p.Q = new float[2];
                for (int i = 0; i < 2; i++)
                {
                    p.Q[i] = (float)GiveMeValue(fStreamDump, 2);
                    if (doPrint) richTextBox1.Text += String.Format("Q{0}: {1}{2}; ", i + 1, p.Q[i], "");
                }

                if (false) richTextBox1.Text += "\n";
                p.T = new float[4];
                for (int i = 0; i < 4; i++)
                {
                    p.T[i] = (float)GiveMeValue(fStreamDump, 2);
                    if (doPrint) richTextBox1.Text += String.Format("T{0}: {1}{2}; ", i + 1, p.T[i], "");
                }

                if (false) richTextBox1.Text += "\n";
                p.M = new float[4];
                for (int i = 0; i < 4; i++)
                {
                    p.M[i] = (float)GiveMeValue(fStreamDump, 2);
                    if (doPrint) richTextBox1.Text += String.Format("M{0}: {1}{2}; ", i + 1, p.M[i], "");
                }

                if (false) richTextBox1.Text += "\n";
                p.V5 = (float)GiveMeValue(fStreamDump, 2);
                if (doPrint) richTextBox1.Text += String.Format("V{0}: {1}{2}; ", 5, p.V5, "");

                if (false) richTextBox1.Text += "\n";
                p.P = new float[4];
                for (int i = 0; i < 4; i++)
                {
                    p.P[i] = (float)GiveMeValue(fStreamDump, 1);
                    if (doPrint) richTextBox1.Text += String.Format("P{0}: {1}{2}; ", i + 1, p.P[i], "");
                }

                if (true) richTextBox1.Text += "\n";
                p.NC = new int[2];
                for (int i = 0; i < 2; i++)
                {
                    p.NC[i] = GiveMeValue(fStreamDump, 1);

                    string sNCDescription = "";
                    if (((p.NC[i] >> 0) & 0x01) == 0x01) sNCDescription += "Ошибка термодатчика 1;";
                    if (((p.NC[i] >> 1) & 0x01) == 0x01) sNCDescription += "Ошибка термодатчика 2;";
                    if (((p.NC[i] >> 2) & 0x01) == 0x01) sNCDescription += "T1<T2 или T1-T2 меньше порога;";
                    if (((p.NC[i] >> 3) & 0x01) == 0x01) sNCDescription += "Т2<Tх;";
                    if (((p.NC[i] >> 4) & 0x01) == 0x01) sNCDescription += "dQ1<0;";
                    if (((p.NC[i] >> 5) & 0x01) == 0x01) sNCDescription += "нет внешнего питания;";
                    if (((p.NC[i] >> 6) & 0x01) == 0x01) sNCDescription += "проводилась коррекция времени;";
                    if (((p.NC[i] >> 7) & 0x01) == 0x01) sNCDescription += "изменялось содержимое EEPROM;";

                    if (sNCDescription == "") sNCDescription = "OK";

                    if (doPrint) richTextBox1.Text += String.Format("Вычислитель {0}: {1} [{2}];\n", i + 1, p.NC[i], sNCDescription);

                }

                p.TimeMinutes1 = GiveMeValue(fStreamDump, 1);
                p.VoltsBattery = GiveMeValue(fStreamDump, 1);
                p.TimeMinutes2 = GiveMeValue(fStreamDump, 1);
                p.Reserved = GiveMeValue(fStreamDump, 1);

                if (doPrint)
                {
                    richTextBox1.Text += String.Format("Time{0}: {1}{2}; ", 1, p.TimeMinutes1, "");
                    richTextBox1.Text += String.Format("Time{0}: {1}{2}; ", 2, p.TimeMinutes2, "");
                    richTextBox1.Text += String.Format("Battery{0}: {1}{2}; ", "", p.VoltsBattery, " Volts");
                    richTextBox1.Text += String.Format("Reserved{0}: {1}{2}; ", "", p.Reserved, "");
                }
            }
        }

        private void PrintLoadedFilenames(List<BatchConnection> batchConnectionList)
        {
            if (batchConnectionList.Count == 0)
            {
                richTextBox1.Text = "Нет файлов";
                return;
            }


            richTextBox1.Text = "Файлы (" + batchConnectionList.Count + "): \n\n";

            int cnt = 1;
            foreach (BatchConnection bi in batchConnectionList)
            {
                if (bi.HasSourceFile)
                    richTextBox1.Text += cnt++.ToString() + ". " + bi.SourceName + "\n";
                else
                    richTextBox1.Text += cnt++.ToString() + ". " + bi.SerialNumber + "\n";
            }
        }

        private void PrintMsg(string msg)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke((MethodInvoker)delegate()
                {
                    richTextBox1.Text += msg;
                });
            }
            else
            {
                richTextBox1.Text += msg;
            }
        }

        private void ClearScreen()
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke((MethodInvoker)delegate()
                {
                    richTextBox1.Clear();
                });
            }
            else
            {
                richTextBox1.Clear();
            }
        }


        #endregion


        MeterInfo tmpMeterInfo = new MeterInfo();
        private bool loadDumpFile(string filename)
        {
            fStreamDump = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            if (GetMeterInfo(fStreamDump, ref tmpMeterInfo))
            {
                PrintLastRecord((int)numericUpDown1.Value);
                InitDumpReaderMode(filename);
                return true;
            }
            else
            {
                richTextBox1.Clear();
                richTextBox1.Text += String.Format("Ошибка. Вероятно файл поврежден. Прочитанное: {0}.", tmpMeterInfo.serialNumber);
                return false;
            }
        }


        #region Поток выполнения опроса

        Thread ExecutingThread;

        event EventHandler<EventArgs> BatchFileExecutionStartEvent;
        event EventHandler<EventArgs> BatchFileExecutionEndEvent;
        event EventHandler<EventArgs> BatchFileTriedEvent;


        private void StartExecutingThread(List<BatchConnection> batchConnectionList)
        {
            StopFlag = false;

            BatchFileExecutionStartEvent = new EventHandler<EventArgs>(BatchFileExecutionStart_EventHandler);
            BatchFileTriedEvent = new EventHandler<EventArgs>(BatchFileTried_EventHandler);
            BatchFileExecutionEndEvent = new EventHandler<EventArgs>(BatchFileExecutionEnd_EventHandler);


            ExecutingThread = new Thread(new ParameterizedThreadStart(ExecuteBatchConnectionList));
            ExecutingThread.Start(batchConnectionList);
        }

        //выполняется в отдельном потоке
        public void ExecuteBatchConnectionList(object batchConnectionListObject)
        {
            List<BatchConnection> batchConnectionList = (List<BatchConnection>)batchConnectionListObject;

            if (batchConnectionList.Count == 0)
                return;

            BatchFileExecutionStartEvent.Invoke(null, new EventArgs());
            ClearScreen();

            for (int i = 0; i < batchConnectionList.Count; i++)
            {
                if (StopFlag)
                {
                    BatchFileExecutionEnd_EventHandler(null, new EventArgs());
                    return;
                } 

                BatchConnection bConn = batchConnectionList[i];
                string tmpCmd = bConn.Command;

                if (!bConn.ExistsRDS)
                {
                    PrintMsg(String.Format("{1}: файл 'rdslib.exe, необходимый для подключения, не найден. Дирректория поиска: {0}\n\n", bConn.FileNameRDSLib, bConn.SerialNumber));
                    continue;
                }

                // создаем процесс cmd.exe с параметрами "ipconfig /all"
                ProcessStartInfo psiOpt = new ProcessStartInfo(@"cmd.exe");

                psiOpt.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
                // скрываем окно запущенного процесса
                psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
                psiOpt.RedirectStandardOutput = true;
                psiOpt.RedirectStandardInput = true;
                psiOpt.UseShellExecute = false;
                psiOpt.CreateNoWindow = true;
                // запускаем процесс
                Process procCommand = Process.Start(psiOpt);
               procCommand.StandardInput.WriteLine(tmpCmd);

               Thread.Sleep((int)numResponseTimeout.Value * 1000);

                if (File.Exists(bConn.FileNameDump))
                {
                    if (loadDumpFile(bConn.FileNameDump))
                    {
                        this.Invoke((MethodInvoker)delegate()
                        {
                            PrintLastRecord((int)numericUpDown1.Value);
                        });
                    }

                    File.Delete(bConn.FileNameDump + bConn.GenerateFileName(".dat"));
                }
                else
                {
                    try
                    {
                        procCommand.CloseMainWindow();
                    }
                    catch (Exception ex)
                    {

                    }

                    PrintMsg(String.Format("{0}: не найден файл дампа {1}, ошибка чтения.\n\n", bConn.SerialNumber, bConn.FileNameDump));
                }

                BatchFileTriedEvent.Invoke(null, new EventArgs());
            }

            BatchFileExecutionEndEvent.Invoke(null, new EventArgs());
        }

        public void BatchFileExecutionStart_EventHandler(object sender, EventArgs e)
        {
            timeoutProgressBarTimer = new System.Windows.Forms.Timer();
            timeoutProgressBarTimer.Interval = 1000;
            timeoutProgressBarTimer.Tick += new EventHandler(TimoutTimerTick_EventHandler);

            Delegate del = (MethodInvoker)delegate()
            {
                toolStripProgressBar1.Value = 0;
                tsLblCurrentFile.Text = "0";
                this.Text = formCaptionStringBase + formCaptionMultiBatchMode + formCaptionBatExecution;

                if (clearStatusTimer != null)
                    clearStatusTimer.Stop();

                timerProgressBar.Minimum = 0;
                timerProgressBar.Maximum = (int)numResponseTimeout.Value;
                timerProgressBar.Value = 0;

                fileCnt = 1;

            };

            this.Invoke(del);
        }


        int ticksCnt = 0;
        public void TimoutTimerTick_EventHandler(object sender, EventArgs e)
        {

        }

        int fileCnt = 1;
        public void BatchFileTried_EventHandler(object sender, EventArgs e)
        {
            Delegate del = (MethodInvoker)delegate()
            {
                ++toolStripProgressBar1.Value;
                tsLblCurrentFile.Text = (fileCnt++).ToString();
            };

            this.Invoke(del);
        }

        System.Windows.Forms.Timer clearStatusTimer;
        System.Windows.Forms.Timer timeoutProgressBarTimer;

        public void BatchFileExecutionEnd_EventHandler(object sender, EventArgs e)
        {

            Delegate del = (MethodInvoker)delegate()
            {
                this.Text = formCaptionStringBase + formCaptionMultiBatchMode;
                tsLblCurrentFile.Text = "0";
                toolStripProgressBar1.Value = 0;
            };

            Invoke(del);
        }

        #endregion

        private bool CreateBatchConnectionList(List<FileInfo> fileInfoList, ref List<BatchConnection> batchConnectionList)
        {
            batchConnectionList = new List<BatchConnection>();


            for (int i = 0; i < fileInfoList.Count; i++)
            {
                try
                {
                    FileStream fs = new FileStream(fileInfoList[i].FullName, FileMode.Open);
                    StreamReader sr = new StreamReader(fs);
                    BatchConnection bConn = new BatchConnection(sr.ReadToEnd(), fileInfoList[i].FullName);

                    batchConnectionList.Add(bConn);
                    sr.Close();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    richTextBox1.Text = "При чтении файлов и создании BatchConnection возникла ошибка";
                    return false;
                }
            }

            if (batchConnectionList.Count == 0)
                return false;


            return true;
        }


        #region Инициализаторы режимов

        private void InitFreeMode()
        {
            this.Text = formCaptionStringBase;

            tsLblCurrentFile.Text = "0";
            tsLblTotalFiles.Text = "0";
            toolStripProgressBar1.Value = 0;

            DumpReaderMode = false;
            BatchMode = false;
        }

        bool _dumpReaderMode;
        bool DumpReaderMode
        {
            get { return _dumpReaderMode; }
            set
            {
                _dumpReaderMode = value;
                if (value)
                {
                    BatchMode = !value;

                    tsLblCurrentFile.Text = "0";
                    tsLblTotalFiles.Text = "0";
                    toolStripProgressBar1.Minimum = 0;
                    toolStripProgressBar1.Value = 0;

                    numBatchFileNum.Value = numBatchFileNum.Minimum;

                    grBoxBat.Enabled = false;
                    grBoxDump.Enabled = true;
                }
                else
                {
                    grBoxDump.Enabled = false; ;
                }
            }
        }
        private bool InitDumpReaderMode(string dumpFileName)
        {
            this.Text = formCaptionStringBase + formCaptionDumpReadMode;
            DumpReaderMode = true;

            return true;
        }

        bool _batchMode;
        bool BatchMode
        {
            get { return _batchMode; }
            set
            {
                _batchMode = value;
                if (value)
                {
                    DumpReaderMode = !value;
                }
                else
                {
                    grBoxBat.Enabled = false;
                }
            }
        }

        List<BatchConnection> BatchConnectionList;
        private bool InitBatchMode()
        {
            if (BatchConnectionList.Count == 0)
            {
                richTextBox1.Text = "BatchConnectionList пуст";
                return false;
            }

            BatchMode = true;
            tsLblCurrentFile.Text = "0";
            tsLblTotalFiles.Text = BatchConnectionList.Count.ToString();

            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = BatchConnectionList.Count;
            toolStripProgressBar1.Value = 0;

            this.Text = formCaptionStringBase + formCaptionMultiBatchMode;

            numBatchFileNum.Maximum = BatchConnectionList.Count;

            grBoxBat.Enabled = true;
            grBoxDump.Enabled = false;

            DialogResult dlgr = MessageBox.Show(String.Format("Открыто ({0}) .bat файла, выполнить сразу?", BatchConnectionList.Count), "Выполнение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgr == System.Windows.Forms.DialogResult.Yes)
            {
                StartExecutingThread(BatchConnectionList);
                return true;
            }
            else
            {
                PrintLoadedFilenames(BatchConnectionList);
                return true;
            }

            return false;
        }

        #endregion

        #region Обработчики компонентов

        private void connPrmsTSMI_Click(object sender, EventArgs e)
        {
            if (connectionParamForm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                BatchConnection bCon = new BatchConnection(connectionParamForm.connectionParams.strResultConnectionString);
                BatchConnectionList = new List<BatchConnection>();
                BatchConnectionList.Add(bCon);

                InitBatchMode();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintLastRecord((int)numericUpDown1.Value);
        }

        private void richTextBox1_DoubleClick(object sender, EventArgs e)
        {
            openTSMI.PerformClick();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            PrintLastRecord((int)numericUpDown1.Value);
        }

        private void btnListOpenedFiles_Click(object sender, EventArgs e)
        {
            PrintLoadedFilenames(BatchConnectionList);
        }

        private void openTSMI_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fi = new FileInfo(openFileDialog.FileNames[0]);
                if (openFileDialog.FileNames.Length == 1 && fi.Extension == ".dat")
                {
                    loadDumpFile(openFileDialog.FileName);
                }
                else
                {
                    List<FileInfo> tmpFIList = new List<FileInfo>();
                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        FileInfo fi2 = new FileInfo(fileName);
                        if (fi2.Extension == ".bat")
                        {
                            tmpFIList.Add(fi2);
                        }
                    }

                    if (tmpFIList.Count > 0)
                    {
                        if (CreateBatchConnectionList(tmpFIList, ref BatchConnectionList))
                            InitBatchMode();
                    }
                }
            }
        }

        private void openDirTSMI_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DirectoryInfo di = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                FileInfo[] batchFilesArr = di.GetFiles("*.bat", SearchOption.TopDirectoryOnly);
                if (batchFilesArr.Length == 0)
                {
                    MessageBox.Show("В указанной дирректории отсутствуют файлы *.bat");
                    return;
                }

                List<FileInfo> fiList = new List<FileInfo>();
                fiList.AddRange(batchFilesArr);

                if (CreateBatchConnectionList(fiList, ref BatchConnectionList))
                    InitBatchMode();
            }
        }

        private void btnShowFile_Click(object sender, EventArgs e)
        {
            if (BatchConnectionList.Count == 0) richTextBox1.Text = "Список BatchConnectionList пуст";

            BatchConnection tmpBatchConn = BatchConnectionList[(int)numBatchFileNum.Value - 1];

            string fileCaption = tmpBatchConn.HasSourceFile ? tmpBatchConn.SourceName : tmpBatchConn.SerialNumber;

            richTextBox1.Text = "*** " + fileCaption + " ***\n\n";

            if (tmpBatchConn.HasSourceFile)
            {
                richTextBox1.Text += "Исходный файл:\n";
                richTextBox1.Text += tmpBatchConn.CommandOriginal + "\n\n";
            }

            richTextBox1.Text += "Интерпретированный:\n";
            richTextBox1.Text += tmpBatchConn.Command + "\n";
        }

        private void btnExecFile_Click(object sender, EventArgs e)
        {
            if (BatchConnectionList.Count == 0) richTextBox1.Text = "Список BatchConnectionList пуст";

            BatchConnection tmpBatchConn = BatchConnectionList[(int)numBatchFileNum.Value - 1];
            List<BatchConnection> tmpBatchConnList = new List<BatchConnection>();
            tmpBatchConnList.Add(tmpBatchConn);

            ExecuteBatchConnectionList(tmpBatchConnList);
        }

        private void btnExecAll_Click(object sender, EventArgs e)
        {
            StartExecutingThread(BatchConnectionList);
        }

        public volatile bool StopFlag = false;
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopFlag = true;
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            StopFlag = true;
            richTextBox1.Text += "Опрос остановится через несколько секунд\n";
        }
        
        #endregion




    }

    public class BatchConnection
    {
        public BatchConnection(string batchContent, string batchFileName = "")
        {
            _batchContentString = batchContent;
            _batchContentStringOrig = batchContent;

            _batchFileName = batchFileName;

            UpdateWithActualData();
        }



        string _batchFileName;
        public bool HasSourceFile
        {
            get 
            {
                if (File.Exists(_batchFileName))
                    return true;
                else
                    return false;           
            }
        }

        public string SourceFileName
        {
            get
            {
                if (HasSourceFile)
                {
                    return _batchFileName;
                }
                else
                {
                    return "";
                }
            }
        }

        public string SourceName
        {
            get
            {
                if (HasSourceFile)
                {
                    FileInfo fi = new FileInfo(_batchFileName);
                    return fi.Name;
                }
                else
                {
                    return "";
                }
            }
        }


        string _batchContentStringOrig;
        public string CommandOriginal
        {
            get { return _batchContentStringOrig; }
        }

        string _batchContentString;
        public string Command
        {
            get
            {
                return _batchContentString;
            }
            set
            {
                _batchContentString = value;
            }
        }

        public void Restore()
        {
            _batchContentString = _batchContentStringOrig;
        }

        public string FileNameRDSLib
        {
            get 
            { 
                if (_batchContentString.Length == 0) return "";
                try
                {
                    return Regex.Match(_batchContentString, "^[^ ]*").Groups[0].Value.Replace("\"", "");
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            set
            {
                try
                {
                    _batchContentString = Regex.Replace(_batchContentString, "^[^ ]*", "\"" + value + "\"");
                }
                catch (Exception ex)
                {
                    return;
                }

            }
        }
        public string FileNameDB
        {
            get 
            { 
                try
                {
                    string oOption = Regex.Match(_batchContentString, "-o\"[^ ]*").Groups[0].Value;
                    return Regex.Match(oOption, "\\w:\\\\[^\"]*").Groups[0].Value;
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            set
            {
                try
                {
                    string oOption = Regex.Match(_batchContentString, "-o\"[^ ]*").Groups[0].Value;
                    oOption = Regex.Replace(oOption, "\\w:\\\\[^\"]*", value);
                    _batchContentString = Regex.Replace(_batchContentString, "-o\"[^ ]*", oOption);
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }        
        public string FileNameDump
        {
            get 
            { 
                if (_batchContentString.Length == 0) return "";
                try
                {
                    return Regex.Match(_batchContentString, "-f\"[^ ]*").Groups[0].Value.Replace("-f", "").Replace("\"", "");
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            set
            {
                try
                {
                    _batchContentString = Regex.Replace(_batchContentString, "-f\"[^ ]*", "-f\"" + value + "\"");
                }
                catch (Exception ex)
                {
                    return;
                }

            }
        }
        public string FileNameLog
        {
            get 
            { 
                if (_batchContentString.Length == 0) return "";
                try
                {
                    string tmpLogVal = Regex.Match(_batchContentString, ">\"? ?[^ ?]*").Groups[0].Value.Replace("\"", "");
                    return Regex.Replace(tmpLogVal, ">\"? ?", "");
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            set
            {
                try
                {
                    _batchContentString = Regex.Replace(_batchContentString, ">\"? ?[^ ?]*", ">\"" + value + "\"");
                }
                catch (Exception ex)
                {
                    return;
                }

            }
        }

        public string SerialNumber
        {
            get 
            { 
                if (_batchContentString.Length == 0) return "";
                try
                {
                    return Regex.Match(_batchContentString, "-a[^ ]*").Groups[0].Value.Replace("-a", String.Empty);
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
        }

        public bool ExistsRDS
        {
            get 
            {
                if (File.Exists(FileNameRDSLib))
                    return true;
                else
                    return false;
            }
        }
        public bool ExistsDump
        {
            get 
            {
                if (File.Exists(FileNameDump))
                    return true;
                else
                    return false;
            }
        }

        static string _libFolderName = "";
        static string _dumpFolderName = "";
        static string _logFolderName = "";

        public static string FolderNameLib
        {
            get
            {
                return _libFolderName.Length == 0 ? "RDS" : _libFolderName;
            }
            set
            {
                _libFolderName = value;
            }
        }
        public static string FolderNameDump
        {
            get
            {
                return _dumpFolderName.Length == 0 ? "Dumps" : _dumpFolderName;
            }
            set
            {
                _dumpFolderName = value;
            }
        }
        public static string FolderNameLog
        {
            get
            {
                return _logFolderName.Length == 0 ? FolderNameDump : _logFolderName;
            }
            set
            {
                _logFolderName = value;
            }
        }

        public string GenerateFileName(string postfix)
        {
            return DateTime.Now.Date.ToShortDateString().Replace(".", "-") + "_" + SerialNumber + postfix;
        }

        public void UpdateWithActualData()
        {
            Restore();

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory; ;
            FileNameRDSLib = baseDirectory + FolderNameLib + "\\rdslib.exe";
            FileNameDB = baseDirectory + FolderNameLib + "\\4rmd.gdb";

            string dumpsFolder = baseDirectory + FolderNameLib + "\\" + FolderNameDump;
            Directory.CreateDirectory(dumpsFolder);
            FileNameDump = dumpsFolder + "\\" + this.GenerateFileName(".dat");

            if (FolderNameLog.Length == 0) FolderNameLog = FolderNameDump;
            string logsFolder = baseDirectory + FolderNameLib + "\\" + FolderNameLog;
            Directory.CreateDirectory(logsFolder);
            FileNameLog = logsFolder + "\\" + this.GenerateFileName(".log");     
        }
    }
}
