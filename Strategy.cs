using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW4_LINQ
{
    public interface ICalculationStrategy
    {
        /// <param name="folderPath">путь к папке</param>
        /// <param name="minLength">количество символов</param>
        /// <returns>Самое часто встречающееся длинное слово (длина не меньше M символов)</returns>
        (string filePath, string word, int count) FindMostCommonLongWord(string folderPath, int minLength);

        /// <summary>
        /// данная функция сначала находил файл,
        /// в котором есть слово с НАИБОЛЬШИМ ПОВТОРЕНИЕМ 
        /// и после этого выбирает из этого файла N(maxWordsToShow) слов
        /// в порядке убывания по количеству вхождений
        /// </summary>
        /// <param name="folderPath">путь к папке</param>
        /// <param name="maxWordsToShow">количество слов, которое выводятся в результате</param>
        /// <returns>
        /// maxWordsToShow наиболее часто встречающихся специфических слов
        /// (присутствуют только в каком-то одном файле с повторами)
        /// </returns>
        List<(string filePath, string word, int count)> FindTopNWords(string folderPath, int maxWordsToShow);

        /// <param name="folderPath">путь к папке</param>
        /// <returns>
        /// Файл с наибольшим количеством повторяющихся слов
        /// (слова, которые присутствуют в файле не менее двух раз)
        ///</returns>
        (string filePath, string word, int count) FindFileWithMostRepeatedWordInTextFiles(string folderPath);

        /// <param name="folderPath">путь к файлу</param>
        /// <returns>Распределение гласных букв по частоте</returns>
        Dictionary<char, int> FindVowelDistribution(string folderPath);
    }

    public class LinqSolver : ICalculationStrategy
    {
        public (string filePath, string word, int count) FindMostCommonLongWord(string folderPath, int minLength)
        {
            var files = Directory.GetFiles(folderPath, "*.txt");
            if (files.Length == 0)
            {
                MessageBox.Show("Текстовые файлы не найдены в данной папке!");
                return ("-", "-", 0);
            }

            var result = files.Select(file => File.ReadAllText(file))
                              .SelectMany(text => Regex.Split(text, @"\W+"))
                              .Where(word => word.Length >= minLength)
                              .GroupBy(word => word)
                              .OrderByDescending(group => group.Count())
                              .Select(group => (filePath: "", word: group.Key, count: group.Count()))
                              .FirstOrDefault();

            if (result.word == null)
            {
                MessageBox.Show("Не найдено слов длиной не менее " + minLength + " символов!");
                return ("-", "-", 0);
            }

            result.filePath = files.FirstOrDefault(file => Regex.IsMatch(File.ReadAllText(file), $@"\b{result.word}\b"));

            return result;
        }

        public List<(string filePath, string word, int count)> FindTopNWords(string folderPath, int maxWordsToShow)
        {
            var files = Directory.GetFiles(folderPath).Where(file => file.EndsWith(".txt"));
            if (!files.Any())
            {
                MessageBox.Show("В папке не найдено текстовых файлов");
                return new List<(string filePath, string word, int count)>();
            }
            var result = new List<(string filePath, string word, int count)>();
            var maxCount = 0;
            var maxFile = "";
            foreach (var file in files)
            {
                var wordCounts = File.ReadAllText(file)
                    .Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .GroupBy(word => word)
                    .Select(group => (word: group.Key, count: group.Count()))
                    .OrderByDescending(tuple => tuple.count);
                var topWordCount = wordCounts.First().count;
                if (topWordCount > maxCount)
                {
                    maxCount = topWordCount;
                    maxFile = file;
                }
            }
            var topNWords = File.ReadAllText(maxFile)
                .Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .GroupBy(word => word)
                .Select(group => (word: group.Key, count: group.Count()))
                .OrderByDescending(tuple => tuple.count)
                .Take(maxWordsToShow);
            result.AddRange(topNWords.Select(tuple => (filePath: maxFile, tuple.word, tuple.count)));
            return result;
        }

        public (string filePath, string word, int count) FindFileWithMostRepeatedWordInTextFiles(string folderPath)
        {
            var textFiles = Directory.EnumerateFiles(folderPath, "*.txt");
            if (!textFiles.Any())
            {
                MessageBox.Show("Подходящий файл не найден");
                return ("Подходящий файл не найден", "-", 0);
            }

            var result = textFiles.Select(file => new
            {
                FilePath = file,
                MostCommonWord = File.ReadAllText(file)
                    .Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(word => word.All(char.IsLetterOrDigit))
                    .GroupBy(word => word)
                    .OrderByDescending(group => group.Count())
                    .FirstOrDefault()
            })
            .Where(x => x.MostCommonWord != null)
            .OrderByDescending(x => x.MostCommonWord.Count())
            .FirstOrDefault();

            if (result == null || result.MostCommonWord.Count() < 2)
            {
                MessageBox.Show("Подходящий файл не найден");
                return ("Подходящий файл не найден", "-", 0);
            }

            return (result.FilePath, result.MostCommonWord.Key, result.MostCommonWord.Count());
        }

        public Dictionary<char, int> FindVowelDistribution(string folderPath)
        {
            char[] vowels = new[] { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
            var files = Directory.GetFiles(folderPath, "*.txt");
            var result = new Dictionary<char, int>();
            if (files.Length == 0)
            {
                MessageBox.Show("Текстовые файлы не найдены.");
                return result;
            }
            
            foreach (var file in files)
            {
                var text = File.ReadAllText(file);
                var vowelGroups = text.ToLower().Where(c => vowels.Contains(c)).GroupBy(c => c);

                foreach (var group in vowelGroups)
                {
                    if (result.ContainsKey(group.Key))
                        result[group.Key] += group.Count();
                    else
                        result.Add(group.Key, group.Count());
                }
            }
            if (result.Count == 0)
            {
                MessageBox.Show("Гласные не найдены.");
                return result;
            }
            return result.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }
    }

    public class NoLinqSolver : ICalculationStrategy
    {

        public (string filePath, string word, int count) FindMostCommonLongWord(string folderPath, int minLength)
        {
            var files = Directory.GetFiles(folderPath, "*.txt");
            if (files.Length == 0)
            {
                MessageBox.Show("Текстовые файлы не найдены в данной папке!");
                return ("-", "-", 0);
            }

            var wordCounts = new Dictionary<string, int>();
            foreach (var file in files)
            {
                var text = File.ReadAllText(file);
                var words = Regex.Split(text, @"\W+");
                foreach (var word in words)
                {
                    if (word.Length >= minLength)
                    {
                        if (wordCounts.ContainsKey(word))
                        {
                            wordCounts[word]++;
                        }
                        else
                        {
                            wordCounts[word] = 1;
                        }
                    }
                }
            }

            if (wordCounts.Count == 0)
            {
                MessageBox.Show("Не найдено слов длиной не менее " + minLength + " символов!");
                return ("-", "-", 0);
            }

            string mostCommonWord = null;
            int maxCount = 0;
            foreach (var pair in wordCounts)
            {
                if (pair.Value > maxCount)
                {
                    mostCommonWord = pair.Key;
                    maxCount = pair.Value;
                }
            }

            string filePath = null;
            foreach (var file in files)
            {
                var text = File.ReadAllText(file);
                if (Regex.IsMatch(text, $@"\b{mostCommonWord}\b"))
                {
                    filePath = file;
                    break;
                }
            }

            return (filePath, mostCommonWord, maxCount);
        }

        public List<(string filePath, string word, int count)> FindTopNWords(string folderPath, int maxWordsToShow)
        {
            var files = Directory.GetFiles(folderPath);
            var txtFiles = new List<string>();
            foreach (var file in files)
            {
                if (file.EndsWith(".txt"))
                txtFiles.Add(file);
            }
            if (txtFiles.Count == 0)
            {
                MessageBox.Show("В папке не найдено текстовых файлов");
                return new List<(string filePath, string word, int count)>();
            }

            var result = new List<(string filePath, string word, int count)>();
            var maxCount = 0;
            var maxFile = "";
            foreach (var file in txtFiles)
            {
                var text = File.ReadAllText(file);
                var words = text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                var wordCounts = new Dictionary<string, int>();
                foreach (var word in words)
                {
                    if (wordCounts.ContainsKey(word))
                    wordCounts[word]++;
                    else
                    wordCounts[word] = 1;
                }
                var topWordCount = 0;
                foreach (var kvp in wordCounts)
                {
                    if (kvp.Value > topWordCount)
                    topWordCount = kvp.Value;
                }
                if (topWordCount > maxCount)
                {
                    maxCount = topWordCount;
                    maxFile = file;
                }
            }
            var textMaxFile = File.ReadAllText(maxFile);
            var wordsMaxFile = textMaxFile.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var wordCountsMaxFile = new Dictionary<string, int>();
            foreach (var word in wordsMaxFile)
            {
                if (wordCountsMaxFile.ContainsKey(word))
                    wordCountsMaxFile[word]++;
                else
                    wordCountsMaxFile[word] = 1;
            }
            var sortedWordCountsMaxFile = new List<KeyValuePair<string, int>>(wordCountsMaxFile);
            sortedWordCountsMaxFile.Sort((x, y) => y.Value.CompareTo(x.Value));
            for (int i = 0; i < maxWordsToShow && i < sortedWordCountsMaxFile.Count; i++)
            {
                result.Add((filePath: maxFile, sortedWordCountsMaxFile[i].Key, sortedWordCountsMaxFile[i].Value));
            }
            return result;
        }

        public (string filePath, string word, int count) FindFileWithMostRepeatedWordInTextFiles(string folderPath)
        {
            var textFiles = Directory.EnumerateFiles(folderPath, "*.txt");
            if (!textFiles.Any())
            {
                MessageBox.Show("Подходящий файл не найден");
                return ("Подходящий файл не найден", "-", 0);
            }

            string mostCommonFilePath = null;
            string mostCommonWord = null;
            int mostCommonCount = 0;

            foreach (var file in textFiles)
            {
                var wordCounts = new Dictionary<string, int>();
                var words = File.ReadAllText(file)
                    .Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    if (word.All(char.IsLetterOrDigit))
                    {
                        if (wordCounts.ContainsKey(word))
                            wordCounts[word]++;
                        else
                            wordCounts[word] = 1;
                    }
                }

                foreach (var kvp in wordCounts)
                {
                    if (kvp.Value > mostCommonCount)
                    {
                        mostCommonFilePath = file;
                        mostCommonWord = kvp.Key;
                        mostCommonCount = kvp.Value;
                    }
                }
            }

            if (mostCommonCount < 2)
            {
                MessageBox.Show("Подходящий файл не найден");
                return ("Подходящий файл не найден", "-", 0);
            }

            return (mostCommonFilePath, mostCommonWord, mostCommonCount);
        }

        public Dictionary<char, int> FindVowelDistribution(string folderPath)
        {
            char[] vowels = new[] { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
            var files = Directory.GetFiles(folderPath, "*.txt");
            var result = new Dictionary<char, int>();
            if (files.Length == 0)
            {
                MessageBox.Show("Текстовые файлы не найдены.");
                return result;
            }

            foreach (var file in files)
            {
                var text = File.ReadAllText(file);
                foreach (char c in text.ToLower())
                {
                    if (vowels.Contains(c))
                    {
                        if (result.ContainsKey(c))
                            result[c]++;
                        else
                            result.Add(c, 1);
                    }
                }
            }

            if (result.Count == 0)
            {
                MessageBox.Show("Гласные не найдены.");
                return result;
            }

            var sortedResult = new Dictionary<char, int>();
            foreach (var kvp in result.OrderByDescending(x => x.Value))
                sortedResult.Add(kvp.Key, kvp.Value);

            return sortedResult;
        }
    }
}
