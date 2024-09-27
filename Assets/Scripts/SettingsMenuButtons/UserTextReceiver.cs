using System;
using OtherUserInterface;
using UnityEngine;
using UnityEngine.UI;

namespace SettingsMenuButtons
{
    public class UserTextReceiver : MonoBehaviour
    {
        [SerializeField] private Button textReceivingButton;
        [SerializeField] private AppMessageText appMessageText;
        public event Action<string> OnTextReceived;

        private void Start()
        {
            textReceivingButton.onClick.AddListener(() =>
            {
                var textFromClipboard = GetTextFromClipboard();
                
                if (string.IsNullOrEmpty(textFromClipboard))
                {
                    ShowErrorMessage();
                    return;
                }
                
                PlayerPrefs.SetString("LastText", textFromClipboard);
                
                OnTextReceived?.Invoke(textFromClipboard);
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
    }
}