using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class AppMessageText : MonoBehaviour
    {
        [SerializeField] private Text textObject;
        
        public void ShowErrorMessage(string message)
        {
            textObject.text = message;
        }
    }
}