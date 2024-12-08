using Core.Component.Data;
using Core.Concreates.Component.Base;
using Core.Concreates.Component.Data;
using Core.Concreates.UI;
using UnityEngine;

namespace Core.Concreates.Component.Controller
{
    public class SmokeController : InteractableController
    {
        public void Awake()
        {
            data = new GeneralData();
            menuUI = GameObject.FindObjectOfType<PumpUI>();
            base.Awake();
        }

        public override void Interact(Transform t)
        {
            data.ElectricData.CURRENT = 1;
            //base.Interact(t);
        }

        public virtual void ReInstall()
        {
            data.ElectricData.CURRENT = 1;
            base.ReInstall();
        }
    }
}
