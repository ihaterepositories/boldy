using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface
{
    public class TextReceivingButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        private AppMessage _appMessage;
        public static event Action<string> OnTextReceived;
        
        [Inject]
        private void Construct(AppMessage appMessage)
        {
            _appMessage = appMessage;
        }

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
            _appMessage.ShowErrorMessage("You have no text in the clipboard...");
        }
        
        private void SaveAndSendText(string text)
        {
            PlayerPrefs.SetString("ReceivedText", text);
            OnTextReceived?.Invoke(text);
        }
    }
}