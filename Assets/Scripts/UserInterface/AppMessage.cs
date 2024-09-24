using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class AppMessage : MonoBehaviour
    {
        [SerializeField] private Text textObject;
        
        public void ShowErrorMessage(string message)
        {
            textObject.text = message;
        }
    }
}