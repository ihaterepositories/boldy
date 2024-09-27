using System;
using UnityEngine;
using UnityEngine.UI;

namespace SettingsMenuButtons
{
    public class TextFormattingOptionValueHolder : MonoBehaviour
    {
        [SerializeField] private string optionSaveKey;
        [SerializeField] private Button button;
        [SerializeField] private Text buttonText;

        private string _defaultButtonText;
        
        public bool Value { get; private set; }

        private void Awake()
        {
            _defaultButtonText = buttonText.text;
            
            button.onClick.AddListener(() =>
            {
                Value = !Value; 
                ShowValue();
            });
            
            LoadLastValue();
        }

        private void OnApplicationQuit()
        {
            PlayerPrefs.SetInt(optionSaveKey, Convert.ToInt32(Value));
        }

        private void LoadLastValue()
        {
            Value = Convert.ToBoolean(PlayerPrefs.GetInt(optionSaveKey, 1));
            ShowValue();
        }
        
        private void ShowValue()
        {
            buttonText.text = _defaultButtonText;
            buttonText.text += Value ? "on" : "off";
        }
    }
}