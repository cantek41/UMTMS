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
    public class PanelUI : ComponentUI
    {

        OnOffSliderController onOffSlider;


        public override void Show(IComponent _data)
        {
            base.Show(_data);
            onOffSlider = companentObjectCanvas.transform.Find("onOffValve").gameObject.GetComponent<OnOffSliderController>();
            onOffSlider.setData(data.status, SetStatus);
        }

        private void SetStatus(float val)
        {
            data.status = (EnumCompanentStatus)val;
        }

        private void Update()
        {
            if (data != null)
                Debug.LogWarning("PanelUI " + data.status.ToString());
        }

    }

}
