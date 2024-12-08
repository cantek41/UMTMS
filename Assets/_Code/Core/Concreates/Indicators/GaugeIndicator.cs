using Core.Abstract.Enum;
using Core.Concreates.Component.Base;
using Core.Concreates.Component.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Concreates.Indicators
{
    public class GaugeIndicator : MonoBehaviour
    {
        [SerializeField]
        public BaseController _controller;
        public EnumUnit unit = EnumUnit.PRESSURE;
        public EnumSystemData systemData;
        private SystemData data;

        public float val;
        public float minAngle = -90;
        public float diff = 90;

        public float minVal = 0;
        public float diffVal = 6;

        public EnumXYX rota = EnumXYX.Y;

        private float previouseVal;

        void Start() { }

        void Update()
        {
            if (data == null)
                SetData();
            if (_controller.data.status == EnumCompanentStatus.OFF)
                val = minVal;
            else
                val = GetVal();
            if (val != previouseVal)
                UpdateGauge();
        }

        public void UpdateGauge()
        {
            switch (rota)
            {
                case EnumXYX.X:
                    transform.localEulerAngles = new Vector3(
                        transform.localEulerAngles.x,
                        transform.localEulerAngles.y,
                        GetRotation()
                    );
                    break;
                case EnumXYX.Y:
                    transform.localEulerAngles = new Vector3(
                        transform.localEulerAngles.x,
                        GetRotation(),
                        transform.localEulerAngles.z
                    );
                    break;
                case EnumXYX.Z:
                    transform.localEulerAngles = new Vector3(
                        transform.localEulerAngles.x,
                        transform.localEulerAngles.y,
                        GetRotation()
                    );
                    break;
            }
            previouseVal = val;
        }

        private float GetRotation()
        {
            return minAngle + (((val - minVal) / diffVal) * diff);
        }

        void SetData()
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
                case EnumSystemData.ElectricData:
                    data = _controller.data.ElectricData;
                    break;
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
                    case EnumUnit.FREQUENCY:
                        val = data.FREQUENCY;
                        break;
                    case EnumUnit.CURRENT:
                        val = data.CURRENT;
                        break;
                    case EnumUnit.VOLTAGE:
                        val = data.VOLTAGE;
                        break;
                }
            return val;
        }
    }
}
