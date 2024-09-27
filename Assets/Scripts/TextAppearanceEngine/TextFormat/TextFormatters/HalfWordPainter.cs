using UnityEngine;

namespace TextAppearence.TextFormat.TextFormatters
{
    public class HalfWordPainter
    {
        private Color boldColor = new Color(0.1f, 0.1f, 0.1f);
        
        public string Paint(string text)
        {
            string[] lines = text.Split('\n');  // Розділяємо текст на абзаци за символами нового рядка
            string colorHex = ColorUtility.ToHtmlStringRGB(boldColor);  // Перетворюємо колір на hex-код

            string formattedText = "";

            foreach (string line in lines)
            {
                string[] words = line.Split(' ');  // Розділяємо рядок на слова

                foreach (string word in words)
                {
                    if (word.Length > 1)  // Перевіряємо, щоб слово було не порожнім
                    {
                        int halfLength = word.Length / 2;
                        string boldPart = word.Substring(0, halfLength);  // Перша половина слова
                        string normalPart = word.Substring(halfLength);   // Друга половина слова

                        // Форматуємо кожне слово
                        formattedText += $"<b><color=#{colorHex}>{boldPart}</color></b>{normalPart} ";
                    }
                    else
                    {
                        // Якщо слово має одну літеру або порожнє, просто додаємо його
                        formattedText += word + " ";
                    }
                }

                // Додаємо символ нового рядка після кожного рядка (або абзацу)
                formattedText = formattedText.TrimEnd() + "\n";
            }

            return formattedText.TrimEnd();  // Видаляємо зайві пробіли і символи нового рядка в кінці
        }
    }
}
