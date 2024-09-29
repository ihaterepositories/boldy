using System.Text.RegularExpressions;

namespace TextAppearanceEngine.TextFormat.TextFormatters
{
    public class ParagraphHighlighter
    {
        private readonly string _colorToHighlight = "800080";
        
        public string Highlight(string text)
        {
            var firstSpaceIndex = text.IndexOf(' ');
            if (firstSpaceIndex == -1) firstSpaceIndex = text.Length;

            var firstWord = text.Substring(0, firstSpaceIndex);
            
            // Remove all previous HTML tags from the first word
            firstWord = new Regex("<.*?>").Replace(firstWord, string.Empty);
            
            var remainingText = text.Substring(firstSpaceIndex);
            
            text = $"   <b><color=#{_colorToHighlight}>{firstWord}</color></b>{remainingText}";
            
            var highlightedText = string.Join("\n", text);

            return highlightedText;
        }
    }
}