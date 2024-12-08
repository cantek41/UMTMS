using TMPro;
using UnityEngine;

namespace Core.Concreates.Component.Controller
{

    public class MessageController : MonoBehaviour
    {
        [SerializeField]
        public GameObject companentObjectCanvas;
        protected Canvas alertCanvas;
        protected TextMeshProUGUI alertMessage;
        private void Start()
        {
            var container = companentObjectCanvas.transform.Find("alertCanvas");
            if (container != null)
            {
                alertCanvas = container.gameObject.GetComponent<Canvas>();
                alertMessage = container.gameObject.GetComponentInChildren<TextMeshProUGUI>();
                alertCanvas.enabled = false;
            }
        }

        public void showMessage(string message)
        {
            Debug.Log(message);
            if (alertMessage != null)
            {
                alertCanvas.enabled = true;
                alertMessage.text = message;
            }
        }

        public void Close()
        {
             if (alertCanvas != null)
            {
                alertCanvas.enabled = false;
            }
        }

    }
}