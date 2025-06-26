namespace CS_CPP__Лаб_работа_14
{
    partial class LuckyTicket
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
            this.textBox_Input = new System.Windows.Forms.TextBox();
            this.panel_Variants = new System.Windows.Forms.Panel();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.radioButton_VariantDefault = new System.Windows.Forms.RadioButton();
            this.radioButtonVariantTask = new System.Windows.Forms.RadioButton();
            this.button_CheckVariant = new System.Windows.Forms.Button();
            this.listBox_Enumerate = new System.Windows.Forms.ListBox();
            this.button_FindAllLucky = new System.Windows.Forms.Button();
            this.panel_Variants.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Input
            // 
            this.textBox_Input.Location = new System.Drawing.Point(56, 51);
            this.textBox_Input.Multiline = true;
            this.textBox_Input.Name = "textBox_Input";
            this.textBox_Input.Size = new System.Drawing.Size(161, 43);
            this.textBox_Input.TabIndex = 0;
            // 
            // panel_Variants
            // 
            this.panel_Variants.Controls.Add(this.radioButtonVariantTask);
            this.panel_Variants.Controls.Add(this.radioButton_VariantDefault);
            this.panel_Variants.Location = new System.Drawing.Point(31, 120);
            this.panel_Variants.Name = "panel_Variants";
            this.panel_Variants.Size = new System.Drawing.Size(219, 113);
            this.panel_Variants.TabIndex = 1;
            // 
            // radioButton_VariantDefault
            // 
            this.radioButton_VariantDefault.AutoSize = true;
            this.radioButton_VariantDefault.Location = new System.Drawing.Point(42, 32);
            this.radioButton_VariantDefault.Name = "radioButton_VariantDefault";
            this.radioButton_VariantDefault.Size = new System.Drawing.Size(144, 17);
            this.radioButton_VariantDefault.TabIndex = 0;
            this.radioButton_VariantDefault.TabStop = true;
            this.radioButton_VariantDefault.Text = "Вариант по умолчанию \r\n";
            this.radioButton_VariantDefault.UseVisualStyleBackColor = true;
            // 
            // radioButtonVariantTask
            // 
            this.radioButtonVariantTask.AutoSize = true;
            this.radioButtonVariantTask.Location = new System.Drawing.Point(42, 65);
            this.radioButtonVariantTask.Name = "radioButtonVariantTask";
            this.radioButtonVariantTask.Size = new System.Drawing.Size(129, 17);
            this.radioButtonVariantTask.TabIndex = 1;
            this.radioButtonVariantTask.TabStop = true;
            this.radioButtonVariantTask.Text = "Вариант по заданию";
            this.radioButtonVariantTask.UseVisualStyleBackColor = true;
            // 
            // button_CheckVariant
            // 
            this.button_CheckVariant.Location = new System.Drawing.Point(43, 259);
            this.button_CheckVariant.Name = "button_CheckVariant";
            this.button_CheckVariant.Size = new System.Drawing.Size(196, 64);
            this.button_CheckVariant.TabIndex = 2;
            this.button_CheckVariant.Text = "Проверить вариант\r\n";
            this.button_CheckVariant.UseVisualStyleBackColor = true;
            this.button_CheckVariant.Click += new System.EventHandler(this.button_CheckVariant_Click);
            // 
            // listBox_Enumerate
            // 
            this.listBox_Enumerate.FormattingEnabled = true;
            this.listBox_Enumerate.Location = new System.Drawing.Point(349, 27);
            this.listBox_Enumerate.Name = "listBox_Enumerate";
            this.listBox_Enumerate.Size = new System.Drawing.Size(139, 381);
            this.listBox_Enumerate.TabIndex = 3;
            // 
            // button_FindAllLucky
            // 
            this.button_FindAllLucky.Location = new System.Drawing.Point(43, 344);
            this.button_FindAllLucky.Name = "button_FindAllLucky";
            this.button_FindAllLucky.Size = new System.Drawing.Size(196, 64);
            this.button_FindAllLucky.TabIndex = 4;
            this.button_FindAllLucky.Text = "Найти все счастливыые числа \r\n";
            this.button_FindAllLucky.UseVisualStyleBackColor = true;
            this.button_FindAllLucky.Click += new System.EventHandler(this.button_FindAllLucky_Click);
            // 
            // LuckyTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Controls.Add(this.button_FindAllLucky);
            this.Controls.Add(this.listBox_Enumerate);
            this.Controls.Add(this.button_CheckVariant);
            this.Controls.Add(this.panel_Variants);
            this.Controls.Add(this.textBox_Input);
            this.Name = "LuckyTicket";
            this.Text = "Form1";
            this.panel_Variants.ResumeLayout(false);
            this.panel_Variants.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Input;
        private System.Windows.Forms.Panel panel_Variants;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.RadioButton radioButton_VariantDefault;
        private System.Windows.Forms.RadioButton radioButtonVariantTask;
        private System.Windows.Forms.Button button_CheckVariant;
        private System.Windows.Forms.ListBox listBox_Enumerate;
        private System.Windows.Forms.Button button_FindAllLucky;
    }
}

