using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication_LuckyTicket.lt_Evaluation
{
    public class Class_Parsing
    {
        /// <summary>
        /// Преобразует строку в short с значением по умолчанию при ошибке
        /// </summary>
        public static short StrToShortDef(string s, short @default)
        {
            if (short.TryParse(s, out short number))
                return number;
            return @default;
        }

        /// <summary>
        /// Преобразует long в массив из 6 цифр
        /// </summary>
        public static void ConvertLongToArray(long lg_value, ref short[] sh_array)
        {
            // Инициализация массива нулями
            Array.Clear(sh_array, 0, sh_array.Length);

            string str = lg_value.ToString();
            int length = Math.Min(str.Length, 6); // Ограничиваем 6 цифрами

            for (int i = 0; i < length; i++)
            {
                string str_digit = str[i].ToString();
                sh_array[i] = StrToShortDef(str_digit, 0);
            }
        }

        /// <summary>
        /// Форматирует число с ведущими нулями
        /// </summary>
        public static string ConvertLongToString(long lg_value, short sh_num_of_digits)
        {
            return lg_value.ToString($"D{sh_num_of_digits}");
        }
    }

    public class Class_Evaluating
    {
        // Константы для определения типа билета
        public const short DEF_LUCKY_TICKET = 1;
        public const short DEF_USUAL_TICKET = 0;
        public const short DEF_FAILED_TICKET = -1;

        // Константы для вариантов проверки
        public const short DEF_VARIANT_DEFAULT = 100;
        public const short DEF_VARIANT_TASK = 101;

        /// <summary>
        /// Возвращает сообщение по типу билета
        /// </summary>
        public static string GetMessageByLuckyValue(short sh_is_lucky)
        {
            switch (sh_is_lucky)
            {
                case DEF_LUCKY_TICKET:
                    return "Получен счастливый билет! :)";
                case DEF_USUAL_TICKET:
                    return "Получен обычный билет! :(";
                default:
                    return "Задан недопустимый номер билета!";
            }
        }

        /// <summary>
        /// Проверяет, является ли билет счастливым
        /// </summary>
        public static short IsHappyLucky(short[] arr, short sh_checked)
        {
            short sh_return = CheckInput(arr);
            if (sh_return == DEF_USUAL_TICKET)
            {
                return sh_checked == DEF_VARIANT_DEFAULT
                    ? RevealLucky_Default(arr)
                    : RevealLucky_Task(arr);
            }
            return sh_return;
        }

        /// <summary>
        /// Проверяет корректность введенных цифр
        /// </summary>
        private static short CheckInput(short[] arr)
        {
            for (int i = 0; i < 6; i++)
            {
                if (arr[i] < 0 || arr[i] > 9)
                    return DEF_FAILED_TICKET;
            }
            return DEF_USUAL_TICKET;
        }

        /// <summary>
        /// Проверка по варианту по умолчанию:
        /// Билет счастливый, если все цифры (кроме первой):
        /// 1. Четные ИЛИ делятся на 3
        /// 2. И равны первой цифре
        /// </summary>
        private static short RevealLucky_Default(short[] arr)
        {
            for (int i = 1; i < 6; i++)
            {
                bool condition = (arr[i] % 2 == 0 || arr[i] % 3 == 0) && (arr[i] == arr[0]);
                if (!condition)
                    return DEF_USUAL_TICKET;
            }
            return DEF_LUCKY_TICKET;
        }

        /// <summary>
        /// Проверка по индивидуальному варианту (пример для суммы цифр):
        /// Билет счастливый, если сумма первых 3 цифр равна сумме последних 3 цифр
        /// </summary>
        private static short RevealLucky_Task(short[] arr)
        {
            int sumFirstHalf = arr[0] + arr[1] + arr[2];
            int sumSecondHalf = arr[3] + arr[4] + arr[5];

            return sumFirstHalf == sumSecondHalf
                ? DEF_LUCKY_TICKET
                : DEF_USUAL_TICKET;
        }
    }
}