using System;
using Core.Abstract.Enum;
using Core.Concreates.Component.Base;
using Core.Concreates.Component.Data;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public float val = 0;
    public EnumUnit unit = EnumUnit.PRESSURE;
    public EnumSystemData systemData;
    public string componentName;
    public TextMeshPro text;
    private SystemData data;

    void Start() { 
        SetData();
    }

    public void Update()
    {
        SetData();
        text.text = GetVal().ToString();
    }

    void SetData()
    {
        GameObject component = GameObject.Find(componentName);
        if (component == null)
            return;
        if (component.TryGetComponent(out BaseController _controller))
        {
            switch (systemData)
            {
                case EnumSystemData.LOData:
                    data = _controller.data.LOdata;
                    break;
                case EnumSystemData.FOData:
                    data = _controller.data.FOdata;
                    break;
                case EnumSystemData.AirData:
                    data = _controller.data.AirData;
                    break;
                case EnumSystemData.JWData:
                    data = _controller.data.JWdata;
                    break;
                case EnumSystemData.CCoolWaterData:
                    data = _controller.data.CCoolerData;
                    break;
                case EnumSystemData.BoilerSystem:
                    data = _controller.data.BData;
                    break;
            }
        }
    }

    private float GetVal()
    {
        if (data != null)
            switch (unit)
            {
                case EnumUnit.PRESSURE:
                    val = data.Pressure;
                    break;
                case EnumUnit.TEMPERATURE:
                    val = data.Temperature;
                    break;
                case EnumUnit.FLOWRATE:
                    val = data.FlowRate;
                    break;
                case EnumUnit.VELOCITY:
                    val = data.FlowVelocity;
                    break;
                case EnumUnit.VISCOSITY:
                    val = data.Viscosity();
                    break;
                case EnumUnit.LEVEL:
                    val = data.LEVEL;
                    break;
            }
        return val;
    }
}
