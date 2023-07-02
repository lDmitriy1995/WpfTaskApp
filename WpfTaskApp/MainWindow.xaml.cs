using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfTaskApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AnalyzeButton_Click(object sender, RoutedEventArgs e)
        {
            string text = InputTextBox.Text;

            Task.Run(() =>
            {
                int sentenceCount = CountSentences(text);
                int characterCount = CountCharacters(text);
                int wordCount = CountWords(text);
                int questionCount = CountQuestions(text);
                int exclamationCount = CountExclamations(text);

                // Выводим результаты анализа в UI-потоке
                Dispatcher.Invoke(() =>
                {
                    ReportTextBox.Text = $"Количество предложений: {sentenceCount}\n" +
                                         $"Количество символов: {characterCount}\n" +
                                         $"Количество слов: {wordCount}\n" +
                                         $"Количество вопросительных предложений: {questionCount}\n" +
                                         $"Количество восклицательных предложений: {exclamationCount}";
                });
            });
        }

        private int CountSentences(string text)
        {
            // Здесь реализация подсчета количества предложений в тексте
            // Можете использовать собственный алгоритм или стороннюю библиотеку для анализа текста
            // В данном примере просто подсчитываем количество точек в тексте
            int count = 0;
            foreach (char c in text)
            {
                if (c == '.')
                    count++;
            }
            return count;
        }

        private int CountCharacters(string text)
        {
            // Здесь реализация подсчета количества символов в тексте
            return text.Length;
        }

        private int CountWords(string text)
        {
            // Здесь реализация подсчета количества слов в тексте
            // Можете использовать собственный алгоритм или стороннюю библиотеку для анализа текста
            // В данном примере просто разделяем текст по пробелам и подсчитываем количество полученных частей
            string[] words = text.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        private int CountQuestions(string text)
        {
            // Здесь реализация подсчета количества вопросительных предложений в тексте
            // Можете использовать собственный алгоритм или стороннюю библиотеку для анализа текста
            // В данном примере просто подсчитываем количество вопросительных знаков в тексте
            int count = 0;
            foreach (char c in text)
            {
                if (c == '?')
                    count++;
            }
            return count;
        }

        private int CountExclamations(string text)
        {
            // Здесь реализация подсчета количества восклицательных предложений в тексте
            // Можете использовать собственный алгоритм или стороннюю библиотеку для анализа текста
            // В данном примере просто подсчитываем количество восклицательных знаков в тексте
            int count = 0;
            foreach (char c in text)
            {
                if (c == '!')
                    count++;
            }
            return count;
        }
    }
}
