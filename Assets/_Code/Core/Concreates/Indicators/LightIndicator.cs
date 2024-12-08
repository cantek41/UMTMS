using Core.Abstract.Enum;
using Core.Concreates.Component.Base;
using UnityEngine;

namespace Core.Concreates.Indicators
{
    public class LightIndicator : MonoBehaviour
    {
        public BaseController controller;
        public bool OnOFF=false;
        Light onLight;

        void Start() { 
            onLight = transform.Find("light").gameObject.GetComponent<Light>();
        }

        void Update()
        {            
            onLight.enabled = !(controller.data.status==EnumCompanentStatus.ON ^ OnOFF);
        }
      
    }
}
