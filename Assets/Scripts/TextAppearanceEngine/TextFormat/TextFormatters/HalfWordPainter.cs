using UnityEngine;

namespace TextAppearanceEngine.TextFormat.TextFormatters
{
    public class HalfWordPainter
    {
        private readonly string _colorToPaint = 
            ColorUtility.ToHtmlStringRGB(new Color(0.1f, 0.1f, 0.1f));
        
        public string Paint(string text)
        {
            var lines = text.Split('\n');

            var paintedText = "";

            foreach (var line in lines)
            {
                var words = line.Split(' ');

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
                
                paintedText = paintedText.TrimEnd() + "\n";
            }

            return paintedText.TrimEnd();
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
