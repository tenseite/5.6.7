using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileFinderExample
{
    public partial class FrmFileFinderMain : Form
    {
        public FrmFileFinderMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {/// <summary> 
         /// Класс, задающий контекст для поиска файлов.  
         /// Содержит необходимые свойства для обмена между потоками и формой
         /// </summary> 
        }
        class FileSearchInfo{
            public long FilesTotalCount { get; set; } = 0;
            public long FilesProcessedCount { get; set; } = 0;
            public string SearchDirectory { get; set; }
            public long FilesFound { get; set; } = 0;
            public string FileNameMask { get; set; } = "";
            public List<string> FoundFiles = new List<string>();
        }
        /// <summary> 
             /// Текущий режим работы BackgroundWorker элементов и рекурсивного обхода директорий:  
        /// Estimate - происходит оценка времени на поиск 
        /// Search - происходит непосредственно поиск файлов по заданной маске
        /// </summary> 
        enum BackgroundWorkerMode{
            Estimate,
            Search
        }
        /// <summary> 
        /// Запущен или нет сейчас поиск 
        /// </summary> 
        public bool IsSearchRunning { get; set; } = false;

        /// <summary> 
        /// Контекстный объект, содержащий необходимые свойства для обмена данными между формой и потоками для объектовBackgroundWorker
        /// </summary> 
        private FileSearchInfo FileSearchInfoHolder { get; set; } = new
            FileSearchInfo();
        /// <summary> 
        /// Переключает свойство IsSearchRunning в значение <paramref name="isRunning"/>, а также
        /// обновляет текст кнопки ButtonStart и её состояние 
        /// </summary> 
        /// <param name="isRunning">значение, которым необходимо обновить свойство IsSearchRunning</param> 
        private void SetIsSearchRunningAndUpdateButtonStartState(bool isRunning)
        {
            if (isRunning)
            {
                ButtonStartSearch.Text = "&Прервать";
            }
            else
            {
                ButtonStartSearch.Text = "&Начать поиск";
                ButtonStartSearch.Enabled = true;
            }
            IsSearchRunning = isRunning;
        }
        /// <summary> 
        /// Запускает выбранный файл с помощью стандартной программы и через штатные механизмы оболочки
        /// операционной системы 
        /// </summary> 
        /// <param name="pathToFile">путь к файлу для запуска</param> 
        private void StartSelectedFileUsingShellExecute(string pathToFile)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = pathToFile;
            processStartInfo.UseShellExecute = true;
            Process.Start(processStartInfo);
        }
        private void UpdateSearchPathReadonlyTextBox(string searchPath)
        {
            if (!searchPath.Equals(TextBoxSearchPath.Text) &&
FileSearchInfoHolder.FilesTotalCount > 0)
            {
                FileSearchInfoHolder.FilesTotalCount = 0;
            }
            TextBoxSearchPath.Text = searchPath;
        }
        /// <summary> 
        /// Метод выбирает один из доступных в системе дисков в выпадающем списке по заданному пути поиска файлов.
        /// Находит в начале пути поиска <paramref name="searchPath"/> букву диска и выберет его в выпадающем списке.   
        /// </summary> 
        /// <param name="searchPath">путь поиска файлов</param> 
        private void SelectDriveBySearchPath(string searchPath)
        {
            int commaSlashPosition = searchPath.IndexOf(":\\");
            if (commaSlashPosition >= 0)
            {
                string driveLetterFromPath = searchPath.Substring(0,
commaSlashPosition + 2);

                foreach (var item in ComboBoxDrives.Items)
                {
                    if (item is DriveInfoItem driveInfoItem)
                    {
                        if (driveInfoItem.DriveName.Equals(driveLetterFromPath))
                        {
                            ComboBoxDrives.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Ошибка: невозможно найти диск, соответствующий выбранному пути", "Ошибка", MessageBoxButtons.OK, 
MessageBoxIcon.Error);
            }
        }
        private void UpdateSearchDirectoryFromSelectedDrive()
        {
            FileSearchInfoHolder.SearchDirectory = (ComboBoxDrives.SelectedItem
as DriveInfoItem).DriveName;

            UpdateSearchPathReadonlyTextBox(FileSearchInfoHolder.SearchDirectory);
        }

        /// <summary> 
        /// Загружает в выпадающий список все доступные в системе диски с краткой информацией о них
        /// </summary> 
        private void LoadAvailableDrivesInfo()
        {
            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            foreach (var driveInfo in driveInfos)
            {
                ComboBoxDrives.Items.Add(new DriveInfoItem(driveInfo));
            }
            ComboBoxDrives.SelectedIndex = 0;
        }

        /// <summary> 
        /// Метод запускает поиск файлов по имени файла (маске файла) 
        /// </summary> 
        private void StartSearchFilesByFileName()
        {
            LabelProgress.Text = "Поиск файла по маске *" +
FileSearchInfoHolder.FileNameMask + "* в каталоге '" +
FileSearchInfoHolder.SearchDirectory + "'...";
            LabelFilesCount.Visible = false;
            ProgressBarMain.Style = ProgressBarStyle.Continuous;
            FileSearchInfoHolder.FilesFound = 0;
            FileSearchInfoHolder.FilesProcessedCount = 0;
            SetIsSearchRunningAndUpdateButtonStartState(true);
            BackgroundWorkerSearchFiles.RunWorkerAsync(FileSearchInfoHolder);
        }
        /// <summary> 
        /// Выполняет рекурсивный обход директорий, начиная с родительской директории<paramref name = "parentDirectory" />.
        /// Может работать в двух режимах: 
        /// 1) подсчёт общего количества вложенных файлов внутри родительской директории<paramref name="parentDirectory"/>,
/// 2) поиск в родительской директории <paramref name= "parentDirectory" /> файла по заданной маске
/// </summary> 
/// <param name="parentDirectory">родительская директория, с которой необходимо начать рекурсивный обход вложенных директорий ифайлов</param> 
        /// <param name="workerMode">режим работы объектов BackgroundWorker: Estimate - оценка времени поиска в каталоге, Search - сампоиск</param> 
        /// <param name="fileInfoHolder">контекстный объект, содержащий необходимые свойства для обеспечения оценки поиска и самогопоиска</param>
        private void CalculateFilesCountRecursively(string parentDirectory,
BackgroundWorkerMode workerMode, FileSearchInfo fileInfoHolder)
        {
            try
            {
                IEnumerable<string> subdirectories =
Directory.EnumerateDirectories(parentDirectory, "*",
SearchOption.TopDirectoryOnly);
                IEnumerable<string> files = Directory.EnumerateFiles(parentDirectory);

                if (workerMode == BackgroundWorkerMode.Estimate)
                {
                    // если было запрошено прерывание операции оценки времени поиска - выходим из рекурсии
                    if (BackgroundWorkerEstimateSearchTime.CancellationPending)
                    {
                        return;
                    }

                    fileInfoHolder.FilesTotalCount += files.LongCount();
                    BackgroundWorkerEstimateSearchTime.ReportProgress(10);
                }
                else if (workerMode == BackgroundWorkerMode.Search)
                {

                    // если было запрошено прерывание операции поиска - выходим из рекурсии
                    if (BackgroundWorkerSearchFiles.CancellationPending)
                    {
                        return;
                    }

                    foreach (string file in files)
                    {
                        if (file.Contains(fileInfoHolder.FileNameMask))
                        {
                            fileInfoHolder.FoundFiles.Add(file);
                            FileSearchInfoHolder.FilesFound++;
                        }
                    }

                    List<string> foundFiles = new
List<string>(fileInfoHolder.FoundFiles);

                    fileInfoHolder.FilesProcessedCount += files.LongCount();
                    int progress = (int)(fileInfoHolder.FilesProcessedCount * 100 /
fileInfoHolder.FilesTotalCount);
                    BackgroundWorkerSearchFiles.ReportProgress(progress, foundFiles);
                    fileInfoHolder.FoundFiles.Clear();
                }

                if (subdirectories.LongCount() > 0)
                {
                    foreach (string subdirectory in subdirectories)
                    {
                        CalculateFilesCountRecursively(subdirectory, workerMode,
fileInfoHolder);
                    }
                }
            }
            catch (UnauthorizedAccessException unauthorizedAccessException)
            {
                // TODO: обработать исключение при необходимости... 
            }
            catch (DirectoryNotFoundException directoryNotFoundException)
            {
                // TODO: обработать исключение при необходимости... 
            }
            catch (Exception otherException)
            {
                // TODO: обработать исключение при необходимости... 
            }
        }
        private void FrmFileFinderMain_Load(object sender, EventArgs e)
        {
            LabelProgress.Visible = false;
            LabelFilesCount.Visible = false;
            ProgressBarMain.Visible = false;
            this.DoubleBuffered = true;

            LoadAvailableDrivesInfo();
            UpdateSearchDirectoryFromSelectedDrive();
        }
        /// <summary> 
        /// Метод для выполнения основной работы для элемента BackgroundWorker, отвечающего за оценку времени поиска в заданнойдиректории.
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void BackgroundWorkerEstimateSearchTime_DoWork(object sender,
DoWorkEventArgs e)
        {
            if (e.Argument is FileSearchInfo fileInfo)
            {
                if (BackgroundWorkerEstimateSearchTime.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {

                    CalculateFilesCountRecursively(FileSearchInfoHolder.SearchDirectory,
                    BackgroundWorkerMode.Estimate, fileInfo);
                    if (BackgroundWorkerEstimateSearchTime.CancellationPending)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
        private void BackgroundWorkerSearchFiles_DoWork(object sender,
DoWorkEventArgs e)
        {
            if (e.Argument is FileSearchInfo fileInfo)
            {
                if (BackgroundWorkerSearchFiles.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {

                    CalculateFilesCountRecursively(FileSearchInfoHolder.SearchDirectory,
                    BackgroundWorkerMode.Search, fileInfo);
                    if (BackgroundWorkerSearchFiles.CancellationPending)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
        private void
BackgroundWorkerEstimateSearchTime_RunWorkerCompleted(object sender,
RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                // Оценка времени поиска завершилась с прерыванием. Выводим сообщение об этом, сбрасываем счётчики,
                // скрываем метку с количеством файлов и делаем невидимым прогресс бар
                SetIsSearchRunningAndUpdateButtonStartState(false);

                LabelProgress.Text = "Оценка времени поиска была прервана.";
                FileSearchInfoHolder.FilesTotalCount = 0;
                FileSearchInfoHolder.FilesFound = 0;
                ProgressBarMain.Visible = false;
                LabelFilesCount.Text = "0";
                LabelFilesCount.Visible = false;
            }
            else
            {
                // Оценка времени поиска завершилась без прерывания. Значит, запускаем непосредственно поиск файлов по маске
                StartSearchFilesByFileName();
            }
        }
        private void BackgroundWorkerSearchFiles_RunWorkerCompleted(object
sender, RunWorkerCompletedEventArgs e)
        {
            SetIsSearchRunningAndUpdateButtonStartState(false);

            if (e.Cancelled)
            {
                // Операция поиска файлов была прервана 
                LabelProgress.Text = "Операция поиска прервана.";
                ProgressBarMain.Visible = false;
                LabelFilesCount.Text = "0";
                LabelFilesCount.Visible = false;
            }
            else
            {
                // Поиск завершился штатно, без прерывания 
                LabelProgress.Text = "Поиск по маске *" +
FileSearchInfoHolder.FileNameMask + "* в каталоге '" +
FileSearchInfoHolder.SearchDirectory + "' завершён. Найдено файлов: ";
                LabelFilesCount.Left = LabelProgress.Right + 10;
                LabelFilesCount.Text = FileSearchInfoHolder.FilesFound.ToString();
                LabelFilesCount.Visible = true;
            }
        }
        private void
BackgroundWorkerEstimateSearchTime_ProgressChanged(object sender,
ProgressChangedEventArgs e)
        {
            LabelFilesCount.Text = FileSearchInfoHolder.FilesTotalCount.ToString();
        }

        /// <summary> 
        /// Событие обработки изменения прогресса для элемента BackgroundWorker, отвечающего за поиск файлов.
        /// Обновляет значение прогресс бара и добавляет в элемент ListViewFoundFiles все найденные файлы.
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void BackgroundWorkerSearchFiles_ProgressChanged(object sender,
ProgressChangedEventArgs e)
        {
            ProgressBarMain.Value = e.ProgressPercentage;
            List<string> foundFiles = (List<string>)e.UserState;

            ListViewGroup group =
ListViewFoundFiles.Groups["listViewGroupFiles"];

            foreach (string fileName in foundFiles)
            {
                long fileSizeInBytes = -1;
                try
                {
                    FileInfo fileInfo = new FileInfo(fileName);
                    fileSizeInBytes = fileInfo.Length;
                }
                catch (FileNotFoundException fileNotFoundException)
                {
                    //TODO: обработать исключение при необходимости... 
                }

                ListViewItem value = new ListViewItem(new string[] { fileName,
fileSizeInBytes.ToString() }, 0, group);
                ListViewFoundFiles.Items.Add(value);
            }

            FileSearchInfoHolder.FoundFiles.Clear();
        }
        /// <summary> 
        /// Обработка изменения события изменения текста в текстовом поле TextBoxFileName.
        /// Необходимо делать доступной кнопку поиска, если маска поиска для файлов задана и недоступной,
        /// если поле пустое или содержит лишь пробелы. 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void TextBoxFileName_TextChanged(object sender, EventArgs e)
        {
            ButtonStartSearch.Enabled = !"".Equals(TextBoxFileName.Text.Trim());
        }
        /// <summary> 
        /// Обработка нажатия на кнопку "Начать поиск" / "Прервать" 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void ButtonStartSearch_Click(object sender, EventArgs e)
        {
            if (IsSearchRunning)
            {
                // Поиск уже запущен - прервать 

                // Запретить повторные нажатия на кнопку "Прервать" 
                ButtonStartSearch.Enabled = false;

                // Асинхронная отмена работы BackgroundWorker-ов 
                if (BackgroundWorkerEstimateSearchTime.IsBusy)
                {
                    BackgroundWorkerEstimateSearchTime.CancelAsync();
                }
                if (BackgroundWorkerSearchFiles.IsBusy)
                {
                    BackgroundWorkerSearchFiles.CancelAsync();
                }
            }
            else
            {
                // Поиск не запущен - запустить оценку времени поиска или сам поиск
                FileSearchInfoHolder.FileNameMask = TextBoxFileName.Text;
                ProgressBarMain.Value = 0;
                ListViewFoundFiles.Groups.Clear();
                ListViewFoundFiles.Groups.Add(new
ListViewGroup("listViewGroupFiles", "Найденные файлы"));

                FileSearchInfoHolder.FoundFiles.Clear();

                ProgressBarMain.Visible = true;

                if (FileSearchInfoHolder.FilesTotalCount == 0)
                {
                    ProgressBarMain.Style = ProgressBarStyle.Marquee;
                    LabelProgress.Text = "Подсчёт количества файлов в системе и оценка примерного времени... Найдено файлов: "; 
                    LabelProgress.Visible = true;
                    LabelFilesCount.Visible = true;
                    LabelFilesCount.Left = LabelProgress.Right + 10;
                    SetIsSearchRunningAndUpdateButtonStartState(true);

                    BackgroundWorkerEstimateSearchTime.RunWorkerAsync(FileSearchInfoHolder)
                     ;
                }
                else
                {
                    StartSearchFilesByFileName();
                }
            }
        }
        /// <summary> 
        /// Обработка нажатия на кнопку "Обзор..." - для выбора директории, в которой необходимо производить поиск файлов
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void ButtonSelectSearchDirectory_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult =
FolderBrowserDialogSelectSearchDirectory.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string selectedPath =
FolderBrowserDialogSelectSearchDirectory.SelectedPath;
                if (!selectedPath.EndsWith("\\"))
                {
                    selectedPath += "\\";
                }
                FileSearchInfoHolder.SearchDirectory = selectedPath;
                UpdateSearchPathReadonlyTextBox(selectedPath);
                SelectDriveBySearchPath(selectedPath);
            }
        }
        /// <summary> 
        /// Обработка двойного клика по одному из найденных файлов - для запуска стандартной программы,  
        /// которая сможет открыть файл 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void ListViewFoundFiles_DoubleClick(object sender, EventArgs e)
        {
            var selectedItems = ListViewFoundFiles.SelectedItems;
            if (selectedItems.Count > 0)
            {
                var selectedItem = selectedItems[0];
                StartSelectedFileUsingShellExecute(selectedItem.Text);
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ButtonStartSearch_Click_1(object sender, EventArgs e)
        {

        }

        private void ButtonSelectSearchDirectory_Click_1(object sender, EventArgs e)
        {

        }

        private void TextBoxSearchPath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
