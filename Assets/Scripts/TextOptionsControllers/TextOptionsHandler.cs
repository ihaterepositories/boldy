using TMPro;
using UnityEngine;

namespace TextOptionsControllers
{
    public class TextOptionsHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textField;
        [SerializeField] private TextOptionValueHolder characterSizeValueHolder;
        [SerializeField] private TextOptionValueHolder wordSpacingValueHolder;
        [SerializeField] private TextOptionValueHolder lineSpacingValueHolder;
        [SerializeField] private TextOptionValueHolder paragraphSpacingValueHolder;

        private void OnEnable()
        {
            characterSizeValueHolder.OnValueChanged += SetCharacterSpacing;
            wordSpacingValueHolder.OnValueChanged += SetWordSpacing;
            lineSpacingValueHolder.OnValueChanged += SetLineSpacing;
            paragraphSpacingValueHolder.OnValueChanged += SetParagraphSpacing;
        }
        
        private void OnDisable()
        {
            characterSizeValueHolder.OnValueChanged -= SetCharacterSpacing;
            wordSpacingValueHolder.OnValueChanged -= SetWordSpacing;
            lineSpacingValueHolder.OnValueChanged -= SetLineSpacing;
            paragraphSpacingValueHolder.OnValueChanged -= SetParagraphSpacing;
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
    }
}