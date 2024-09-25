using System;
using UnityEngine;
using UnityEngine.UI;

namespace TextOptionsControllers
{
    public class TextOptionValueHolder : MonoBehaviour
    {
        [SerializeField] private string optionSaveKey;
        [SerializeField] private Button increaseButton;
        [SerializeField] private Button decreaseButton;
        [SerializeField] private int initialValue;
        [SerializeField] private int minValue;
        [SerializeField] private int maxValue;
        [SerializeField] private int valueMultiplier = 1;
        [SerializeField] private Text buttonText;
        
        private int _value;
        private string _defaultButtonText;
        
        public event Action<int> OnValueChanged; 
        
        private void Start()
        {
            _defaultButtonText = buttonText.text;
            increaseButton.onClick.AddListener(IncreaseOption);
            decreaseButton.onClick.AddListener(DecreaseOption);
            LoadLastValue();
        }

        private void OnEnable()
        {
            OnValueChanged += ShowValue;
        }
        
        private void OnDisable()
        {
            OnValueChanged -= ShowValue;
        }

        private void OnApplicationQuit()
        {
            PlayerPrefs.SetInt(optionSaveKey, _value);
        }
        
        private void LoadLastValue()
        {
            _value = PlayerPrefs.GetInt(optionSaveKey, initialValue);
            OnValueChanged?.Invoke(_value);
        }
        
        private void IncreaseOption()
        {
            if (_value < maxValue)
            {
                _value += 1 * valueMultiplier;
                OnValueChanged?.Invoke(_value);
            }
            else
            {
                _value = minValue;
                OnValueChanged?.Invoke(_value);
            }
        }
        
        private void DecreaseOption()
        {
            if (_value > minValue)
            {
                _value -= 1 * valueMultiplier;
                OnValueChanged?.Invoke(_value);
            }
            else
            {
                _value = maxValue;
                OnValueChanged?.Invoke(_value);
            }
        }

        private void ShowValue(int value)
        {
            buttonText.text = _defaultButtonText + value/valueMultiplier;
        }
    }
}