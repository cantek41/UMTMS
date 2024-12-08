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

    public class AirSystem : BaseSystem
    {
        private static AirSystem instance;

        private AirSystem()
        {
            components = new();
        }

        public static BaseSystem getInstance()
        {
            if (instance == null)
            {
                instance = new AirSystem();
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
            var data = new SystemData(23, 40, 1.8f, 320);
            
            #region Comporessor
            var alarms = new List<string>() { "ALR_CA_001", "ALR_CA_002"};
            var comporessorMain = AddComponent<GeneralController>("AirMasterComporessor", this, data.Clone(), EnumCompanentStatus.ON, alarms);
            var comporessorSlave = AddComponent<GeneralController>("AirSlaveComporessor", this, data.Clone(), EnumCompanentStatus.OFF, null);
            AddModul(comporessorMain, comporessorSlave);
            #endregion

            #region AirSlaveRecevior
            alarms = new List<string>() { "ALR_CA_003"};
            var recerviorMain = AddComponent<GeneralController>("AirMasterRecevior", this, data.Clone(), EnumCompanentStatus.ON, alarms);
            var recerviorSlave = AddComponent<GeneralController>("AirSlaveRecevior", this, data.Clone(), EnumCompanentStatus.OFF, null);
            AddModul(recerviorMain, recerviorSlave);
            #endregion

            #region  AirDriyer
            alarms = new List<string>() { "ALR_CA_007"};
            var airDriyer = AddComponent<GeneralController>("AirDriyer", this, data.Clone(), EnumCompanentStatus.OFF, alarms);
            components.Add(airDriyer.data);
            #endregion
           
            Debug.Log("AIR SYSTEM BULIDED");

        }


    }

}
