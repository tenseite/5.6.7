using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace WinFormsApp_FormatOutputBox
{
    interface IFormatOutputBox // перечень функций, назначаемых для форматного вывода данных
    {
        bool Load_Invoking(ref RichTextBox lbox, ref PictureBox picbox);
        bool Run_Executing(int? a, int? b, ref RichTextBox lbox);
    }
    public class FormatOutputBox_GUI // класс форматного вывода, содержащий ссылки на графические и текстовые объекты
    {
        // 1. Public data
        public enum operations // перечень операций
        {
            None = 0,
            SimpleSum, // = 1, т.к. в перечислимом типе значения по умолчанию увеличиваются на 1
            SimpleMult // = 2
        };
        // 2. Private data
        private int _sel_operation = (int)operations.None; // номер действия в списке: по умолчанию № 0
        private PictureBox _picturePreview = null; // объект картинки для превью
        private RichTextBox _consoleExample = null; // объект сымитированной консоли
        private List<IFormatOutputBox> _operations = new List<IFormatOutputBox>(); // список операций
                                                                                   // 3. Public Methods
        public FormatOutputBox_GUI()
        {
            foreach (operations i in Enum.GetValues(typeof(operations))) // заполняем список операций
            {
                switch(i) // здесь необходимо заполнить список всех используемых операций в порядке их перечисления
                {
                    case operations.None:
                        _operations.Add(new FormatOutputBox_Handling.Operation_None());
                        break;
                    case operations.SimpleSum:
                        _operations.Add(new FormatOutputBox_Handling.Operation_SimpleSum());
                        break;
                    case operations.SimpleMult:
                        _operations.Add(new FormatOutputBox_Handling.Operation_SimpleMult());
                        break;
                }
            }
        }
        // запоминаем данные форматного вывода: номер операции, объект превью, объект консоли
        public bool Invoke_Data(int sel_operation, ref PictureBox picturePreview, ref RichTextBox
  consoleExample)
        {
            _sel_operation = sel_operation;
            _picturePreview = picturePreview;
            _consoleExample = consoleExample; // запоминаем объекты
            Clear_Data(); // очищаем полученную консоль
            _operations[_sel_operation].Load_Invoking(ref _consoleExample, ref _picturePreview); // уведомляем пользователя
            return true;
        }
        // запоминаем данные форматного вывода: номер операции, объект превью, объект консоли
        public bool Execute_Data(int? a, int? b)
        {  // благодаря интерфейсу имитируется механизм виртуализации: функция вызывается в зависимости от _sel_operation
                     _operations[_sel_operation].Run_Executing(a, b, ref _consoleExample); // выполняем операцию номер _sel_operation
           return true;
        }
        // очистка имитированной консоли
        public void Clear_Data()
        {
            _consoleExample.Clear(); // очищаем полученную консоль
        }
    }
}