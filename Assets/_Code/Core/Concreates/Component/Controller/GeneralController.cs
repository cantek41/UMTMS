using UnityEngine;
using Core.Component.Data;
using Core.Concreates.Component.Data;
using Core.Concreates.Component.Base;
using Core.Concreates.UI;

namespace Core.Concreates.Component.Controller
{

    public class GeneralController : InteractableController
    {

        public void Awake()
        {
            data = new GeneralData();
            menuUI =  GameObject.FindObjectOfType<PumpUI>();
            base.Awake();

        }

        public override void Interact(Transform t)
        {        
            menuUI.Show(this);
        }

        public void Update()
        {
            VoiceControl();
        }
        

    }
}
