using UnityEngine;
using System.Collections;
using TMPro;
using Core.Concreates.Component.Base;
using System;
using Core.Concreates.Component.Controller;
using Core.Concreates.Component.Data;
using Core.Abstract.Enum;

namespace Core.Concreates.UI
{

    public class CoolerUI : _UIBaseForInteractableComponent
    {

        OnOffSliderController inletValveHOTSlider;
        OnOffSliderController outletValveHOTSlider;
        OnOffSliderController inletValveCOOLSlider;
        OnOffSliderController outletValveCOOLSlider;

        public override void Show(IComponent _data)
        {
            base.Show(_data);
            SliderInitialize(inletValveHOTSlider, "inletValve_1", data.inletValve);
            SliderInitialize(outletValveHOTSlider, "outletValve_1", data.outletValve);
            SliderInitialize(inletValveCOOLSlider, "inletValve_2", data.inletCOOLValve);
            SliderInitialize(outletValveCOOLSlider, "outletValve_2", data.outletCOOLValve);

        }


        private bool checkValves()
        {
            if (data.inletValve.GetStatus())
            {
                messageUI.Show("Inlet valve must be close");
                return false;
            }
            if (data.outletValve.GetStatus())
            {
                messageUI.SendMessage("Outlet valve must be close");
                return false;
            }
            return true;

        }


    }
}