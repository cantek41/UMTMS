using Core.Concreates.Component.Base;
using Core.Concreates.Component.Data;
using Core.Concreates.UI;
using UnityEngine;

namespace Core.Concreates.Component.Controller {

    public class TankController : InteractableController
    {

        public void Awake(){
            data = new TankData();
            menuUI = GameObject.FindAnyObjectByType<PanelUI>();

        }

    }
}
