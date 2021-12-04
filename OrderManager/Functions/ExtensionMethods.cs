using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManager.Functions
{
    static class ExtensionMethods
    {
        public static double RoundUpDown(double input) //Round tới 1000d
        {
            double temp = input % 1000; // ex: 13050 -> temp = 50
            if(temp < 100)
            {
                input -= temp;
            }
            else
            {
                input = input - temp + 1000;
            }
            return input;
        }
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }

        public static void ErrorOutput(string error)
        {
            string path = AppContext.BaseDirectory;
            string text = "";
            try
            {
                text = File.ReadAllText(path + @"\ErrorLog.txt");
            }
            catch
            {

            }
            string errorDetail = DateTime.Today.ToString() + "\n" + error;
            File.WriteAllText("ErrorLog.txt", errorDetail + "\n" + text);
        }
    }
}
