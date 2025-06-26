namespace FileFinderExample
{
    partial class FrmFileFinderMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFileFinderMain));
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Найденные файлы", System.Windows.Forms.HorizontalAlignment.Left);
            this.LabelDrive = new System.Windows.Forms.Label();
            this.LabelSearchPath = new System.Windows.Forms.Label();
            this.LabelFileName = new System.Windows.Forms.Label();
            this.LabelFoundFilesList = new System.Windows.Forms.Label();
            this.LabelProgress = new System.Windows.Forms.Label();
            this.ComboBoxDrives = new System.Windows.Forms.ComboBox();
            this.TextBoxSearchPath = new System.Windows.Forms.TextBox();
            this.TextBoxFileName = new System.Windows.Forms.TextBox();
            this.ButtonSelectSearchDirectory = new System.Windows.Forms.Button();
            this.ButtonStartSearch = new System.Windows.Forms.Button();
            this.ListViewFoundFiles = new System.Windows.Forms.ListView();
            this.columnHeaderFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProgressBarMain = new System.Windows.Forms.ProgressBar();
            this.BackgroundWorkerEstimateSearchTime = new System.ComponentModel.BackgroundWorker();
            this.BackgroundWorkerSearchFiles = new System.ComponentModel.BackgroundWorker();
            this.FolderBrowserDialogSelectSearchDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.ToolTipHints = new System.Windows.Forms.ToolTip(this.components);
            this.LabelFilesCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelDrive
            // 
            this.LabelDrive.AutoSize = true;
            this.LabelDrive.Location = new System.Drawing.Point(14, 9);
            this.LabelDrive.Name = "LabelDrive";
            this.LabelDrive.Size = new System.Drawing.Size(100, 13);
            this.LabelDrive.TabIndex = 0;
            this.LabelDrive.Text = "Диск для поиска: ";
            this.LabelDrive.Click += new System.EventHandler(this.label1_Click);
            // 
            // LabelSearchPath
            // 
            this.LabelSearchPath.AutoSize = true;
            this.LabelSearchPath.Location = new System.Drawing.Point(14, 41);
            this.LabelSearchPath.Name = "LabelSearchPath";
            this.LabelSearchPath.Size = new System.Drawing.Size(97, 13);
            this.LabelSearchPath.TabIndex = 1;
            this.LabelSearchPath.Text = "Путь для поиска: ";
            // 
            // LabelFileName
            // 
            this.LabelFileName.AutoSize = true;
            this.LabelFileName.Location = new System.Drawing.Point(14, 91);
            this.LabelFileName.Name = "LabelFileName";
            this.LabelFileName.Size = new System.Drawing.Size(293, 13);
            this.LabelFileName.TabIndex = 2;
            this.LabelFileName.Text = " Полное имя файла, часть имени файла или часть пути, ";
            // 
            // LabelFoundFilesList
            // 
            this.LabelFoundFilesList.AutoSize = true;
            this.LabelFoundFilesList.Location = new System.Drawing.Point(14, 146);
            this.LabelFoundFilesList.Name = "LabelFoundFilesList";
            this.LabelFoundFilesList.Size = new System.Drawing.Size(152, 13);
            this.LabelFoundFilesList.TabIndex = 3;
            this.LabelFoundFilesList.Text = " Список найденных файлов: ";
            // 
            // LabelProgress
            // 
            this.LabelProgress.AutoSize = true;
            this.LabelProgress.Location = new System.Drawing.Point(14, 454);
            this.LabelProgress.Name = "LabelProgress";
            this.LabelProgress.Size = new System.Drawing.Size(62, 13);
            this.LabelProgress.TabIndex = 4;
            this.LabelProgress.Text = "Прогресс: ";
            // 
            // ComboBoxDrives
            // 
            this.ComboBoxDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxDrives.FormattingEnabled = true;
            this.ComboBoxDrives.Location = new System.Drawing.Point(126, 6);
            this.ComboBoxDrives.Name = "ComboBoxDrives";
            this.ComboBoxDrives.Size = new System.Drawing.Size(662, 21);
            this.ComboBoxDrives.TabIndex = 5;
            this.ToolTipHints.SetToolTip(this.ComboBoxDrives, "Указывает на системный диск, в \r\nкотором осуществляется поиск файлов \r\n");
            // 
            // TextBoxSearchPath
            // 
            this.TextBoxSearchPath.Location = new System.Drawing.Point(15, 57);
            this.TextBoxSearchPath.Name = "TextBoxSearchPath";
            this.TextBoxSearchPath.ReadOnly = true;
            this.TextBoxSearchPath.Size = new System.Drawing.Size(632, 20);
            this.TextBoxSearchPath.TabIndex = 6;
            this.ToolTipHints.SetToolTip(this.TextBoxSearchPath, "Отображает путь, в котором будет \r\nпроизводиться поиск файлов ");
            this.TextBoxSearchPath.TextChanged += new System.EventHandler(this.TextBoxSearchPath_TextChanged);
            // 
            // TextBoxFileName
            // 
            this.TextBoxFileName.Location = new System.Drawing.Point(15, 107);
            this.TextBoxFileName.Name = "TextBoxFileName";
            this.TextBoxFileName.Size = new System.Drawing.Size(632, 20);
            this.TextBoxFileName.TabIndex = 7;
            this.ToolTipHints.SetToolTip(this.TextBoxFileName, resources.GetString("TextBoxFileName.ToolTip"));
            // 
            // ButtonSelectSearchDirectory
            // 
            this.ButtonSelectSearchDirectory.Location = new System.Drawing.Point(653, 55);
            this.ButtonSelectSearchDirectory.Name = "ButtonSelectSearchDirectory";
            this.ButtonSelectSearchDirectory.Size = new System.Drawing.Size(135, 23);
            this.ButtonSelectSearchDirectory.TabIndex = 8;
            this.ButtonSelectSearchDirectory.Text = "&Обзор... ";
            this.ToolTipHints.SetToolTip(this.ButtonSelectSearchDirectory, "Выберите директорию, в которой \r\nбудет производиться поиск файлов");
            this.ButtonSelectSearchDirectory.UseVisualStyleBackColor = true;
            this.ButtonSelectSearchDirectory.Click += new System.EventHandler(this.ButtonSelectSearchDirectory_Click_1);
            // 
            // ButtonStartSearch
            // 
            this.ButtonStartSearch.Location = new System.Drawing.Point(653, 105);
            this.ButtonStartSearch.Name = "ButtonStartSearch";
            this.ButtonStartSearch.Size = new System.Drawing.Size(135, 23);
            this.ButtonStartSearch.TabIndex = 9;
            this.ButtonStartSearch.Text = "&Начать поиск ";
            this.ToolTipHints.SetToolTip(this.ButtonStartSearch, "Нажмите для начала поиска или \r\nостановки поиска файлов");
            this.ButtonStartSearch.UseVisualStyleBackColor = true;
            this.ButtonStartSearch.Click += new System.EventHandler(this.ButtonStartSearch_Click_1);
            // 
            // ListViewFoundFiles
            // 
            this.ListViewFoundFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFileName,
            this.columnHeaderFileSize});
            this.ListViewFoundFiles.FullRowSelect = true;
            this.ListViewFoundFiles.GridLines = true;
            listViewGroup2.Header = "Найденные файлы";
            listViewGroup2.Name = "listViewGroupFiles";
            this.ListViewFoundFiles.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup2});
            this.ListViewFoundFiles.HideSelection = false;
            this.ListViewFoundFiles.Location = new System.Drawing.Point(15, 172);
            this.ListViewFoundFiles.MultiSelect = false;
            this.ListViewFoundFiles.Name = "ListViewFoundFiles";
            this.ListViewFoundFiles.Size = new System.Drawing.Size(773, 270);
            this.ListViewFoundFiles.TabIndex = 10;
            this.ToolTipHints.SetToolTip(this.ListViewFoundFiles, "В списке будут отражены результаты \r\nпоиска файлов ");
            this.ListViewFoundFiles.UseCompatibleStateImageBehavior = false;
            this.ListViewFoundFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderFileName
            // 
            this.columnHeaderFileName.Text = "Имя файла";
            this.columnHeaderFileName.Width = 650;
            // 
            // columnHeaderFileSize
            // 
            this.columnHeaderFileSize.Text = "Размер файла, байт";
            this.columnHeaderFileSize.Width = 115;
            // 
            // ProgressBarMain
            // 
            this.ProgressBarMain.Location = new System.Drawing.Point(15, 470);
            this.ProgressBarMain.MarqueeAnimationSpeed = 30;
            this.ProgressBarMain.Name = "ProgressBarMain";
            this.ProgressBarMain.Size = new System.Drawing.Size(773, 23);
            this.ProgressBarMain.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBarMain.TabIndex = 11;
            this.ToolTipHints.SetToolTip(this.ProgressBarMain, "Отображает ход выполнения операции \r\n(оценки времени поиска файлов или \r\nнепосред" +
        "ственно поиска файлов) ");
            // 
            // BackgroundWorkerEstimateSearchTime
            // 
            this.BackgroundWorkerEstimateSearchTime.WorkerReportsProgress = true;
            this.BackgroundWorkerEstimateSearchTime.WorkerSupportsCancellation = true;
            this.BackgroundWorkerEstimateSearchTime.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerEstimateSearchTime_DoWork);
            // 
            // BackgroundWorkerSearchFiles
            // 
            this.BackgroundWorkerSearchFiles.WorkerReportsProgress = true;
            this.BackgroundWorkerSearchFiles.WorkerSupportsCancellation = true;
            // 
            // ToolTipHints
            // 
            this.ToolTipHints.AutoPopDelay = 20000;
            this.ToolTipHints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ToolTipHints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ToolTipHints.InitialDelay = 100;
            this.ToolTipHints.ReshowDelay = 1000;
            this.ToolTipHints.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ToolTipHints.ToolTipTitle = "Подсказка:";
            // 
            // LabelFilesCount
            // 
            this.LabelFilesCount.AutoSize = true;
            this.LabelFilesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.LabelFilesCount.Location = new System.Drawing.Point(774, 454);
            this.LabelFilesCount.Name = "LabelFilesCount";
            this.LabelFilesCount.Size = new System.Drawing.Size(14, 13);
            this.LabelFilesCount.TabIndex = 12;
            this.LabelFilesCount.Text = "0";
            // 
            // FrmFileFinderMain
            // 
            this.AcceptButton = this.ButtonStartSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 523);
            this.Controls.Add(this.LabelFilesCount);
            this.Controls.Add(this.ProgressBarMain);
            this.Controls.Add(this.ListViewFoundFiles);
            this.Controls.Add(this.ButtonStartSearch);
            this.Controls.Add(this.ButtonSelectSearchDirectory);
            this.Controls.Add(this.TextBoxFileName);
            this.Controls.Add(this.TextBoxSearchPath);
            this.Controls.Add(this.ComboBoxDrives);
            this.Controls.Add(this.LabelProgress);
            this.Controls.Add(this.LabelFoundFilesList);
            this.Controls.Add(this.LabelFileName);
            this.Controls.Add(this.LabelSearchPath);
            this.Controls.Add(this.LabelDrive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFileFinderMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " [Allineed.Ru] Пример поиска файлов в системе с ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelDrive;
        private System.Windows.Forms.Label LabelSearchPath;
        private System.Windows.Forms.Label LabelFileName;
        private System.Windows.Forms.Label LabelFoundFilesList;
        private System.Windows.Forms.Label LabelProgress;
        private System.Windows.Forms.ComboBox ComboBoxDrives;
        private System.Windows.Forms.TextBox TextBoxSearchPath;
        private System.Windows.Forms.TextBox TextBoxFileName;
        private System.Windows.Forms.Button ButtonSelectSearchDirectory;
        private System.Windows.Forms.Button ButtonStartSearch;
        private System.Windows.Forms.ListView ListViewFoundFiles;
        private System.Windows.Forms.ColumnHeader columnHeaderFileName;
        private System.Windows.Forms.ColumnHeader columnHeaderFileSize;
        private System.Windows.Forms.ProgressBar ProgressBarMain;
        private System.ComponentModel.BackgroundWorker BackgroundWorkerEstimateSearchTime;
        private System.ComponentModel.BackgroundWorker BackgroundWorkerSearchFiles;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialogSelectSearchDirectory;
        private System.Windows.Forms.ToolTip ToolTipHints;
        private System.Windows.Forms.Label LabelFilesCount;
    }
}

