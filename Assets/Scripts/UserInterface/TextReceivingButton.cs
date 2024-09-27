using System;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class TextReceivingButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private AppMessageText appMessageText;
        public static event Action<string> OnTextReceived;

        private void Start()
        {
            button.onClick.AddListener(() =>
            {
                var textFromClipboard = GetTextFromClipboard();
                
                if (string.IsNullOrEmpty(textFromClipboard))
                {
                    ShowErrorMessage();
                    return;
                }
                
                SaveAndSendText(textFromClipboard);
            });
        }
        
        private string GetTextFromClipboard()
        {
            return GUIUtility.systemCopyBuffer;
        }
        
        private void ShowErrorMessage()
        {
            appMessageText.ShowErrorMessage("You have no text in the clipboard...");
        }
        
        private void SaveAndSendText(string text)
        {
            PlayerPrefs.SetString("ReceivedText", text);
            OnTextReceived?.Invoke(text);
        }
    }
}