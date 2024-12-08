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
    public abstract class _UIBaseForInteractableComponent : ComponentUI
    {

        public override void Show(IComponent _data)
        {
            
            base.Show(_data);
            var status = companentObjectCanvas.transform.Find("statusVal").gameObject.GetComponent<TextMeshProUGUI>();
            status.text = data.status.ToString();
            if (_data.status == EnumCompanentStatus.ON)
            {
               // messageUI.ShowWithComponentMessageOnOFF(this);

            }
        }

        protected void SliderInitialize(OnOffSliderController slider, string componentName, OnOffData value)
        {
            slider = companentObjectCanvas.transform.Find(componentName).gameObject.GetComponent<OnOffSliderController>();
            slider.setData(value);
        }

        public void Remove()
        {
            if (!checkValves())
                return;

            if (data.actionStatus == EnumCompanentActionStatus.INSTALL)
            {
                data.actionStatus = EnumCompanentActionStatus.REMOVE;
                controller.Remove();
            }
            else
            {
                messageUI.Show("Companent have already remove");

            }

        }
        public void Repair()
        {
            if (!checkValves())
                return;

            if (data.actionStatus != EnumCompanentActionStatus.INSTALL)
            {
                controller.Repair();
            }
            else
            {
                messageUI.Show("Companent must be remove");
            }

        }
        public void ReInstall()
        {
            if (!checkValves())
                return;

            if (data.actionStatus == EnumCompanentActionStatus.REMOVE)
            {
                data.actionStatus = EnumCompanentActionStatus.INSTALL;
                controller.ReInstall();

            }
            else
            {
                messageUI.Show("Companent must be remove");

            }

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
                messageUI.Show("Outlet valve must be close");
                return false;
            }
            return true;

        }


    }
}