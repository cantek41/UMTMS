using UnityEngine;
using Core.Abstract.Enum;
using Core.Concreates.Component.Data;
using Core.Abstract.Data;

namespace Core.Concreates.Component.Controller
{
    public class LocalGaugeController : MonoBehaviour
    {

        public GaugeInitializeData initializeData;
        public float val = 0;
        [SerializeField]
        private SystemData data;
        [SerializeField]
        GameObject currentGauge;
        public EnumUnit unit = EnumUnit.PRESSURE;

        private void Start()
        {

        }


        public void Update()
        {
            // currentGauge.transform.localRotation = Quaternion.Euler(GetRotation(), currentGauge.transform.localEulerAngles.y, currentGauge.transform.localEulerAngles.z);
          //  currentGauge.transform.localEulerAngles = new Vector3(GetRotation(), currentGauge.transform.localEulerAngles.y, currentGauge.transform.localEulerAngles.z);
            if (data != null)
            {
            }
        }


        private float GetRotation()
        {

            return initializeData.minAngle - ((GetVal() / initializeData.maxVal) * initializeData.totalAngle);
        }

        private float GetVal()
        {
            return val;

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
}
