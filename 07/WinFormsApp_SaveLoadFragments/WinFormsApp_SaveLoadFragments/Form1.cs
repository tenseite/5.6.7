using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms_SaveLoadFragments;

namespace WinFormsApp_SaveLoadFragments
{
    public partial class form_Main : Form
    {
        private ArrayPictures _arr_pictures; // класс с фрагментами изображений
        public form_Main()
        {
            InitializeComponent();
            int ind_image = 0; // загружаем изображение из ресурсов 
            Image im_pic = (Image)Properties.Resources.ResourceManager.GetObject("Task_" +
                (ind_image + 1).ToString());
            Bitmap bmp_pic = new Bitmap(im_pic);
            //bmp_pic = ; 
            Size size_pic = new Size(pictureBox.Width, pictureBox.Height);
            _arr_pictures = new ArrayPictures(pictureBox, bmp_pic, size_pic, 3, 4); // инициализируем фрагменты
                                                                                    // пересчитываем размер изображения 
            Size pic_size = new Size(this.Size.Width ‐ 20, this.Size.Height ‐ 100);
            pictureBox.Size = pic_size; // присваиваем новые размеры изображения 
                                        // изменяем размер изображений фрагментов и перерисовываем их 
            _arr_pictures.Set_Sizes(pic_size);
            AssignPictures();
        } // назначить клики для фрагментов и выполняем прорисовку  // ‐‐‐ BEGIN OF USER DEFINED METHODS
          // ‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐ 
      //‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐ 
private void AssignPictures() // перерисовка фрагментов изображения 
        {
            foreach (PictureBox pic in _arr_pictures.Get_Pictures()) // для всех изображений 
            {
                int index = (int)pic.Tag;
                pic.Click += new EventHandler(fragment_Click); // обработка клика 
                pic.Visible = true;
            }
        }

        void fragment_Click(object sender, EventArgs e) // обработка клика фрагмента 
        {
            PictureBox pic = (PictureBox)sender;
            int index = (int)pic.Tag;
            if (radioButton_Load.Checked) // если требуется загрузка фрагмента изображения 
            {
                Load_Fragment(index);
            }
            else // иначе выполняем сохранение данного фрагмента изображения 
            {
                Save_Fragment(index);
            }
        }

        private void Load_Fragment(int index)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Фильтр показа только файлов с определенным расширением. 
            openFileDialog.Filter = "файлы картинок (*.bmp;*.jpg;*.jpeg;)|*.bmp;*.jpg;.jpeg|All files(*.*) | *.* "; 
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap pic_show = new Bitmap(openFileDialog.FileName); // Загружаем выбранную картинку
                _arr_pictures.Change_Bmp(index, pic_show);
            }
        }

        private void Save_Fragment(int index)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            // Фильтр показа только файлов с определенным расширением. 
            saveFileDialog.Filter = "файлы картинок (*.bmp;*.jpg;*.jpeg;)|*.bmp;*.jpg;.jpeg|All files(*.*) | *.* "; 
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string str_file = saveFileDialog.FileName; // Загружаем выбранную картинку 
                PictureBox pic = _arr_pictures[index]; // обращение к индексатору 
                pic.Image.Save(str_file);

            }
        } 

      //‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐ 
// ‐‐‐ END OF USER DEFINED METHODS ‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
