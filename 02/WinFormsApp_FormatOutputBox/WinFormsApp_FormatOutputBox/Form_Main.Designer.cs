namespace WinFormsApp_FormatOutputBox
{
    partial class Form_Main
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
            this.richTextBox_Output = new System.Windows.Forms.RichTextBox();
            this.groupBox_Input = new System.Windows.Forms.GroupBox();
            this.textBox_A = new System.Windows.Forms.TextBox();
            this.textBox_B = new System.Windows.Forms.TextBox();
            this.label_A = new System.Windows.Forms.Label();
            this.label_B = new System.Windows.Forms.Label();
            this.pictureBox_Preview = new System.Windows.Forms.PictureBox();
            this.listBox_Input = new System.Windows.Forms.ListBox();
            this.button_Evaluate = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.groupBox_Input.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Preview)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox_Output
            // 
            this.richTextBox_Output.Location = new System.Drawing.Point(12, 12);
            this.richTextBox_Output.Name = "richTextBox_Output";
            this.richTextBox_Output.ReadOnly = true;
            this.richTextBox_Output.Size = new System.Drawing.Size(464, 237);
            this.richTextBox_Output.TabIndex = 0;
            this.richTextBox_Output.Text = "";
            // 
            // groupBox_Input
            // 
            this.groupBox_Input.Controls.Add(this.listBox_Input);
            this.groupBox_Input.Controls.Add(this.pictureBox_Preview);
            this.groupBox_Input.Controls.Add(this.label_B);
            this.groupBox_Input.Controls.Add(this.label_A);
            this.groupBox_Input.Controls.Add(this.textBox_B);
            this.groupBox_Input.Controls.Add(this.textBox_A);
            this.groupBox_Input.Location = new System.Drawing.Point(12, 270);
            this.groupBox_Input.Name = "groupBox_Input";
            this.groupBox_Input.Size = new System.Drawing.Size(464, 142);
            this.groupBox_Input.TabIndex = 1;
            this.groupBox_Input.TabStop = false;
            this.groupBox_Input.Text = "Выбор исходных данных";
            // 
            // textBox_A
            // 
            this.textBox_A.Location = new System.Drawing.Point(367, 25);
            this.textBox_A.Name = "textBox_A";
            this.textBox_A.Size = new System.Drawing.Size(77, 20);
            this.textBox_A.TabIndex = 0;
            this.textBox_A.TextChanged += new System.EventHandler(this.textBox_A_TextChanged);
            // 
            // textBox_B
            // 
            this.textBox_B.Location = new System.Drawing.Point(367, 116);
            this.textBox_B.Name = "textBox_B";
            this.textBox_B.Size = new System.Drawing.Size(77, 20);
            this.textBox_B.TabIndex = 1;
            this.textBox_B.TextChanged += new System.EventHandler(this.textBox_B_TextChanged);
            // 
            // label_A
            // 
            this.label_A.AutoSize = true;
            this.label_A.Location = new System.Drawing.Point(280, 28);
            this.label_A.Name = "label_A";
            this.label_A.Size = new System.Drawing.Size(81, 13);
            this.label_A.TabIndex = 2;
            this.label_A.Text = "Переменная A";
            // 
            // label_B
            // 
            this.label_B.AutoSize = true;
            this.label_B.Location = new System.Drawing.Point(280, 119);
            this.label_B.Name = "label_B";
            this.label_B.Size = new System.Drawing.Size(81, 13);
            this.label_B.TabIndex = 3;
            this.label_B.Text = "Переменная B";
            // 
            // pictureBox_Preview
            // 
            this.pictureBox_Preview.Location = new System.Drawing.Point(283, 51);
            this.pictureBox_Preview.Name = "pictureBox_Preview";
            this.pictureBox_Preview.Size = new System.Drawing.Size(150, 50);
            this.pictureBox_Preview.TabIndex = 4;
            this.pictureBox_Preview.TabStop = false;
            // 
            // listBox_Input
            // 
            this.listBox_Input.FormattingEnabled = true;
            this.listBox_Input.Items.AddRange(new object[] {
            "<Нет действий>",
            "Простое сложение целых чисел",
            "Простое умножение целых чисел"});
            this.listBox_Input.Location = new System.Drawing.Point(24, 28);
            this.listBox_Input.Name = "listBox_Input";
            this.listBox_Input.Size = new System.Drawing.Size(233, 108);
            this.listBox_Input.TabIndex = 5;
            this.listBox_Input.SelectedIndexChanged += new System.EventHandler(this.listBox_Input_SelectedIndexChanged);
            // 
            // button_Evaluate
            // 
            this.button_Evaluate.Location = new System.Drawing.Point(36, 418);
            this.button_Evaluate.Name = "button_Evaluate";
            this.button_Evaluate.Size = new System.Drawing.Size(233, 23);
            this.button_Evaluate.TabIndex = 6;
            this.button_Evaluate.Text = "Выполнить расчет";
            this.button_Evaluate.UseVisualStyleBackColor = true;
            this.button_Evaluate.Click += new System.EventHandler(this.button_Evaluate_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(295, 418);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(161, 23);
            this.button_Clear.TabIndex = 7;
            this.button_Clear.Text = "Очистить";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 450);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_Evaluate);
            this.Controls.Add(this.groupBox_Input);
            this.Controls.Add(this.richTextBox_Output);
            this.Name = "Form_Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.groupBox_Input.ResumeLayout(false);
            this.groupBox_Input.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Preview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_Output;
        private System.Windows.Forms.GroupBox groupBox_Input;
        private System.Windows.Forms.TextBox textBox_A;
        private System.Windows.Forms.Label label_B;
        private System.Windows.Forms.Label label_A;
        private System.Windows.Forms.TextBox textBox_B;
        private System.Windows.Forms.ListBox listBox_Input;
        private System.Windows.Forms.PictureBox pictureBox_Preview;
        private System.Windows.Forms.Button button_Evaluate;
        private System.Windows.Forms.Button button_Clear;
    }
}

