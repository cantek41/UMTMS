using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using Core.Abstract.Enum;
using Core.Concreates.Component.Base;
using Core.Concreates.Component.Controller;
using Core.Concreates.Component.Data;
using UnityEngine;

namespace Core.Concreates.Systems
{

    public class ElectricSystem : BaseSystem
    {
        private static ElectricSystem instance;

        private ElectricSystem()
        {
            components = new();
        }

        public static BaseSystem getInstance()
        {
            if (instance == null)
            {
                instance = new ElectricSystem();
            }
            return instance;
        }

        public override void Build()
        {
            /// No.1 (No.2) Main Air Reservoir – 4.5 m3
            // No.1 (No.2) Main Air Compressor – 160 m3/h x 30 bar, 440 V, Amin-Amax 0-100 A, Power 30 kW, Fuse – 120 A
            // Emergency Air Compressor – 25 m3/h x 30 bar
            // Aux Air Reservoir – 300 L
            // 2 x Reduction station – 30 bar to 7 bar
            var data = new SystemData(300,90,55);
            data.Pressure = 5;
            #region Generator
            var alarms = new List<string>() { "ELCXXM_0001"};
            var comporessorMain = AddComponent<GeneratorController>("ELCMasterGenerator", this, data.Clone(), EnumCompanentStatus.ON, alarms);
            var comporessorSlave = AddComponent<GeneratorController>("ELCSlaveGenerator", this, data.Clone(), EnumCompanentStatus.OFF, alarms);
            components.Add(comporessorMain.data);
            components.Add(comporessorSlave.data);
            #endregion

            alarms = new List<string>() { "ELCXXM_0002"};
            var emergencyGenerator = AddComponent<GeneratorController>("EmergencyGenerator", this, data.Clone(), EnumCompanentStatus.ON, alarms);
            components.Add(emergencyGenerator.data);
           


            #region smoke density
            alarms = new List<string>() { "ELCSMK_0001"};
            var smokeDencity = AddComponent<SmokeController>("ELCSmoke", this, data.Clone(), EnumCompanentStatus.ON, alarms);
            components.Add(smokeDencity.data);
            #endregion
           
            Debug.Log("ElectricSystem SYSTEM BULIDED");

        }


    }

}
