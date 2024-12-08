using UnityEngine;
using Core.Component.Data;
using Core.Concreates.Component.Data;
using Core.Concreates.Component.Base;
using Core.Concreates.UI;

namespace Core.Concreates.Component.Controller
{

    public class SteeringController : InteractableController
    {

        public void Awake()
        {
            data = new GeneralData();
            menuUI =  GameObject.FindObjectOfType<PumpUI>();
            base.Awake();

        }

        public override void Interact(Transform t)
        {        
            data.SData.Pressure = 0.23f;
            
        }

         public void ManualControl()
        {        
            data.SData.CURRENT= 3;            
        }
        

    }
}
