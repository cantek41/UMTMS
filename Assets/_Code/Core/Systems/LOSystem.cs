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

    public class LOSystem : BaseSystem
    {
        private static LOSystem instance;

        private LOSystem()
        {
            components = new();
        }

        public static BaseSystem getInstance()
        {
            if (instance == null)
            {
                instance = new LOSystem();
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
            var data = new SystemData(0.21f, 40, 1.8f, 320);
            #region Pumps
            var alarms = new List<string>() { "ECUXXM_5121", "ECUXXM_5136", "ECUXXM_5139" };

            var pumpMaster = AddComponent<PumpController>("LOMasterPump", this, data.Clone(), EnumCompanentStatus.ON, alarms);
            alarms = new List<string>() { "ECUXXS_5121", "ECUXXS_5136", "ECUXXS_5139" };
            var pumpSlave = AddComponent<PumpController>("LOSlavePump", this, data.Clone(), EnumCompanentStatus.OFF, alarms);
            AddModul(pumpMaster, pumpSlave);
            #endregion

            #region Cooller
            alarms = new List<string>() {"EICUXXM_0150", "EICUXXM_0151", "EICUXXM_0152" };
            var coolerMaster = AddComponent<CoolerController>("LOMasterCooler",  this, data.Clone(), EnumCompanentStatus.ON, alarms);
            alarms = new List<string>() {"EICUXXS_0150", "EICUXXS_0151", "EICUXXS_0152" };
            
            var coolerSlave = AddComponent<CoolerController>("LOSlaveCooler",  this, data.Clone(), EnumCompanentStatus.OFF, alarms);
            AddModul(coolerMaster, coolerSlave);
            #endregion

            #region Filter
            alarms = new List<string>() { "EICUXXM_0354", "EICUXXM_0353", "EICUXXM_0300" };
            var filterMaster = AddComponent<FilterController>("LOMasterFilter",  this, data.Clone(), EnumCompanentStatus.ON, alarms);
            alarms = new List<string>() { "EICUXXS_0354", "EICUXXS_0353", "EICUXXS_0300" };
            var filterSlave = AddComponent<FilterController>("LOSlaveFilter",  this, data.Clone(), EnumCompanentStatus.OFF, alarms);
            AddModul(filterMaster, filterSlave);
            #endregion

            #region Enginee  
            // var engine = AddComponent<EngineeController>("EngineBlock", this, data.Clone(), EnumCompanentStatus.ON, null);
            // components.Add(engine.data);
            #endregion

            Debug.Log("LO SYSTEM BULIDED");

        }


    }

}
