using System.Collections;
using System.Collections.Generic;
using Core.Abstract.Enum;
using Core.Concreates.Component.Base;
using Core.Concreates.Component.Data;
using Core.Concreates.UI;
using TMPro;
using UnityEngine;

namespace Core.Concreates.Component.Controller
{
    public class OnOffControlPanelController : InteractableController
    {
        [SerializeField]
        public BaseController Component;
        TextMeshPro labelTextMesh;
        Light onLight;
        Light offLight;
        GameObject currentGauge;
        GameObject switchHolder;
        int rotationGauge = -90;
        int rotationSw = 120;

        EnumCompanentStatus preStatus;

        Vector3 switchAngles;

        public void Awake()
        {
            menuUI = GameObject.FindAnyObjectByType<PanelUI>();
        }

        public void Start()
        {
            data = Component.data;
            labelTextMesh = transform.Find("labelContainer/label").gameObject.GetComponent<TextMeshPro>();
            onLight = transform.Find("onButton/onLight").gameObject.GetComponent<Light>();
            offLight = transform.Find("offButton/offLight").gameObject.GetComponent<Light>();
            currentGauge = transform.Find("gauge_amp/gauge").gameObject;
            switchHolder = transform.Find("switchOnOFF/switchHolder").gameObject;
            labelTextMesh.text = componentName;
            switchAngles = new Vector3(switchHolder.transform.eulerAngles.x, switchHolder.transform.eulerAngles.y, rotationSw);
            switchHolder.transform.eulerAngles = switchAngles;
            preStatus = data.status;
            onStatusChange();
        }
        public override void Interact(Transform t)
        {
            menuUI.Show(data);
        }

        public void Update()
        {
            if (preStatus != data.status)
            {
                onStatusChange();
            }
        }

        private void onStatusChange()
        {
            switch (data.status)
            {
                case EnumCompanentStatus.ON:
                    switchAngles.z = 45;
                    rotationGauge = -45;
                    setLight(true);
                    break;
                case EnumCompanentStatus.OFF:
                    switchAngles.z = 120;
                    rotationGauge = -90;
                    setLight(false);
                    break;
            }
            switchHolder.transform.eulerAngles = switchAngles;
            currentGauge.transform.localRotation = Quaternion.Euler(currentGauge.transform.localEulerAngles.x, currentGauge.transform.localEulerAngles.y, rotationGauge); ;
            preStatus = data.status;

        }

        private void setLight(bool onOFF)
        {
            onLight.enabled = onOFF;
            offLight.enabled = !onOFF;

        }



    }
}

