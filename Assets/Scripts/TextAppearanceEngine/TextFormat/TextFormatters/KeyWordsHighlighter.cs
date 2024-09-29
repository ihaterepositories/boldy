using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextAppearanceEngine.TextFormat.TextFormatters
{
    public class KeyWordsHighlighter
    {
        public string Highlight(string text)
        {
            var wordFrequency = GetWordsFrequency(text);
            
            string finalText = "";
            
            var sentences = SplitSentences(text);
            for (int i = 0; i < sentences.Count; i++)
            {
                var keyWord = GetKeyWord(sentences[i], wordFrequency);

                if (!string.IsNullOrEmpty(keyWord))
                {
                    string highlightedWord = $"<u>{keyWord}</u>";
                    sentences[i] = Regex.Replace(sentences[i], $@"\b{keyWord}\b", highlightedWord, RegexOptions.IgnoreCase);
                }

                finalText += sentences[i] + " ";
            }
            
            return finalText;
        }
        
        private Dictionary<string, int> GetWordsFrequency(string inputText)
        {
            var words = inputText.Split(' ').Select(w => w.ToLower()).ToList();
            var wordFrequency = new Dictionary<string, int>();
            foreach (var word in words)
            {
                wordFrequency.TryAdd(word, 0);
                wordFrequency[word]++;
            }
            return wordFrequency;
        }
        
        private List<string> SplitSentences(string inputText)
        {
            return Regex.Split(inputText, @"(?<=[\.!\?])\s+").ToList();
        }
        
        private string GetKeyWord(string sentence, Dictionary<string, int> wordFrequency)
        {
            var words = sentence.Split(' ').Select(w => w.ToLower()).ToList();
            return words.OrderBy(word => wordFrequency.GetValueOrDefault(word, 0)).FirstOrDefault();
        }
    }
}