using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using evaluate = WindowsFormsApplication_LuckyTicket.lt_Evaluation.Class_Evaluating;
using parse = WindowsFormsApplication_LuckyTicket.lt_Evaluation.Class_Evaluating;

namespace CS_CPP__Лаб_работа_14
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LuckyTicket());
        }
    }
}
