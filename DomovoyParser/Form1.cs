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

using ExcelLibrary.SpreadSheet;

using Prizmer.Meters;
using Prizmer.Meters.iMeters;


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

            numResponseTimeout.Value = 8;

            BatchConnectionList = new List<BatchConnection>();

            this.Text = formCaptionStringBase;
            stopBtn.Enabled = false;

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

        sayani_kombik sayaniKombik = new sayani_kombik();
        Prizmer.Ports.VirtualPort sayaniKombikVirtualPort = null;

        //форма генерации *.bat файла
        FormConnPrms connectionParamForm = new FormConnPrms();

        OpenFileDialog openFileDialog;
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

        FileStream fStreamDump;


        DataTable dt = new DataTable("meters");
        public string worksheetName = "Лист1";

        //список, хранящий номера параметров в перечислении Params драйвера
        //целесообразно его сделать здесь, так как кол-во считываемых значений зависит от кол-ва колонок
        List<int> paramCodes = null;
        private void createMainTable(ref DataTable dt)
        {
            paramCodes = new List<int>();

            //creating columns for internal data table
            DataColumn column = dt.Columns.Add();

            column.DataType = typeof(string);
            column.Caption = "S/N";
            column.ColumnName = "colFactory";

            column = dt.Columns.Add();
            column.DataType = typeof(string);
            column.Caption = "Q1 (МДж)";
            column.ColumnName = "colEnergy1";
            paramCodes.Add(1);
            column = dt.Columns.Add();
            column.DataType = typeof(string);
            column.Caption = "Q2 (МДж)";
            column.ColumnName = "colEnergy2";
            paramCodes.Add(2);

            column = dt.Columns.Add();
            column.DataType = typeof(string);
            column.Caption = "M1 (кг)";
            column.ColumnName = "colMass1";
            paramCodes.Add(3);

            column = dt.Columns.Add();
            column.DataType = typeof(string);
            column.Caption = "M2 (кг)";
            column.ColumnName = "colMass2";
            paramCodes.Add(4);

            column = dt.Columns.Add();
            column.DataType = typeof(string);
            column.Caption = "M3 (кг)";
            column.ColumnName = "colMass3";
            paramCodes.Add(5);

            column = dt.Columns.Add();
            column.DataType = typeof(string);
            column.Caption = "M4 (кг)";
            column.ColumnName = "colMass4";
            paramCodes.Add(6);

            column = dt.Columns.Add();
            column.DataType = typeof(string);
            column.Caption = "T1 (*C)";
            column.ColumnName = "colTemp1";
            paramCodes.Add(7);

            column = dt.Columns.Add();
            column.DataType = typeof(string);
            column.Caption = "T2 (*C)";
            column.ColumnName = "colTemp2";
            paramCodes.Add(8);

            column = dt.Columns.Add();
            column.DataType = typeof(string);
            column.Caption = "T3 (*C)";
            column.ColumnName = "colTemp3";
            paramCodes.Add(9);

            column = dt.Columns.Add();
            column.DataType = typeof(string);
            column.Caption = "T4 (*C)";
            column.ColumnName = "colTemp4";
            paramCodes.Add(10);

            DataRow captionRow = dt.NewRow();
            for (int i = 0; i < dt.Columns.Count; i++)
                captionRow[i] = dt.Columns[i].Caption;
            dt.Rows.Add(captionRow);

        }

        private void fillTableWithStartData(List<BatchConnection> bcList)
        {
            try
            {
                Workbook book = new Workbook();
                book.Worksheets.Add(new Worksheet("Лист 1"));

                //auto detection of working mode
                object typeDirectiveVal = "";

                try
                {
                    Row zeroRow = book.Worksheets[0].Cells.GetRow(0);
                    typeDirectiveVal = zeroRow.GetCell(0).Value;
                }
                catch (Exception ex)
                {
                    return;
                }

                dt = new DataTable();
                createMainTable(ref dt);

                int rowsInFile = bcList.Count;

                //filling internal data table with *.xls file data according to *.config file
                for (int i = 0; i < 1; i++)
                {
                    Worksheet sheet = book.Worksheets[i];

                    for (int rowIndex = 0; rowIndex < rowsInFile; rowIndex++)
                    {
                        DataRow dataRow = dt.NewRow();
                        dataRow[0] = bcList[rowIndex].SerialNumberDec2Bytes;

                        for (int j = 1; j < dt.Columns.Count; j++)
                            dataRow[j] = "";

                        dt.Rows.Add(dataRow);
                    }
                }

                dgv1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проблемы с формированием таблицы для dgv1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region Разбор дампа

        private int GiveMeNextValue(FileStream fs, int valBytesCount)
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

        private bool FillRowWithValues(Params prms, DataTable dt, int rowIndex, bool FillWithEmptyVals = false)
        {
            try
            {
                List<float> prmsList = new List<float>();

                if (!FillWithEmptyVals)
                {
                    prmsList.Add(prms.Q[0]);
                    prmsList.Add(prms.Q[1]);

                    prmsList.Add(prms.M[0]);
                    prmsList.Add(prms.M[1]);
                    prmsList.Add(prms.M[2]);
                    prmsList.Add(prms.M[3]);

                    prmsList.Add(prms.T[0]);
                    prmsList.Add(prms.T[1]);
                    prmsList.Add(prms.T[2]);
                    prmsList.Add(prms.T[3]);
                }

                for (int i = 1; i < dt.Columns.Count; i++)
                    dt.Rows[rowIndex][i] = prmsList[i - 1];


                dgv1.DataSource = dt;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void PrintLastRecord(int bytesFromTheEnd, bool bClearBefore = true, DataTable dt = null, int rowIndex = -1)
        {
            if (fStreamDump != null)
            {
                if (bClearBefore) richTextBox1.Clear();

                Params prms = new Params();

                richTextBox1.Text += String.Format("***[ S/N: {0} ]***\n", tmpMeterInfo.serialNumber);

                string strRepresentation = "";
                if (!sayaniKombik.GetParamValues(fStreamDump, bytesFromTheEnd, ref prms, ref strRepresentation))
                    richTextBox1.Text += "Ошибка разбора дампа\n";

                richTextBox1.Text += strRepresentation;

                //добавим в таблицу строку
                if (dt != null && rowIndex != -1)
                {
                    FillRowWithValues(prms, dt, rowIndex);
                    dgv1.DataSource = dt;
                }


                if (!bClearBefore)
                    richTextBox1.Text += "\n";
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
        private bool loadDumpFile(string filename, bool doDumpMode = true)
        {
            fStreamDump = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);

            if (GetMeterInfo(fStreamDump, ref tmpMeterInfo))
            {
                if (doDumpMode)
                {
                    PrintLastRecord((int)numericUpDown1.Value);
                    InitDumpReaderMode(filename);
                }
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
                    BatchFileExecutionEnd_EventHandler(null, new EventArgs());
                    return;
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

               this.Invoke((MethodInvoker)delegate()
               {
                   timerProgressBar.Maximum = (int)numResponseTimeout.Value;
                   timerProgressBar.Value = 0;
               });

               for (int t = 0; t < (int)numResponseTimeout.Value; t++)
               {
                   if (StopFlag)
                   {
                       BatchFileExecutionEnd_EventHandler(null, new EventArgs());
                       return;
                   } 

                   Thread.Sleep(1000);

                   this.Invoke((MethodInvoker)delegate()
                   {
                       ++timerProgressBar.Value;
                   });

               }

                if (File.Exists(bConn.FileNameDump))
                {
                    if (loadDumpFile(bConn.FileNameDump, false))
                    {
                        this.Invoke((MethodInvoker)delegate()
                        {
                            PrintLastRecord((int)numericUpDown1.Value, false, dt, i);
                            PrintMsg("\n");
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
            Delegate del = (MethodInvoker)delegate()
            {
                ClearScreen();
                ResetGUIParams();

                this.Text = formCaptionStringBase + formCaptionMultiBatchMode + formCaptionBatExecution;
                grBoxBat.Enabled = false;
                grBoxDump.Enabled = false;
                stopBtn.Enabled = true;
                fileCnt = 1;
            };

            this.Invoke(del);
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

        public void BatchFileExecutionEnd_EventHandler(object sender, EventArgs e)
        {

            Delegate del = (MethodInvoker)delegate()
            {
                ResetGUIParams();

                this.Text = formCaptionStringBase + formCaptionMultiBatchMode;
                grBoxBat.Enabled = true;
                stopBtn.Enabled = false;

                string buf = richTextBox1.Text;
                richTextBox1.Clear();
                richTextBox1.Text += "*** ОПРОС ЗАВЕРШЕН ***\n\n";
                richTextBox1.Text += buf;

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

                    fillTableWithStartData(batchConnectionList);
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

        private void ResetGUIParams()
        {
            tsLblCurrentFile.Text = "0";

            int batchFilesCount = 0;
            if (BatchConnectionList != null && BatchConnectionList.Count > 0)
                batchFilesCount = BatchConnectionList.Count;
            else
                batchFilesCount = 0;

            tsLblTotalFiles.Text = batchFilesCount.ToString();
            toolStripProgressBar1.Maximum = batchFilesCount;
            toolStripProgressBar1.Value = 0;

            timerProgressBar.Value = 0;
            timerProgressBar.Maximum = (int)numResponseTimeout.Value;

            stopBtn.Enabled = false;
        }

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

            StartExecutingThread(tmpBatchConnList);
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
            if (ExecutingThread != null && ExecutingThread.IsAlive)
            {
                StopFlag = true;
                richTextBox1.Text += "\nОпрос остановится через несколько секунд\n";
            }
        }

        private void numResponseTimeout_ValueChanged(object sender, EventArgs e)
        {
            int val = (int)((NumericUpDown)sender).Value;

            timerProgressBar.Value = 0;
            timerProgressBar.Maximum = val;
        }
        
        #endregion

        #region Тест функционала драйвера

        private void btnReadCurrent_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            sayaniKombik.Init(uint.Parse(tbSerial.Text), tbPass.Text, sayaniKombikVirtualPort);

            float val = -1;
            if (sayaniKombik.ReadCurrentValues((ushort)numP.Value, (ushort)numT.Value, ref val))
                richTextBox1.Text = "Получено значение: " + val.ToString();
        }

        private void btnReadDaily_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            sayaniKombik.Init(uint.Parse(tbSerial.Text), tbPass.Text, sayaniKombikVirtualPort);

            float val = -1;
            if (sayaniKombik.ReadDailyValues(DateTime.Now.Date, (ushort)numP.Value, (ushort)numT.Value, ref val))
                richTextBox1.Text = "Получено новое значение: " + val.ToString();
            else
                richTextBox1.Text = "Не удалось получить новое значение, возможно с момента последнего опроса не прошло " + tbPass.Text + " дней";

        }

        SaveFileDialog sfd1 = new SaveFileDialog();
        private void tsExportBtn_Click(object sender, EventArgs e)
        {
            if (sfd1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //create new xls file
                string file = sfd1.FileName;
                Workbook workbook = new Workbook();
                Worksheet worksheet = new Worksheet(worksheetName);

                //office 2010 will not open file if there is less than 100 cells
                for (int i = 0; i < 100; i++)
                    worksheet.Cells[i, 0] = new Cell("");

                //copying data from data table
                for (int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < dt.Columns.Count; colIndex++)
                    {
                        worksheet.Cells[rowIndex, colIndex] = new Cell(dt.Rows[rowIndex][colIndex].ToString());
                    }
                }

                workbook.Worksheets.Add(worksheet);
                workbook.Save(file);
            }
        }

        #endregion
    }

}
