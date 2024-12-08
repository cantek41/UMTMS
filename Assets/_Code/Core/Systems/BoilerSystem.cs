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

    public class BoilerSystem : BaseSystem
    {
        private static BoilerSystem instance;

        private BoilerSystem()
        {
            components = new();
        }

        public static BaseSystem getInstance()
        {
            if (instance == null)
            {
                instance = new BoilerSystem();
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
            var data = new SystemData(7f, 50, 1.8f, 320,210);
            #region Pumps
            var alarms = new List<string>() { "BLPXX_001", "BLPXX_003" };

            var pumpMaster = AddComponent<PumpController>("boilerMasterPump1", this, data.Clone(), EnumCompanentStatus.ON, alarms);
            var pumpSlave = AddComponent<PumpController>("boilerMasterPump2", this, data.Clone(), EnumCompanentStatus.OFF, null);
            AddModul(pumpMaster, pumpSlave);

            
            #endregion

            

            #region Filter
            alarms = new List<string>() { "BLCXX_002"};
            var boilerMaster = AddComponent<GeneralController>("BoilerMaster",  this, data.Clone(), EnumCompanentStatus.ON, alarms);
         //   var boilerSlave = AddComponent<GeneralController>("BoilerSlave",  this, data.Clone(), EnumCompanentStatus.OFF, null);
            components.Add(boilerMaster.data);
            //AddModul(boilerMaster, boilerSlave);
            #endregion

            #region Enginee  
            // var engine = AddComponent<EngineeController>("EngineBlock", this, data.Clone(), EnumCompanentStatus.ON, null);
            // components.Add(engine.data);
            #endregion

            Debug.Log("Boiler SYSTEM BULIDED");

        }


    }

}
