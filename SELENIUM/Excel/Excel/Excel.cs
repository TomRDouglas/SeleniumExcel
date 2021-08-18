using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Excel
{
    public partial class Excel : Form
    {

        DataTableCollection tableCollection;
        DataGridView dgvtests;
        StreamWriter logFileStream;
        String logFilePath;
        Int32 logLevel;

        //public static IWebDriver webdriver = new FirefoxDriver();
        public static IWebDriver webdriver = new ChromeDriver();

        public Excel()
        {
            InitializeComponent();
        }




        //======================================================== Locate and Open Excel Spread sheet
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter="Excel Workbook|*.xlsx"})
            {

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFileName.Text = openFileDialog.FileName;
                    try
                    {
                        using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            using (IExcelDataReader read = ExcelReaderFactory.CreateReader(stream))
                            {
                                DataSet result = read.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                                });
                                tableCollection = result.Tables;
                                cboSheet.Items.Clear();
                                foreach (DataTable table in tableCollection)
                                    cboSheet.Items.Add(table.TableName); //add sheet to combobox
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("File may be in use : " + txtFileName.Text, "Information");
                    }


                    
                }
            }
        }

//===================================================  Select Excel Worksheet and Initialise Tests
private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
            dataGridView1.DataSource = dt;
            dgvtests = dataGridView1;

            if ((dgvtests == null))
            {
                MessageBox.Show("DataSet Not valid", "cboSheet_SelectedIndexChanged");
                return;
            }
            InitialiseTests();
        }


        public void InitialiseTests()
        {
            if ((dgvtests.DataSource == null)) { return; }

            //// Header column names          
            int gridViewCellCount = dgvtests.Rows[0].Cells.Count; // Column count 18
            List<DataGridViewColumn> columnList = dgvtests.Columns.Cast<DataGridViewColumn>().ToList(); // Column List
            DataGridViewRow dgr = new DataGridViewRow();

            TestRec testrec = new TestRec();

            int rowCount = dgvtests.BindingContext[dgvtests.DataSource].Count;

            dgvtests.MultiSelect = false;
            for (int currentRow = 0; currentRow < rowCount; currentRow++)
            {
                dgvtests.Rows[currentRow].Cells[0].Selected = true;
                dgr = dgvtests.Rows[currentRow];
                testrec.setRec(dgr, columnList);

                if (testrec.CMD == "TESTS") break; //Initialiation ends

                if (testrec.CMD == "LOG" && testrec.SUBCMD == "START")
                {
                    if (testrec.ITEMURL != null)
                        {
                        this.logFilePath = testrec.ITEMURL;
                        this.logFileStream = File.AppendText(this.logFilePath);
                        if (!(testrec.IPARM1 == null))
                            logLevel = Convert.ToInt32(testrec.IPARM1);
                        else
                            logLevel = 1;
                        WriteLog(this.logFileStream, "=============================================", "");

                    }
                    else {
                        MessageBox.Show("No Log file path found","Initialise Tests");
                    }
                }

                if (logFileStream != null)
                {
                    if (Convert.ToInt32(testrec.TESTLOGLEVEL) <= logLevel)
                    {
                        WriteLog(logFileStream, String.Concat(testrec.SERIES, "  ", testrec.STEP, "  ", testrec.SUBSTEP, testrec.CMD, "  ", testrec.SUBCMD), "");
                    }
                }
            }
            CloseLog(logFileStream);
            return;
        }








        //======================================================== Display New Excel Spread sheet for saving
        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                int StartCol = 1;
                int StartRow = 1;
                int j = 0, i = 0;

                //Write Headers
                for (j = 0; j < dgvtests.Columns.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dgvtests.Columns[j].HeaderText;
                }

                StartRow++;

                //Write datagridview content
                for (i = 0; i < dgvtests.Rows.Count; i++)
                {
                    for (j = 0; j < dgvtests.Columns.Count; j++)
                    {
                        try
                        {
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                            myRange.Value2 = dgvtests[j, i].Value == null ? "" : dgvtests[j, i].Value;
                        }
                        catch
                        {
                            ;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
       


 
         private TestRec getTestRec(Int32 targetrec)
        {
            List<DataGridViewColumn> columnList = dgvtests.Columns.Cast<DataGridViewColumn>().ToList(); // Column List
            DataGridViewRow dgr = new DataGridViewRow();
            TestRec testrec = new TestRec();          
            if (targetrec < dgvtests.RowCount - 1)
            {
                dgr = dgvtests.Rows[targetrec];
                testrec.setRec(dgr, columnList);
            }
            return testrec;
        }


        private void Close_Click(object sender, EventArgs e)
        {
            TestRec testrec = new TestRec();
            Exectests executeTests = new Exectests();
            testrec.CMD = "KILL";
            executeTests.runTest(webdriver, testrec);

            CloseLog(logFileStream);
            this.Close();
        }


        //================================================================= Logging
        private StreamWriter OpenLog(String filePath)  
        {
            StreamWriter sw = File.AppendText(filePath);
            return sw;
        }

         private void WriteLog(StreamWriter fileStream, String errObject, String logMessage)
        {
            errObject = String.Concat(DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture), " - ",errObject ," > ",logMessage);
            fileStream.WriteLineAsync(errObject);
        }
        private void CloseLog(StreamWriter fileStream)
        {
            if (fileStream != null)            
                fileStream.Close();
        }

        private void Log(String message)
        {
            logFileStream = OpenLog(logFilePath);

            if (logFileStream != null){
                WriteLog(logFileStream, message, "");
                CloseLog(logFileStream);
            }           
        }

        //============================================================== Locate test line
        private Int32 GotoNext()
        {
            int currentRow = dgvtests.CurrentCell.RowIndex;
            if (currentRow < dgvtests.RowCount - 1)
            {
                dgvtests.Rows[++currentRow].Cells[0].Selected = true;
            }
            return dgvtests.CurrentCell.RowIndex;
        }

        private Int32 GotoPrev()
        {
            int currentRow = dgvtests.CurrentCell.RowIndex;
            if (currentRow > 0)
            {
                dgvtests.Rows[--currentRow].Cells[0].Selected = true;
            }
            return dgvtests.CurrentCell.RowIndex; 
        }


        public Int32 GotoStep(String gSTEP,String gSUBSTEP)
        {
            if ((dgvtests.DataSource == null)) { return -1; }

            int rowCount = dgvtests.BindingContext[dgvtests.DataSource].Count;
            //// Header column names          
            int gridViewCellCount = dgvtests.Rows[0].Cells.Count; // Column count
            List<DataGridViewColumn> columnList = dgvtests.Columns.Cast<DataGridViewColumn>().ToList(); // Column List
            DataGridViewRow dgr = new DataGridViewRow();
            TestRec testrec = new TestRec();

            dgvtests.MultiSelect = false;
            for (int currentRow = 0; currentRow < rowCount; currentRow++)
            {
                dgvtests.Rows[currentRow].Cells[0].Selected = true;
                dgr = dgvtests.Rows[currentRow];
                testrec.setRec(dgr, columnList);

                if ((!(gSTEP == null)) && (!(gSUBSTEP == null))){
                    if (testrec.STEP == gSTEP && testrec.SUBSTEP == gSUBSTEP)  {
                        Log( "=Moved To=" + gSTEP + ":" + gSUBSTEP);
                        return currentRow;
                    }                                                 
                }

                if ((!(gSTEP == null)) && (!(gSUBSTEP != null)))
                {
                    if (testrec.STEP == gSTEP){
                        Log("=Moved To=" + gSTEP);
                        return currentRow;
                    }
                    
                }
            }
            Log( "=Moved Not Found=" + gSTEP);
            return -1;
        }

        public Int32 GotoCMD(String gCMD, String gSUBCMD)
        {
            if ((dgvtests.DataSource == null)) { return -1; }

            int rowCount = dgvtests.BindingContext[dgvtests.DataSource].Count;
            //// Header column names          
            int gridViewCellCount = dgvtests.Rows[0].Cells.Count; // Column count
            List<DataGridViewColumn> columnList = dgvtests.Columns.Cast<DataGridViewColumn>().ToList(); // Column List
            DataGridViewRow dgr = new DataGridViewRow();
            TestRec testrec = new TestRec();

            dgvtests.MultiSelect = false;
            for (int currentRow = 0; currentRow < rowCount; currentRow++)
            {
                dgvtests.Rows[currentRow].Cells[0].Selected = true;
                dgr = dgvtests.Rows[currentRow];
                testrec.setRec(dgr, columnList);

                if ((!(gCMD == null)) && (!(gSUBCMD == null)))
                {
                    if (testrec.CMD == gCMD && testrec.SUBCMD == gSUBCMD)
                    {
                        Log("=Moved To=" + gCMD + ":" + gSUBCMD);
                        return currentRow;
                    }
                }

                if ((!(gCMD == null)) && (!(gSUBCMD != null)))
                {
                    if (testrec.CMD == gCMD)
                    {
                        Log("=Moved To=" + gCMD);
                        return currentRow;
                    }

                }
            }
            Log("=Moved Not Found=" + gCMD);
            return -1;
        }


        //======================================================== Itterate Through Tests
        private Int32 Run_Tests(Int32 run_from, String run_to, String mode)
        {
            Int32 startPoint = 0;

            TestRec testrec = new TestRec();
            ResultRec resultrec = new ResultRec();
            
            Exectests executeTests = new Exectests();


            if ((dgvtests.DataSource == null))
            {
                Log("=Run_Tests=" + " Null Dataset");
                return -1;
            }

            Int32 retRow = -1;
            //// Header column names   
            int rowCount = dgvtests.BindingContext[dgvtests.DataSource].Count;
            List<DataGridViewColumn> columnList = dgvtests.Columns.Cast<DataGridViewColumn>().ToList(); // Column List
            DataGridViewRow dgr = new DataGridViewRow();

            dgvtests.MultiSelect = false;
            for (int currentRow = run_from; currentRow < rowCount; currentRow++)
            {
                dgr = dgvtests.Rows[dgvtests.CurrentCell.RowIndex];
                testrec.setRec(dgr, columnList);
                Log("=Moved To= STEP:" + testrec.STEP.ToString() + " SUBSTEP:" + testrec.SUBSTEP.ToString() + testrec.CMD.ToString() + " SUBCMD:" + testrec.SUBCMD.ToString());

                resultrec = executeTests.runTest(webdriver,testrec);

                if ((testrec.CMD == "ASSERT" || testrec.SUBCMD == "ASSERT") && resultrec.RESULT == "OK")
                {
                    dataGridView1.Rows[dgvtests.CurrentCell.RowIndex].Cells[0].Style.BackColor = Color.LightGreen;
                    changeCurrentCellText("", "RESULT");
                }
                if ((testrec.CMD == "ASSERT" || testrec.SUBCMD == "ASSERT") && resultrec.RESULT == "ERROR")
                {
                    dataGridView1.Rows[dgvtests.CurrentCell.RowIndex].Cells[0].Style.BackColor = Color.Red;
                    changeCurrentCellText(resultrec.RESULTMESSAGE, "RESULT");
                }
                
                if (resultrec.RESULT != "OK") {
                    dataGridView1.Rows[dgvtests.CurrentCell.RowIndex].Cells[1].Style.BackColor = Color.LightGray;
                    dataGridView1.Rows[dgvtests.CurrentCell.RowIndex].Cells[2].Style.BackColor = Color.LightGray;
                } else {
                    dataGridView1.Rows[dgvtests.CurrentCell.RowIndex].Cells[1].Style.BackColor = Color.LightGray;
                    dataGridView1.Rows[dgvtests.CurrentCell.RowIndex].Cells[2].Style.BackColor = Color.LightGray;         
                }

                if (mode == "RUN")
                {
                    //Continue to end or Breakpoint
                    if (testrec.CMD.ToString() == "BREAKPOINT")
                    {
                        Log("=Moved To= STEP:" + testrec.STEP.ToString() + " SUBSTEP:" + testrec.SUBSTEP.ToString() + testrec.CMD.ToString() + " SUBCMD:" + testrec.SUBCMD.ToString());
                        break;
                    }
                    if (mode == "RUNTO")
                    {
                        if (testrec.STEP.ToString() == run_to)
                        {
                            Log("=Moved To= STEP:" + testrec.STEP.ToString() + " SUBSTEP:" + testrec.SUBSTEP.ToString() + testrec.CMD.ToString() + " SUBCMD:" + testrec.SUBCMD.ToString());
                            break;
                        }

                        Log("=Moved To= STEP:" + testrec.STEP.ToString() + " SUBSTEP:" + testrec.SUBSTEP.ToString() + testrec.CMD.ToString() + " SUBCMD:" + testrec.SUBCMD.ToString());
                        break;
                    }

                }
                if (mode == "STEP")
                {
                    Log("=Moved To= STEP:" + testrec.STEP.ToString() + " SUBSTEP:" + testrec.SUBSTEP.ToString() + testrec.CMD.ToString() + " SUBCMD:" + testrec.SUBCMD.ToString());
                    break;
                }


           retRow = GotoNext();
                if (retRow == -1)
                {
                    Log("=Run_Tests=GotoNext() Fail" + " from:" + currentRow.ToString());
                    MessageBox.Show("=Run_Tests=GotoNext() Fail" + " from:" + currentRow.ToString(), "=Run_Tests=");
                    return -1;
                }

            }
            return retRow;
        }

        //-======================================================= User Controls
        private void Restart_Click(object sender, EventArgs e)
        {
            //Int32 currentRow = GotoCMD("TESTS", null);
            Int32 currentRow = GotoCMD("TESTS", null);
            String run_to = "";
            String mode = "RUN";
            Log("=Restart_Click=");
            if (currentRow > 0)
            {
                Run_Tests(currentRow, run_to, mode);
            }
        }

        private void continue_Click(object sender, EventArgs e)
        {
            Int32 currentRow = -1;
            currentRow = GotoNext();
            dgvtests.Rows[currentRow].Cells[0].Selected = true;

            String run_to = "";
            String mode = "RUN";
            Log("=Continue_Click=");
            if (currentRow > 0)
            {
                Run_Tests(currentRow, run_to, mode);
            }
        }

        private void step_Click(object sender, EventArgs e)
        {
            Int32 currentRow = -1;
            currentRow = GotoNext();
            dgvtests.Rows[currentRow].Cells[0].Selected = true;
            String run_to = "";
            String mode = "STEP";
            Log("=Step_Click=");
            if (currentRow > 0)
            {
                Run_Tests(currentRow, run_to, mode);
            }
        }

        //=========================== DataViewGrid Mouse
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
               contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            String myCellValue;

            //handle the row selection on right click
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    dgvtests.CurrentCell = dgvtests.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // Can leave these here - doesn't hurt
                    dgvtests.Rows[e.RowIndex].Selected = true;
                    dgvtests.Focus();

                    myCellValue = Convert.ToString(dgvtests.Rows[e.RowIndex].Cells[1].Value);
                }
                catch (Exception)
                {

                }
            }
        }

        //=========================== Context Menu Mouse
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string itemText = e.ClickedItem.Text;
        }

        
        private void removeBreakPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = dgvtests.DataSource as DataTable;
            DataRow[] rows = dt.Select("STEP='BREAKPOINT'");

            for (int i = 0; i < rows.Length; i++)
                rows[i].Delete();
            dt.AcceptChanges();
        }

        private void insertLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<DataGridViewColumn> columnList = dgvtests.Columns.Cast<DataGridViewColumn>().ToList(); // Column List
            int currentRow = dgvtests.CurrentCell.RowIndex;
            DataGridViewRow dgr = dgvtests.Rows[2];
            String SERIES = Convert.ToString(dgr.Cells[columnList.FindIndex(c => c.HeaderText == "SERIES")].Value);
            DataTable dt = dgvtests.DataSource as DataTable;
            DataRow R = dt.NewRow();
            dt.Rows.InsertAt(R, currentRow);
            R["SERIES"] = SERIES;
        }

        private void removeLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<DataGridViewColumn> columnList = dgvtests.Columns.Cast<DataGridViewColumn>().ToList(); // Column List
            int currentRow = dgvtests.CurrentCell.RowIndex;
            DataGridViewRow dgr = dgvtests.Rows[currentRow];
            String STEP = Convert.ToString(dgr.Cells[columnList.FindIndex(c => c.HeaderText == "STEP")].Value);
            String SUBSTEP = Convert.ToString(dgr.Cells[columnList.FindIndex(c => c.HeaderText == "SUBSTEP")].Value);

            DataTable dt = dgvtests.DataSource as DataTable;
            DataRow[] rows = null;
            if (string.IsNullOrEmpty(SUBSTEP))
            {
                rows = dt.Select("STEP='" + STEP + " '" );
            }
            else {
                rows = dt.Select("STEP='" + STEP + " '" + " AND " + "SUBSTEP='" + SUBSTEP + "' ");
            }
            
            for (int i = 0; i < rows.Length; i++)
                rows[i].Delete();
            dt.AcceptChanges();
        }

        private void insertBreakPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<DataGridViewColumn> columnList = dgvtests.Columns.Cast<DataGridViewColumn>().ToList(); // Column List
            int currentRow = dgvtests.CurrentCell.RowIndex;
            DataGridViewRow dgr = dgvtests.Rows[2];
            String SERIES = Convert.ToString(dgr.Cells[columnList.FindIndex(c => c.HeaderText == "SERIES")].Value);
            DataTable dt = dgvtests.DataSource as DataTable;
            DataRow R = dt.NewRow();
            dt.Rows.InsertAt(R, currentRow );
            R["SERIES"] = SERIES;
            R["CMD"] = "BREAKPOINT";
        }

        private void appendLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = dgvtests.DataSource as DataTable;
            DataRow R = dt.Rows.Add(); 
            R["SERIES"] =  dt.Rows[2]["SERIES"].ToString();
        }


        private void changeCurrentCellText(String newText, String cell)
        {
            int currentRow = dgvtests.CurrentCell.RowIndex;
            DataTable dt = dgvtests.DataSource as DataTable;
            DataRow row = dt.Rows[currentRow];
            row[cell] = newText;
        }
    }
}
