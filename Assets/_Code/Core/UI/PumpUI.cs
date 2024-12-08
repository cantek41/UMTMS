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
    public class PumpUI : _UIBaseForInteractableComponent
    {

        OnOffSliderController inletValveSlider;
        OnOffSliderController outletValveSlider;

        public override void Show(IComponent _data)
        {
            base.Show(_data);
            SliderInitialize(inletValveSlider, "inletValve", data.inletValve);
            SliderInitialize(outletValveSlider, "outletValve", data.outletValve);
        }

    }
}