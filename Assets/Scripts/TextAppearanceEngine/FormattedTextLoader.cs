using SettingsMenuButtons;
using TextAppearanceEngine.TextFormat;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace TextAppearance
{
    // The main class for text output
    public class FormattedTextLoader : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textField;
        [SerializeField] private UserTextReceiver userTextReceiver;
        [FormerlySerializedAs("textFormatHandler")] [SerializeField] private TextFormatter textFormatter;

        private void Start()
        {
            LoadLastText();
        }

        private void OnEnable()
        {
            userTextReceiver.OnTextReceived += ShowFormattedText;
        }

        private void OnDisable()
        {
            userTextReceiver.OnTextReceived -= ShowFormattedText;
        }

        private void LoadLastText()
        {
            var lastText = PlayerPrefs.GetString("LastText", "Copy text somewhere and paste it by clicking \"paste\" button");
            ShowFormattedText(lastText);
        }
        
        private void ShowFormattedText(string text)
        {
            textField.text = textFormatter.FormatText(text);
        }
    }
}