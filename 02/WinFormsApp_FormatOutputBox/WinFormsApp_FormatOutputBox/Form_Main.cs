using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp_FormatOutputBox
{
    public partial class Form_Main : Form
    {
        private FormatOutputBox_GUI _outputBox = new FormatOutputBox_GUI();
        private int? _A = null; // переменные для ввода данных
        private int? _B = null; // "int?" в отличие от "int" позволяет задавать null
        private int _index = 0; // индекс операции
        public Form_Main()
        {
            InitializeComponent();
        }

        private void textBox_A_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (Int32.TryParse(textBox_A.Text, out value))
            {
                _A = value; // обновляем переменную класса, если парсинг выполнен
            }
            else
            {
                _A = null; // преобразование не было выполнено
            }
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {

        }

        private void listBox_Input_SelectedIndexChanged(object sender, EventArgs e)
        {
            _index = listBox_Input.SelectedIndex; // запоминаем выбранный индекс операции
            _outputBox.Invoke_Data(_index, ref pictureBox_Preview, ref richTextBox_Output); // инициализируем
        }

        private void button_Evaluate_Click(object sender, EventArgs e)
        {
            if (_A != null && _B != null)
            {
                _outputBox.Execute_Data(_A, _B);// выполняем действие в зависимости от выбранной операции
            }
        }

        private void textBox_B_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (Int32.TryParse(textBox_A.Text, out value))
            {
                _A = value; // обновляем переменную класса, если парсинг выполнен
            }
            else
            {
                _A = null; // преобразование не было выполнено
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            _outputBox.Clear_Data();
        }
    }
}
