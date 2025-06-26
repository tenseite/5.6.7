using System;
using System.Drawing;
using System.Windows.Forms;
namespace WinFormsApp_FormatOutputBox
{
    class FormatOutputBox_Handling // класс форматного вывода, содержащий алгоритмы обработки
    {
        // 0. <None> //////////////////////////////////////////////////////////////////////
        public class Operation_None : IFormatOutputBox
        {
            //##############################################################################
            public bool Load_Invoking(ref RichTextBox consoleOut, ref PictureBox pic) //####
            {  // получаем имя текущего класса и загружаем по имени этого ресурса
                string str_class_name = this.GetType().Name; // ресурс с таким именем должен существовать!
               pic.Image = (Image)Properties.Resources.ResourceManager.GetObject(str_class_name);
                consoleOut.AppendText("Инициализировано действие \"0\".");
                return true;
            }
            //##############################################################################
            public bool Run_Executing(int? a, int? b, ref RichTextBox consoleOut) //##########
            {
                string str = String.Format("\nВыполнение действия \"0\"");
                return true;
            }
            //##############################################################################
        }
        // 1. <SimpleSum> /////////////////////////////////////////////////////////////////
        public class Operation_SimpleSum : IFormatOutputBox
        {
            //##############################################################################
            public bool Load_Invoking(ref RichTextBox consoleOut, ref PictureBox pic) //####
            {  // получаем имя текущего класса и загружаем по имени этого ресурса
                string str_class_name = this.GetType().Name; // ресурс с таким именем должен существовать!
               pic.Image = (Image)Properties.Resources.ResourceManager.GetObject(str_class_name);
                consoleOut.AppendText("Инициализировано действие \"1\"!");
                return true;
            }
            //##############################################################################
            public bool Run_Executing(int? a, int? b, ref RichTextBox consoleOut) //##########
            {  // если под каждую подстановку резервируется 3 символа: {0,3} + {1,3} + {2,3}
                string str = String.Format("\nВыполнение действия \"1\":\n{0} + {1} = {2}", a, b, a + b);
                consoleOut.AppendText(str); // форматный вывод строки
                return true;
            }
            //##############################################################################
        }
        // 2. <SimpleMult> /////////////////////////////////////////////////////////////////
        public class Operation_SimpleMult : IFormatOutputBox
        {
            //##############################################################################
            public bool Load_Invoking(ref RichTextBox consoleOut, ref PictureBox pic) //####
            {  // получаем имя текущего класса и загружаем по имени этого ресурса
                string str_class_name = this.GetType().Name; // ресурс с таким именем должен существовать!
               pic.Image = (Image)Properties.Resources.ResourceManager.GetObject(str_class_name);
                consoleOut.AppendText("Инициализировано действие \"2\"!");
                return true;
            }
            //##############################################################################
            public bool Run_Executing(int? a, int? b, ref RichTextBox consoleOut) //##########
            {  // если под каждую подстановку резервируется 4 символа: {0,4} * {1,4} + {2,4}
                string str = String.Format("\nВыполнение действия \"2\":\n{0} * {1} = {2}", a, b, a * b);
                consoleOut.AppendText(str);
                return true;
            }
            //##############################################################################
        }
    }
}