using TextFormatControllers.TextFormatters;
using TMPro;
using UnityEngine;
using UserInterface;
using Zenject;

namespace TextFormatControllers
{
    public class TextFormatHandler : MonoBehaviour 
    {
        [SerializeField] private TextMeshProUGUI textField;
        private HalfWordPainter _halfWordPainter;
        
        [Inject]
        private void Construct(HalfWordPainter halfWordPainter)
        {
            _halfWordPainter = halfWordPainter;
        }
        
        private void Start()
        {
            ShowLastReceivedText();
        }

        private void OnEnable()
        {
            TextReceivingButton.OnTextReceived += ShowText;
        }
        
        private void OnDisable()
        {
            TextReceivingButton.OnTextReceived -= ShowText;
        }

        private void ShowLastReceivedText()
        {
            var lastText = PlayerPrefs.GetString("ReceivedText", "Copy text somewhere and paste it by clicking \"paste\" the button");
            ShowText(lastText);
        }
        
        private void ShowText(string text)
        {
            textField.text = ReformText(text);
        }
        
        private string ReformText(string text)
        {
            var reformattedText = _halfWordPainter.Paint(text);
            return reformattedText;
        }
    }
}