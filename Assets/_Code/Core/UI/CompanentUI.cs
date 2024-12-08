using UnityEngine;
using TMPro;
using Core.Concreates.Component.Base;
using Core.Concreates.Component.Data;
using StarterAssets;
using System.Numerics;


namespace Core.Concreates.UI
{

    public class ComponentUI : MonoBehaviour
    {

        protected IComponent data;
        protected InteractableController controller;

        [SerializeField]
        public GameObject companentObjectCanvas;
        protected MessageUI messageUI;
        protected PlayerInteractBehaviour playerInteract;
        protected PlayerInteractUI interactCompanentName;
        protected FirstPersonController player;

        private void Start()
        {
            interactCompanentName = GameObject.FindAnyObjectByType<PlayerInteractUI>();
            playerInteract = GameObject.FindAnyObjectByType<PlayerInteractBehaviour>();
            messageUI = GameObject.Find("MessageUI").GetComponent<MessageUI>();
            player = GameObject.FindAnyObjectByType<FirstPersonController>();
        }

       

        public virtual void Show(InteractableController _controller)
        {
            controller = _controller;
            Show(controller.data);

        }
        public virtual void Show(IComponent _data)
        {
            data = _data;
            ShowCanvas();
            var title = companentObjectCanvas.transform.Find("title").gameObject.GetComponent<TextMeshProUGUI>();
            title.text = playerInteract.GetInteractableObjectWithCam().ComponentName();

        }

        protected void ShowCanvas()
        {
            interactCompanentName.setIsWorking(true);
            companentObjectCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
           player.LockCameraPosition = true;
        }


        public void Close()
        {
            HideCanvas();
        }

        // Update is called once per frame
        protected void HideCanvas()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            interactCompanentName.setIsWorking(false);
            companentObjectCanvas.SetActive(false);
            player.LockCameraPosition = false;



        }


    }

}
