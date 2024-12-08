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

    public class CentralCoolerSystem : BaseSystem
    {
        private static CentralCoolerSystem instance;
        private CentralCoolerSystem()
        {
            components = new();
            Build();
        }

        public static BaseSystem getInstance()
        {
            if (instance == null)
            {
                instance = new CentralCoolerSystem();
            }
            return instance;
        }

        public override void Build()
        {

            /// Flow velocity : 3 m/s



            #region Pumps
            /// input - pump - locooler/jacketwater -- tank 
            /// pump data max 0.2bar 
            /// 36 temp  range 32-45C
            /// ComponentData(float Pressure, float Temperature, float FlowVelocity,float FlowRate)

            var data = new SystemData(0.19f, 36, 3f, 320);
            var alarms = new List<string>() { "COWXX_001" };
            var pumpMaster = AddComponent<PumpController>("CCMasterPump", this, data.Clone(), EnumCompanentStatus.ON, alarms);
            var pumpSlave = AddComponent<PumpController>("CCSlavePump", this, data.Clone(), EnumCompanentStatus.OFF, alarms);
            AddModul(pumpMaster, pumpSlave);
            #endregion




            #region LOCooller
            /// LO cooller output  36 temp  range 32-45C
            /// pressure max 0.2 Mpa
            /// ComponentData(float Pressure, float Temperature, float FlowVelocity,float FlowRate)

            // data = new ComponentData(0.19f, 36, 3f, 320);
            // alarms = new List<string>() { "COWXX_002" };
            // var coolerMaster = AddComponent<CoolerController>("LOMasterCooler", this, data.Clone(), EnumCompanentStatus.ON, alarms);
            // var coolerSlave = AddComponent<CoolerController>("LOSlaveCooler", this, data.Clone(), EnumCompanentStatus.OFF, alarms);
            // AddModul(coolerMaster, coolerSlave);
            #endregion

            #region JWCooler

            /// jacket water in
            /// pressure max 0.2 Mpa
            /// temp  range max 45 default 32ß

            // data = new SystemData(0.18f, 32, 3f, 320); //out
            // alarms = new List<string>() { "COWXX_003" };
            // var JWCoolerMaster = AddComponent<CoolerController>("CCMasterCooler", this, data.Clone(), EnumCompanentStatus.ON, alarms);
            // var JWCoolerSlave = AddComponent<CoolerController>("CCSlaveCooler", this, data.Clone(), EnumCompanentStatus.OFF, alarms);
            // AddModul(JWCoolerMaster, JWCoolerSlave);
            #endregion

            #region Filter

            /// jacket water in
            /// pressure max 0.2 Mpa
            /// temp  range max 45 default 32ß

            data = new SystemData(0.18f, 32, 3f, 320); //out
            alarms = new List<string>() { "COWXX_004" };
            var CCFilterMaster = AddComponent<FilterController>("CCMasterFilter", this, data.Clone(), EnumCompanentStatus.ON, alarms);
            var CCFilterSlave = AddComponent<FilterController>("CCSlaveFilter", this, data.Clone(), EnumCompanentStatus.OFF, alarms);
            AddModul(CCFilterMaster, CCFilterSlave);
            #endregion
            Debug.Log("Central Cooler SYSTEM BULIDED");

        }




    }

}
