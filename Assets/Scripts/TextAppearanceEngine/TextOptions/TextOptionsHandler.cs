using System.Collections.Generic;
using DataModels;
using TextAppearence.TextOptions;
using TMPro;
using UnityEngine;

namespace TextAppearance.TextOptions
{
    // A class that unites and sets all text options in real time format
    public class TextOptionsHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textField;
        
        [SerializeField] private TextOptionValueHolder characterSizeValueHolder;
        [SerializeField] private TextOptionValueHolder wordSpacingValueHolder;
        [SerializeField] private TextOptionValueHolder lineSpacingValueHolder;
        [SerializeField] private TextOptionValueHolder paragraphSpacingValueHolder;
        [SerializeField] private TextOptionValueHolder fontSizeValueHolder;
        [SerializeField] private TextOptionValueHolder fontValueHolder;

        [SerializeField] private List<FontContainer> fonts;
        
        private void OnEnable()
        {
            characterSizeValueHolder.OnValueChanged += SetCharacterSpacing;
            wordSpacingValueHolder.OnValueChanged += SetWordSpacing;
            lineSpacingValueHolder.OnValueChanged += SetLineSpacing;
            paragraphSpacingValueHolder.OnValueChanged += SetParagraphSpacing;
            fontSizeValueHolder.OnValueChanged += SetFontSize;
            fontValueHolder.OnValueChanged += SetFont;
        }
        
        private void OnDisable()
        {
            characterSizeValueHolder.OnValueChanged -= SetCharacterSpacing;
            wordSpacingValueHolder.OnValueChanged -= SetWordSpacing;
            lineSpacingValueHolder.OnValueChanged -= SetLineSpacing;
            paragraphSpacingValueHolder.OnValueChanged -= SetParagraphSpacing;
            fontSizeValueHolder.OnValueChanged -= SetFontSize;
            fontValueHolder.OnValueChanged -= SetFont;
        }

        private void SetCharacterSpacing(int value)
        {
            textField.characterSpacing = value;
        }
        
        private void SetWordSpacing(int value)
        {
            textField.wordSpacing = value;
        }
        
        private void SetLineSpacing(int value)
        {
            textField.lineSpacing = value;
        }
        
        private void SetParagraphSpacing(int value)
        {
            textField.paragraphSpacing = value;
        }
        
        private void SetFontSize(int value)
        {
            textField.fontSize = value;
            fontSizeValueHolder.buttonText.fontSize = value;
        }
        
        private void SetFont(int value)
        {
            textField.font = fonts[value].font;
            fontValueHolder.buttonText.text = fonts[value].fontName;
        }
    }
}