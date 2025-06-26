using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.Xml.Linq;
namespace WinForms_SaveLoadFragments
{
    class ArrayPictures
    {
        private Bitmap _bmp_picture; // все изображение в bmp‐формате 
        private Size _size_picture; // размер изображения 
        private PictureBox[] _pictures = null; // 1‐мерный массив хранимых фрагментов изображения 
        private int _count_str; // число изображений по горизонтали 
        private int _count_col; // число изображений по вертикали 

        public ArrayPictures(Control parent_control, Bitmap bmp_picture, Size size_picture,
            int count_str, int count_col)
        {
            _count_str = count_str; // инициализируем внутренние переменные 
            _count_col = count_col;
            _pictures = new PictureBox[count_str * count_col];
            _bmp_picture = bmp_picture;
            _size_picture = size_picture;

            for (int i_w = 0; i_w < _count_col; i_w++) // цикл по индексам по горизонтали 
                for (int i_h = 0; i_h < _count_str; i_h++) // подцикл по индексам по вертикали 
                {   // координаты копируемого фрагмента 
                    int index = Get_Real_Index(i_w, i_h); // получаем реальный индекс 
                    _pictures[index] = new PictureBox();// распределяем память под фрагмент изображения
                                        _pictures[index].Name = "pic_" + i_h.ToString() + "_" + i_w.ToString();
                    _pictures[index].Parent = parent_control; // назначаем родителя 
                    _pictures[index].BorderStyle = BorderStyle.FixedSingle; // используем окантовку 
                    _pictures[index].SizeMode = PictureBoxSizeMode.StretchImage; // подгонять под размеры
                                        _pictures[index].Tag = (int)index; // запоминаем индекс изображения 
                }
            Set_Sizes(size_picture); // устанавливаем размеры фрагментов и перерисовываем 
        }

        public void Change_Bmp(int index, Bitmap bmp_change)
        {
            int w_bmp = _bmp_picture.Width / _count_col; // ширина фрагмента оригинального изображения
            int h_bmp = _bmp_picture.Height / _count_str; // высота фрагмента оригинального изображения
            int index_string = Get_String_Index(index);
            int index_column = Get_Column_Index(index);
            RectangleF rect_temp = new RectangleF(index_string * w_bmp, index_column * h_bmp, w_bmp,
h_bmp);
            Graphics gr = Graphics.FromImage(_bmp_picture);
            gr.DrawImage(bmp_change, rect_temp);

            Set_Sizes(_size_picture);
        }

        public void Swap_Bmp(int index_first, int index_second)
        {
            int w_bmp = _bmp_picture.Width / _count_col; // ширина фрагмента оригинального изображения
            int h_bmp = _bmp_picture.Height / _count_str; // высота фрагмента оригинального изображения


            int index_first_string = Get_String_Index(index_first);
            //////////////////////////////////// 
            int index_first_column = Get_Column_Index(index_first);
            RectangleF rect_first = new RectangleF(index_first_string * w_bmp, index_first_column *
h_bmp,
                w_bmp, h_bmp);
            Bitmap bmp_first = _bmp_picture.Clone(rect_first, _bmp_picture.PixelFormat); // 1‐й фрагмент


            int index_second_string = Get_String_Index(index_second);
            //////////////////////////////////// 
            int index_second_column = Get_Column_Index(index_second);
            RectangleF rect_second = new RectangleF(index_second_string * w_bmp, index_second_column
* h_bmp,
                w_bmp, h_bmp);
            Bitmap bmp_second = _bmp_picture.Clone(rect_second, _bmp_picture.PixelFormat); // 2‐й фрагмент

                        Graphics gr = Graphics.FromImage(_bmp_picture);
            gr.DrawImage(bmp_first, rect_second); // копируем 1‐е изображение во 2‐й прямоугольник 
            gr.DrawImage(bmp_second, rect_first); // копируем 2‐е изображение в 1‐й прямоугольник 
            Set_Sizes(_size_picture);
        }

        public void Set_Sizes(Size im_size) // обновление общего размера изображения 
        {
            _size_picture = im_size;
            int w = _size_picture.Width / _count_col; // ширина фрагмента изображения на форме 
            int h = _size_picture.Height / _count_str; // высота фрагмента изображения на форме 
            int w_bmp = _bmp_picture.Width / _count_col; // ширина фрагмента оригинального изображения
            int h_bmp = _bmp_picture.Height / _count_str; // высота фрагмента оригинального изображения

                        Bitmap bmp_temp; // для временного хранения фрагмента изображения в bmp‐формате 
            RectangleF rect_temp; // для временного хранения координат копируемой области общего изображения
            for (int i_w = 0; i_w < _count_col; i_w++) // цикл по индексам по горизонтали 
                for (int i_h = 0; i_h < _count_str; i_h++) // подцикл по индексам по вертикали 
                {   // координаты копируемого фрагмента 
                    rect_temp = new RectangleF(i_w * w_bmp, i_h * h_bmp, w_bmp, h_bmp);
                    bmp_temp = _bmp_picture.Clone(rect_temp, _bmp_picture.PixelFormat); // сам  фрагмент
                    int index = Get_Real_Index(i_w, i_h); // получаем реальный индекс 
                    _pictures[index].Image = bmp_temp;
                    _pictures[index].Width = w;      // задаем ширину 
                    _pictures[index].Height = h;     //        высоту 
                    _pictures[index].Left = i_w * w; // отступ слева 
                    _pictures[index].Top = i_h * h;  //        сверху 
                    _pictures[index].BorderStyle = BorderStyle.FixedSingle; // используем окантовку 
                    _pictures[index].SizeMode = PictureBoxSizeMode.StretchImage; // подгонять под размеры
                                        _pictures[index].Refresh();
                }
        }

        public IEnumerable<PictureBox> Get_Pictures()
        {
            int count = _count_col * _count_str; // общее число фрагментов изображения 
            for (int i = 0; i < count; i++)
            {
                if (_pictures != null)
                {
                    yield return _pictures[i]; // возвращаем фрагмент изображения 
                }
            }
        }

        public int Get_String_Index(int real_index)
        {
            int ind_string = real_index / _count_str;
            return ind_string;
        }

        public int Get_Column_Index(int real_index)
        {
            int ind_column = real_index % _count_str;
            return ind_column;
        }

        public int Get_Real_Index(int ind_str, int ind_col) // получаем 1‐мерный индекс по "2мерному" 
        { 
            int index_1d = _count_str * ind_str + ind_col; 
            return index_1d; 
        } 
 
        public PictureBox this[int index] // обращение к 1‐мерному индексатору 
        {
            get
            {
                return _pictures[index];
                //int ind_string = Get_String_Index(index); 
                //int ind_column = Get_Column_Index(index); 
                //return this[ind_string, ind_column]; 
            }
        }

        public PictureBox this[int ind_str, int ind_col] // обращаемся как к 2‐мерному массиву 
        {
            get
            {
                if (ind_str < _count_str && ind_col < _count_col)
                {
                    int index = Get_Real_Index(ind_str, ind_col); // пересчитываем 1‐мерный индекс 
                    return _pictures[index]; // возвращаем указатель на реальный фрагмент 
                }
                else
                {
                    return null; // выход за границы "2‐мерного" массива 
                }
            }
            set
            {
                if (ind_str < _count_str && ind_col < _count_col)
                {
                    int index = Get_Real_Index(ind_str, ind_col); // пересчитываем 1‐мерный индекс 
                    _pictures[index] = value; // запоминаем фрагмент в реальный индекс 
                }
            }
        }
    }
}