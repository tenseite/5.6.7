namespace WinFormsApp_SaveLoadFragments
{
    partial class form_Main
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.radioButton_SaveAs = new System.Windows.Forms.RadioButton();
            this.radioButton_Load = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.MinimumSize = new System.Drawing.Size(480, 280);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(480, 280);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // radioButton_SaveAs
            // 
            this.radioButton_SaveAs.AutoSize = true;
            this.radioButton_SaveAs.Location = new System.Drawing.Point(51, 304);
            this.radioButton_SaveAs.Name = "radioButton_SaveAs";
            this.radioButton_SaveAs.Size = new System.Drawing.Size(152, 17);
            this.radioButton_SaveAs.TabIndex = 1;
            this.radioButton_SaveAs.TabStop = true;
            this.radioButton_SaveAs.Text = "Сохранить фрагмент как";
            this.radioButton_SaveAs.UseVisualStyleBackColor = true;
            this.radioButton_SaveAs.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton_Load
            // 
            this.radioButton_Load.AutoSize = true;
            this.radioButton_Load.Location = new System.Drawing.Point(327, 304);
            this.radioButton_Load.Name = "radioButton_Load";
            this.radioButton_Load.Size = new System.Drawing.Size(130, 17);
            this.radioButton_Load.TabIndex = 2;
            this.radioButton_Load.TabStop = true;
            this.radioButton_Load.Text = "Загрузить фрагмент";
            this.radioButton_Load.UseVisualStyleBackColor = true;
            // 
            // form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 327);
            this.Controls.Add(this.radioButton_Load);
            this.Controls.Add(this.radioButton_SaveAs);
            this.Controls.Add(this.pictureBox);
            this.Name = "form_Main";
            this.Text = "Сохранение и загрузка фрагментов изображений";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.RadioButton radioButton_SaveAs;
        private System.Windows.Forms.RadioButton radioButton_Load;
    }
}

