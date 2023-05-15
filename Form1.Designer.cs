namespace HW4_LINQ
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonNoLinq = new System.Windows.Forms.RadioButton();
            this.radioButtonLinq = new System.Windows.Forms.RadioButton();
            this.buttonSetFolderPath = new System.Windows.Forms.Button();
            this.numericUpDown_minLength = new System.Windows.Forms.NumericUpDown();
            this.textBoxFolderPath = new System.Windows.Forms.TextBox();
            this.buttonFindMostCommonLongWord = new System.Windows.Forms.Button();
            this.buttonFindMostFrequentWords = new System.Windows.Forms.Button();
            this.buttonFindFileWithMostRepeatedWordInTextFiles = new System.Windows.Forms.Button();
            this.buttonFindVowelDistribution = new System.Windows.Forms.Button();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.labelTimer = new System.Windows.Forms.Label();
            this.numericUpDown_maxWordsToShow = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_maxWordsToShow)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.GridColor = System.Drawing.SystemColors.MenuText;
            this.dataGridView.Location = new System.Drawing.Point(404, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(384, 290);
            this.dataGridView.TabIndex = 0;
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.Color.Transparent;
            this.chart.BorderlineColor = System.Drawing.SystemColors.WindowText;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Location = new System.Drawing.Point(231, 308);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(557, 138);
            this.chart.TabIndex = 1;
            this.chart.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonNoLinq);
            this.groupBox1.Controls.Add(this.radioButtonLinq);
            this.groupBox1.Location = new System.Drawing.Point(12, 338);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LINQ";
            // 
            // radioButtonNoLinq
            // 
            this.radioButtonNoLinq.AutoSize = true;
            this.radioButtonNoLinq.Location = new System.Drawing.Point(39, 60);
            this.radioButtonNoLinq.Name = "radioButtonNoLinq";
            this.radioButtonNoLinq.Size = new System.Drawing.Size(141, 20);
            this.radioButtonNoLinq.TabIndex = 1;
            this.radioButtonNoLinq.Text = "Не использовать";
            this.radioButtonNoLinq.UseVisualStyleBackColor = true;
            // 
            // radioButtonLinq
            // 
            this.radioButtonLinq.AutoSize = true;
            this.radioButtonLinq.Checked = true;
            this.radioButtonLinq.Location = new System.Drawing.Point(39, 30);
            this.radioButtonLinq.Name = "radioButtonLinq";
            this.radioButtonLinq.Size = new System.Drawing.Size(122, 20);
            this.radioButtonLinq.TabIndex = 0;
            this.radioButtonLinq.TabStop = true;
            this.radioButtonLinq.Text = "Использовать";
            this.radioButtonLinq.UseVisualStyleBackColor = true;
            // 
            // buttonSetFolderPath
            // 
            this.buttonSetFolderPath.Location = new System.Drawing.Point(51, 227);
            this.buttonSetFolderPath.Name = "buttonSetFolderPath";
            this.buttonSetFolderPath.Size = new System.Drawing.Size(116, 47);
            this.buttonSetFolderPath.TabIndex = 13;
            this.buttonSetFolderPath.Text = "Выбрать папку";
            this.buttonSetFolderPath.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_minLength
            // 
            this.numericUpDown_minLength.Location = new System.Drawing.Point(318, 33);
            this.numericUpDown_minLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_minLength.Name = "numericUpDown_minLength";
            this.numericUpDown_minLength.Size = new System.Drawing.Size(80, 22);
            this.numericUpDown_minLength.TabIndex = 15;
            this.numericUpDown_minLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_minLength.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // textBoxFolderPath
            // 
            this.textBoxFolderPath.Location = new System.Drawing.Point(12, 280);
            this.textBoxFolderPath.Name = "textBoxFolderPath";
            this.textBoxFolderPath.ReadOnly = true;
            this.textBoxFolderPath.Size = new System.Drawing.Size(379, 22);
            this.textBoxFolderPath.TabIndex = 17;
            this.textBoxFolderPath.Text = "Выберите папку с .txt файлами...";
            // 
            // buttonFindMostCommonLongWord
            // 
            this.buttonFindMostCommonLongWord.Location = new System.Drawing.Point(12, 12);
            this.buttonFindMostCommonLongWord.Name = "buttonFindMostCommonLongWord";
            this.buttonFindMostCommonLongWord.Size = new System.Drawing.Size(300, 47);
            this.buttonFindMostCommonLongWord.TabIndex = 18;
            this.buttonFindMostCommonLongWord.Text = "Найти самое частое длинное слово\r\nдлины не менее M";
            this.buttonFindMostCommonLongWord.UseVisualStyleBackColor = true;
            // 
            // buttonFindMostFrequentWords
            // 
            this.buttonFindMostFrequentWords.Location = new System.Drawing.Point(12, 65);
            this.buttonFindMostFrequentWords.Name = "buttonFindMostFrequentWords";
            this.buttonFindMostFrequentWords.Size = new System.Drawing.Size(300, 47);
            this.buttonFindMostFrequentWords.TabIndex = 19;
            this.buttonFindMostFrequentWords.Text = "Найти N наиболее частых\r\nуникальных слов";
            this.buttonFindMostFrequentWords.UseVisualStyleBackColor = true;
            // 
            // buttonFindFileWithMostRepeatedWordInTextFiles
            // 
            this.buttonFindFileWithMostRepeatedWordInTextFiles.Location = new System.Drawing.Point(12, 174);
            this.buttonFindFileWithMostRepeatedWordInTextFiles.Name = "buttonFindFileWithMostRepeatedWordInTextFiles";
            this.buttonFindFileWithMostRepeatedWordInTextFiles.Size = new System.Drawing.Size(386, 47);
            this.buttonFindFileWithMostRepeatedWordInTextFiles.TabIndex = 20;
            this.buttonFindFileWithMostRepeatedWordInTextFiles.Text = "Найти файл с наибольшим\r\nколичеством повторений";
            this.buttonFindFileWithMostRepeatedWordInTextFiles.UseVisualStyleBackColor = true;
            // 
            // buttonFindVowelDistribution
            // 
            this.buttonFindVowelDistribution.Location = new System.Drawing.Point(12, 118);
            this.buttonFindVowelDistribution.Name = "buttonFindVowelDistribution";
            this.buttonFindVowelDistribution.Size = new System.Drawing.Size(386, 50);
            this.buttonFindVowelDistribution.TabIndex = 21;
            this.buttonFindVowelDistribution.Text = "Получить распределение гласных";
            this.buttonFindVowelDistribution.UseVisualStyleBackColor = true;
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(260, 252);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(100, 22);
            this.textBoxTime.TabIndex = 22;
            this.textBoxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(228, 227);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(163, 16);
            this.labelTimer.TabIndex = 23;
            this.labelTimer.Text = "Время работы функции:";
            // 
            // numericUpDown_maxWordsToShow
            // 
            this.numericUpDown_maxWordsToShow.Location = new System.Drawing.Point(318, 86);
            this.numericUpDown_maxWordsToShow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_maxWordsToShow.Name = "numericUpDown_maxWordsToShow";
            this.numericUpDown_maxWordsToShow.Size = new System.Drawing.Size(80, 22);
            this.numericUpDown_maxWordsToShow.TabIndex = 24;
            this.numericUpDown_maxWordsToShow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_maxWordsToShow.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "N:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "M:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 453);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_maxWordsToShow);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.buttonFindVowelDistribution);
            this.Controls.Add(this.buttonFindFileWithMostRepeatedWordInTextFiles);
            this.Controls.Add(this.buttonFindMostFrequentWords);
            this.Controls.Add(this.buttonFindMostCommonLongWord);
            this.Controls.Add(this.textBoxFolderPath);
            this.Controls.Add(this.numericUpDown_minLength);
            this.Controls.Add(this.buttonSetFolderPath);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HW4_LINQ_Muradyan_Artur";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_maxWordsToShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonNoLinq;
        private System.Windows.Forms.RadioButton radioButtonLinq;
        private System.Windows.Forms.Button buttonSetFolderPath;
        private System.Windows.Forms.NumericUpDown numericUpDown_minLength;
        private System.Windows.Forms.TextBox textBoxFolderPath;
        private System.Windows.Forms.Button buttonFindMostCommonLongWord;
        private System.Windows.Forms.Button buttonFindMostFrequentWords;
        private System.Windows.Forms.Button buttonFindFileWithMostRepeatedWordInTextFiles;
        private System.Windows.Forms.Button buttonFindVowelDistribution;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.NumericUpDown numericUpDown_maxWordsToShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

