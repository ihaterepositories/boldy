using SettingsMenuButtons;
using TextAppearence.TextFormat.TextFormatters;
using UnityEngine;

namespace TextAppearance.TextFormat
{
    // A class that unites and run all text formatters
    public class TextFormatter : MonoBehaviour 
    {
        [SerializeField] private TextFormattingOptionValueHolder halfWordsPaintingValueHolder;
        
        private readonly HalfWordPainter _halfWordPainter = new();

        public string FormatText(string text)
        {
            var formattedText = text;
            
            if(halfWordsPaintingValueHolder.Value)
                formattedText = _halfWordPainter.Paint(formattedText);
            
            // other formatting

            return formattedText;
        }
    }
}