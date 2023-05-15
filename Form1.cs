using HW4_LINQ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HW4_LINQ
{
    public partial class Form1 : Form
    {
        private ICalculationStrategy linqStrategy = new LinqSolver();
        private ICalculationStrategy noLinqStrategy = new NoLinqSolver();
        private ICalculationStrategy currentStrategy;
        
        private DataTable dataTable = new DataTable();

        Stopwatch stopwatch = new Stopwatch();

        private string folderPath = "";

        private int minLength;
        private int maxWordsToShow;

        public Form1()
        {
            InitializeComponent();
            currentStrategy = linqStrategy;
            minLength = (int)numericUpDown_maxWordsToShow.Value;
            maxWordsToShow = (int)numericUpDown_maxWordsToShow.Value;

            // привязка таблица datagridview и chart к источнику dataTable
            dataGridView.DataSource = dataTable;
            chart.DataSource = dataTable;

            buttonSetFolderPath.Click += ButtonSetFolderPath_Click;

            radioButtonLinq.CheckedChanged += RadioButton_CheckedChanged;
            radioButtonNoLinq.CheckedChanged += RadioButton_CheckedChanged;

            numericUpDown_minLength.ValueChanged += NumericUpDown_minLength_ValueChanged;
            numericUpDown_maxWordsToShow.ValueChanged += NumericUpDown_maxWordsToShow_ValueChanged;

            buttonFindMostCommonLongWord.Enabled = false;
            buttonFindVowelDistribution.Enabled = false;
            buttonFindMostFrequentWords.Enabled = false;
            buttonFindFileWithMostRepeatedWordInTextFiles.Enabled = false;

            buttonFindMostCommonLongWord.Click += ButtonFindMostCommonLongWord_Click;
            buttonFindMostFrequentWords.Click += ButtonFindMostFrequentWords_Click;
            buttonFindVowelDistribution.Click += ButtonFindVowelDistribution_Click;
            buttonFindFileWithMostRepeatedWordInTextFiles.Click += ButtonFindFileWithMostRepeatedWordInTextFiles_Click; ;
        }

        
        private void NumericUpDown_minLength_ValueChanged(object sender, EventArgs e)
        {
            minLength = (int)numericUpDown_minLength.Value;
        }
        private void NumericUpDown_maxWordsToShow_ValueChanged(object sender, EventArgs e)
        {
            maxWordsToShow = (int)numericUpDown_maxWordsToShow.Value;
        }
       
        // выбор папки с файлами
        private void ButtonSetFolderPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                folderPath = fbd.SelectedPath;
                textBoxFolderPath.Text = folderPath;
                buttonFindFileWithMostRepeatedWordInTextFiles.Enabled = true;
                buttonFindMostCommonLongWord.Enabled = true;
                buttonFindVowelDistribution.Enabled = true;
                buttonFindMostFrequentWords.Enabled = true;
            }
        }

        // выбор режима функций
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLinq.Checked)
            {
                currentStrategy = linqStrategy;
            }
            else if (radioButtonNoLinq.Checked)
            {
                currentStrategy = noLinqStrategy;
            }
        }

        private void ButtonFindMostCommonLongWord_Click(object sender, EventArgs e)
        {
            dataTable.Rows.Clear();
            dataTable.Columns.Clear();
            chart.Series.Clear();

            stopwatch.Reset();
            stopwatch.Start();
            var result = currentStrategy.FindMostCommonLongWord(folderPath, minLength);
            stopwatch.Stop();
            textBoxTime.Text = stopwatch.ElapsedMilliseconds.ToString() + " мсек";

            dataTable.Columns.Add("Путь к файлу", typeof(string));
            dataTable.Columns.Add("Слово", typeof(string));
            dataTable.Columns.Add("Количество вхождений", typeof(int));

            dataTable.Rows.Add(result.filePath, result.word, result.count);

            var series = chart.Series.Add("Количество вхождений");
            series.Points.AddXY(result.word, result.count);
        }

        private void ButtonFindMostFrequentWords_Click(object sender, EventArgs e)
        {
            dataTable.Rows.Clear();
            dataTable.Columns.Clear();
            chart.Series.Clear();

            stopwatch.Reset();
            stopwatch.Start();

            /// <summary>
            /// данная функция сначала находил файл,
            /// в котором есть слово с НАИБОЛЬШИМ ПОВТОРЕНИЕМ 
            /// и после этого выбирает из этого файла N(maxWordsToShow) слов
            /// в порядке убывания по количеству вхождений
            /// </summary>
            var topNWords = currentStrategy.FindTopNWords(folderPath, maxWordsToShow);
            
            stopwatch.Stop();
            textBoxTime.Text = stopwatch.ElapsedMilliseconds.ToString() + " мсек";

            dataTable.Columns.Add("Путь к файлу", typeof(string));
            dataTable.Columns.Add("Слово", typeof(string));
            dataTable.Columns.Add("Количество вхождений", typeof(int));
            foreach (var wordInfo in topNWords)
            {
                dataTable.Rows.Add(wordInfo.filePath, wordInfo.word, wordInfo.count);
            }

            var series = new Series("Количество вхождений слов");
            series.ChartType = SeriesChartType.Column;

            chart.Series.Add(series);

            foreach (var wordInfo in topNWords)
            {
                series.Points.AddXY(wordInfo.word, wordInfo.count);
            }
        }

        private void ButtonFindVowelDistribution_Click(object sender, EventArgs e)
        {
            dataTable.Rows.Clear();
            dataTable.Columns.Clear();
            chart.Series.Clear();

            stopwatch.Reset();
            stopwatch.Start();
            var results = currentStrategy.FindVowelDistribution(folderPath);
            stopwatch.Stop();
            textBoxTime.Text = stopwatch.ElapsedMilliseconds.ToString() + " мсек";

            dataTable.Columns.Add("Гласная", typeof(char));
            dataTable.Columns.Add("Количество", typeof(int));

            foreach (var pair in results)
            {
                dataTable.Rows.Add(pair.Key, pair.Value);
            }

            var series = chart.Series.Add("Гласные");
            series.ChartType = SeriesChartType.Column;

            foreach (var pair in results)
            {
                series.Points.AddXY(pair.Key.ToString(), pair.Value);
            }
        }
        private void ButtonFindFileWithMostRepeatedWordInTextFiles_Click(object sender, EventArgs e)
        {
            dataTable.Rows.Clear();
            dataTable.Columns.Clear();
            chart.Series.Clear();

            stopwatch.Reset();
            stopwatch.Start();
            var result = currentStrategy.FindFileWithMostRepeatedWordInTextFiles(folderPath);
            stopwatch.Stop();
            textBoxTime.Text = stopwatch.ElapsedMilliseconds.ToString() + " мсек";

            dataTable.Columns.Add("Путь к файлу", typeof(string));
            dataTable.Columns.Add("Слово", typeof(string));
            dataTable.Columns.Add("Количество вхождений", typeof(int));

            var row = dataTable.NewRow();
            row["Путь к файлу"] = result.Item1;
            row["Слово"] = result.Item2;
            row["Количество вхождений"] = result.Item3;
            dataTable.Rows.Add(row);

            chart.Series.Add("Самое частое слово");
            chart.Series["Самое частое слово"].Points.AddXY(result.word, result.count);
        }
    }
}
