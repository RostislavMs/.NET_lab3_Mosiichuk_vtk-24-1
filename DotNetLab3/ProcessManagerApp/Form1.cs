using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessManagerApp
{
    public partial class Form1 : Form
    {
        private Process selectedProcess;
        private ProcessManager processManager = new ProcessManager();
        public Form1()
        {
            InitializeComponent();
            LoadProcesses();
            ProcessGridView.SelectionChanged += ProcessGridView_SelectionChanged;
        }
        private void LoadProcesses()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Process Name");
            dt.Columns.Add("Process ID");
            dt.Columns.Add("Working Set");
            dt.Columns.Add("Start Time");
            dt.Columns.Add("Priority");
            dt.Columns.Add("Thread Count");

            foreach (var process in processManager.GetProcesses())
            {
                try
                {
                    string workingSet = process.WorkingSet64.ToString();
                    string startTime = process.StartTime.ToString();
                    string priorityClass = process.PriorityClass.ToString();
                    string threadCount = process.Threads.Count.ToString();

                    if (process.StartTime == default)
                        startTime = "N/A";

                    if (process.WorkingSet64 == 0)
                        workingSet = "N/A";

                    dt.Rows.Add(process.ProcessName, process.Id, workingSet, startTime, priorityClass, threadCount);
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine($"Access denied to process {process.ProcessName} with ID {process.Id}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error accessing process {process.ProcessName}: {ex.Message}");
                }
            }

            ProcessGridView.DataSource = dt;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            PriorityComboBox.Items.Add(ProcessPriorityClass.Idle);
            PriorityComboBox.Items.Add(ProcessPriorityClass.BelowNormal);
            PriorityComboBox.Items.Add(ProcessPriorityClass.Normal);
            PriorityComboBox.Items.Add(ProcessPriorityClass.AboveNormal);
            PriorityComboBox.Items.Add(ProcessPriorityClass.High);
            PriorityComboBox.Items.Add(ProcessPriorityClass.RealTime);

            PriorityComboBox.SelectedIndex = 2;
        }


        private void ProcessGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ProcessGridView.SelectedRows.Count > 0)
            {
                var selectedRow = ProcessGridView.SelectedRows[0];

                var processIdCellValue = selectedRow.Cells["Process ID"].Value;

                if (processIdCellValue != null && int.TryParse(processIdCellValue.ToString(), out int processId))
                {
                    selectedProcess = Process.GetProcessById(processId);
                }
                else
                {
                    MessageBox.Show("Invalid Process ID.");
                }
            }
        }

        private void KillProcessButton_Click(object sender, EventArgs e)
        {
            if (selectedProcess != null)
            {
                try
                {
                    processManager.KillProcess(selectedProcess.Id);
                    LoadProcesses();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error killing process: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a process to kill.");
            }
        }

        private void SetPriorityButton_Click(object sender, EventArgs e)
        {
            if (selectedProcess != null && PriorityComboBox.SelectedItem != null)
            {
                try
                {
                    var priority = (ProcessPriorityClass)Enum.Parse(typeof(ProcessPriorityClass), PriorityComboBox.SelectedItem.ToString());
                    processManager.SetProcessPriority(selectedProcess.Id, priority);
                    LoadProcesses();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error setting priority: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a process and priority.");
            }
        }

        private void StartCalculatorButton_Click(object sender, EventArgs e)
        {
            processManager.StartProgram("calc.exe");
        }



        private void startWordBtn_Click(object sender, EventArgs e)
        {
            processManager.StartProgram("winword.exe");

        }

        private void startExelBtn_Click(object sender, EventArgs e)
        {
            processManager.StartProgram("excel.exe");
        }

        private void startChromeBtn_Click(object sender, EventArgs e)
        {
            processManager.StartProgram("chrome.exe");
        }

        private void startPaintBtn_Click(object sender, EventArgs e)
        {
            processManager.StartProgram("mspaint.exe");
        }
    }
}
