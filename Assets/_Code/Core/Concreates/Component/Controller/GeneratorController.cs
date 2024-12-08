using Core.Concreates.Component.Base;
using Core.Concreates.Component.Data;
using Core.Concreates.UI;
using UnityEngine;

namespace Core.Concreates.Component.Controller
{
    public class GeneratorController : InteractableController
    {
        public void Awake()
        {
            data = new GeneratorData();
            menuUI = GameObject.FindAnyObjectByType<PumpUI>();
        }

       

        public void IncreaseFrequance()
        {
            data.ElectricData.FREQUENCY++;
            Debug.Log("IncreaseFrequance");
        }

        public void DecreaseFrequance()
        {
            data.ElectricData.FREQUENCY--;
            Debug.Log("DecreaseFrequance");

        }

         public void activateCurrent()
        {
            data.ElectricData.CURRENT = 5;
        }
    }
}
