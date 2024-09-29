using SettingsMenuButtons;
using TextAppearanceEngine.TextFormat.TextFormatters;
using UnityEngine;

namespace TextAppearanceEngine.TextFormat
{
    // A class that unites and run all text formatters
    public class TextFormatter : MonoBehaviour 
    {
        [SerializeField] private TextFormattingOptionValueHolder halfWordsPaintingValueHolder;
        [SerializeField] private TextFormattingOptionValueHolder paragraphHighlightingValueHolder;
        [SerializeField] private TextFormattingOptionValueHolder keywordsHighlightingValueHolder;
        
        private readonly WordsHalvesPainter _wordsHalvesPainter = new();
        private readonly ParagraphHighlighter _paragraphHighlighter = new();
        private readonly KeyWordsHighlighter _keyWordsHighlighter = new();

        public string FormatText(string text)
        {
            var formattedText = string.Empty;
            
            var paragraphs = text.Split(
                new[] { '\n', '\r' }, 
                System.StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < paragraphs.Length; i++)
            {
                if (keywordsHighlightingValueHolder.Value)
                    paragraphs[i] = _keyWordsHighlighter.Highlight(paragraphs[i]);

                if (halfWordsPaintingValueHolder.Value)
                    paragraphs[i] = _wordsHalvesPainter.Paint(paragraphs[i]);

                if (paragraphHighlightingValueHolder.Value)
                    paragraphs[i] = _paragraphHighlighter.Highlight(paragraphs[i]);
                
                formattedText += paragraphs[i] + "\n";
            }

            return formattedText;
        }
    }
}