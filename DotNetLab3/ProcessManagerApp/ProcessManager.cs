using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ProcessManagerApp
{
    internal class ProcessManager
    {
        public Process[] GetProcesses()
        {
            return Process.GetProcesses();
        }

        public void KillProcess(int processId)
        {
            try
            {
                var process = Process.GetProcessById(processId);
                process.Kill();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error killing process: {ex.Message}");
            }
        }

        public void SetProcessPriority(int processId, ProcessPriorityClass priority)
        {
            try
            {
                var process = Process.GetProcessById(processId);
                process.PriorityClass = priority;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error setting priority: {ex.Message}");
            }
        }

        public void StartProgram(string programPath)
        {

            Process process =  Process.Start(programPath);
        }
    }
}
