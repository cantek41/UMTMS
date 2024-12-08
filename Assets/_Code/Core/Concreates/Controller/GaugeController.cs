using Core.Abstract.Enum;
using Core.Concreates.Component.Base;
using Core.Concreates.Component.Data;
using UnityEngine;

public class GaugeController : MonoBehaviour
{
    public float minVal = 0;
    public float maxVal = 0.6f;
    public float minAngle = -128;
    public float totalAngle = -256;
    public float val = 0;
    public EnumUnit unit = EnumUnit.PRESSURE;
    public EnumSystemData systemData;
    public string componentName;
    private SystemData data;

    public void Update()
    {
        SetData();
        if (data != null)
            transform.localEulerAngles = new Vector3(GetRotation(), -90, 0);
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
                    data = _controller.data.CCoolerData;
                    break;
            }
        }
    }

    private float GetRotation()
    {
        return minAngle - ((GetVal() / maxVal) * totalAngle);
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
            }
        return val;
    }
}
