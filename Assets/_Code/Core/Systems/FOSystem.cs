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

    public class FOSystem : BaseSystem
    {
        private static FOSystem instance;
        private FOSystem()
        {
            components = new();
            Build();
        }

        public static BaseSystem getInstance()
        {
            if (instance == null)
            {
                instance = new FOSystem();
            }
            return instance;
        }

        public override void Build()
        {
            /// Flow Rate : 320nm3/h
            /// Flow velocity : 1.8 m/s
            /// pumps pressure work range 0.19-0.25 Mpa, default 0.21
            /// pumps tempreture work range 35-55 C, default 40
            /// pumps pressure work range 0.19-0.25 Mpa, default 0.21
            /// pumps tempreture work range 35-55 C, default 40
            var data = new SystemData(0.5f, 100, 1.8f, 320);
            #region Pumps
            var alarm = new List<string>() { "FOWXX_002" };

            var pumpMaster = AddComponent<PumpController>("FOMasterPump", this, data.Clone(), EnumCompanentStatus.ON, alarm);
            var pumpSlave = AddComponent<PumpController>("FOSlavePump", this, data.Clone(), EnumCompanentStatus.OFF, alarm);
            AddModul(pumpMaster, pumpSlave);
            #endregion

            #region Autofilter
            alarm = new List<string>() { "FOWXX_001" };

            var autoFilet = AddComponent<FilterController>("FOAutoFilter", this, data.Clone(), EnumCompanentStatus.ON, alarm);
            components.Add(autoFilet.data);
            #endregion

            #region heater
            alarm = new List<string>() { "FOWXX_004" };
            var heater = AddComponent<HeaterController>("FOHeater", this, data.Clone(), EnumCompanentStatus.ON, alarm);
            components.Add(heater.data);
            #endregion

            #region Filter
            alarm = new List<string>() { "FOWXX_003" };
            var filterMaster = AddComponent<FilterController>("FOMasterFilter", this, data.Clone(), EnumCompanentStatus.ON, alarm);
            var filterSlave = AddComponent<FilterController>("FOSlaveFilter", this, data.Clone(), EnumCompanentStatus.OFF, alarm);
            AddModul(filterMaster, filterSlave);
            #endregion

            #region Enginee  
            // var engine = CreateComponent<EngineeController>("Enginee", "Enginee", this, data.Clone(),EnumCompanentStatus.ON, new List<string>() { "EICUXX_0354","EICUXX_0353","EICUXX_0300" });
            // components.Add(engine.data);  
            #endregion

            Debug.Log("FO SYSTEM BULIDED");

        }


    }

}
