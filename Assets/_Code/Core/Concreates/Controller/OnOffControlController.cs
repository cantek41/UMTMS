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
    public class OnOffControlController : InteractableController
    {
        [SerializeField]
        public BaseController Component;
        TextMeshPro labelTextMesh;
        [SerializeField]
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
            preStatus = data.status;
            if (onLight != null)
            {
                onLight.enabled = data.status == EnumCompanentStatus.ON;
            }
        }
    }
}
