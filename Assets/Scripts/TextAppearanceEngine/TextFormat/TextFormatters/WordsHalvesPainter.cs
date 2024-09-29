using UnityEngine;

namespace TextAppearanceEngine.TextFormat.TextFormatters
{
    public class WordsHalvesPainter
    {
        private readonly string _colorToPaint = 
            ColorUtility.ToHtmlStringRGB(new Color(0.1f, 0.1f, 0.1f));
        
        public string Paint(string text)
        {
            var paintedText = "";
            
            var words = text.Split(' ');

            foreach (var word in words)
            {
                if (word.Length > 1)
                {
                    paintedText += PaintWord(word) + " ";
                }
                else
                {
                    paintedText += word + " ";
                }
            }

            return paintedText;
        }
        
        private string PaintWord(string word)
        {
            var halfLength = word.Length / 2;
            var boldPart = word.Substring(0, halfLength);
            var normalPart = word.Substring(halfLength);
            return $"<b><color=#{_colorToPaint}>{boldPart}</color></b>{normalPart}";
        }
    }
}
