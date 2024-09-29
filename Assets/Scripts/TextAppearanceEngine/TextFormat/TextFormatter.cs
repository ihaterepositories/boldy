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
        
        private readonly HalfWordPainter _halfWordPainter = new();
        private readonly ParagraphHighlighter _paragraphHighlighter = new();

        public string FormatText(string text)
        {
            var formattedText = text;
            
            if(halfWordsPaintingValueHolder.Value)
                formattedText = _halfWordPainter.Paint(formattedText);
            
            if(paragraphHighlightingValueHolder.Value)
                formattedText = _paragraphHighlighter.Highlight(formattedText);

            return formattedText;
        }
    }
}