using System;
using System.Collections;
using System.Collections.Generic;
using Core.Abstract.AlarmSystem;
using Core.Abstract.Enum;
using Core.Concreates.Component.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Core.Concreates.Component.Controller
{

    public class OnOffSliderController : MonoBehaviour
    {
        private Slider slider;
        private TextMeshProUGUI textUI;

        [SerializeField]
        string Text;

        OnOffData onOffData;
        EnumCompanentStatus componentStatus;

        void Start()
        {
            slider = GetComponentInChildren<Slider>();
            textUI = GetComponentInChildren<TextMeshProUGUI>();
            textUI.text = Text;
        }
        public void setData(OnOffData _data)
        {
            
            onOffData = _data;
            if (slider == null)
                slider = GetComponentInChildren<Slider>();
            slider.value = onOffData.GetStatusFloat();
            slider.onValueChanged.AddListener(SliderChangeONOFF);

        }
        private void SliderChangeONOFF(float arg0)
        {
            onOffData.SetStatus(arg0 == 0 ? false : true);
        }

        public void setData(EnumCompanentStatus _data, UnityAction<float> changeStatus)
        {
            Debug.LogWarning("setData");
            componentStatus = _data;
            if (slider == null)
                slider = GetComponentInChildren<Slider>();
            slider.value = (float)componentStatus;
            slider.onValueChanged.AddListener(changeStatus);

        }
        private void OnDestroy()
        {
            if (slider != null)
                slider.onValueChanged.RemoveAllListeners();
        }
    }
}
