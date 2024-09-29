using System.Text.RegularExpressions;

namespace TextAppearanceEngine.TextFormat.TextFormatters
{
    public class ParagraphHighlighter
    {
        private readonly string _colorToHighlight = "800080";
        
        public string Highlight(string text)
        {
            var paragraphs = text.Split(
                new[] { '\n', '\r' }, 
                System.StringSplitOptions.RemoveEmptyEntries);
            
            for (var i = 0; i < paragraphs.Length; i++)
            {
                var paragraph = paragraphs[i];
                var firstSpaceIndex = paragraph.IndexOf(' ');
                if (firstSpaceIndex == -1) firstSpaceIndex = paragraph.Length;

                var firstWord = paragraph.Substring(0, firstSpaceIndex);
                
                // Remove all previous HTML tags from the first word
                firstWord = new Regex("<.*?>").Replace(firstWord, string.Empty);
                
                var remainingText = paragraph.Substring(firstSpaceIndex);
                
                paragraphs[i] = $"   <b><color=#{_colorToHighlight}>{firstWord}</color></b>{remainingText}";
            }
            
            var highlightedText = string.Join("\n", paragraphs);

            return highlightedText;
        }
    }
}