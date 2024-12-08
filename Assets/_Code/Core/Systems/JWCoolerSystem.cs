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

    public class JWCoolerSystem : BaseSystem

    {
        private static JWCoolerSystem instance;

        private JWCoolerSystem()
        {
            components = new();
            Build();
        }

        public static BaseSystem getInstance()
        {
            if (instance == null)
            {
                instance = new JWCoolerSystem();
            }
            return instance;
        }
        public override void Build()
        {

            /// Flow velocity : 3 m/s
            #region pump
            /// jacket water out
            /// pressure max 0.3 Mpa
            /// temp  range max 100 default 80
            var data = new SystemData(0.25f, 80, 3f, 320); //out
            var alarms = new List<string>() { "JWXX_001", "JWXX_002" };
            var pumpMaster = AddComponent<PumpController>("JWMasterPump", this, data, EnumCompanentStatus.ON, alarms);
           // var pumpSlave = AddComponent<PumpController>("JWSlavePump", this, data, EnumCompanentStatus.OFF, alarms);
            components.Add(pumpMaster.data);
            #endregion


            #region JWCooler
            /// jacket water out
            /// pressure max 0.3 Mpa
            /// temp  range max 100 default 80
            // data = new ComponentData(0.25f, 80, 3f, 320); //out
            // var masterCooler = CreateComponent<CoolerController>("JWMasterCooler", "JW Master Cooler", this, data,EnumCompanentStatus.ON, new List<string>() {"COWXX_001", "COWXX_003" });
            // var slaveCooler = CreateComponent<CoolerController>("JWSlaveCooler", "JW Slave Cooler", this, data,EnumCompanentStatus.STANDBY, new List<string>() { "COWXX_001","COWXX_003" });
            // AddModul(masterCooler, slaveCooler);

            data = new SystemData(0.25f, 80, 3f, 320); //out
            alarms = new List<string>() { "JWXX_003", "JWXX_004" };
            var masterCooler = AddComponent<CoolerController>("JWMasterCooler", this, data, EnumCompanentStatus.ON, alarms);
            var slaveCooler = AddComponent<CoolerController>("JWSlaveCooler", this, data, EnumCompanentStatus.OFF, alarms);
            AddModul(masterCooler, slaveCooler);
            #endregion

            #region Filter

            /// jacket water in
            /// pressure max 0.2 Mpa
            /// temp  range max 45 default 32ß

            data = new SystemData(0.18f, 80, 3f, 320); //out
            alarms = new List<string>() { "JWXX_005" };
            var JWMasterFilter = AddComponent<FilterController>("JWMasterFilter", this, data.Clone(), EnumCompanentStatus.ON, alarms);
            var JWSlaveFilter = AddComponent<FilterController>("JWSlaveFilter", this, data.Clone(), EnumCompanentStatus.OFF, alarms);
            AddModul(JWMasterFilter, JWSlaveFilter);
            #endregion

            alarms = new List<string>() { "JWWME_001" };
            var cylinder = AddComponent<EngineeController>("CYLINDER5", this, data.Clone(), EnumCompanentStatus.ON, alarms);
            components.Add(cylinder.data);




            #region  AirDriyer
            data = new SystemData(8, 100, 3f, 320); //out
            alarms = new List<string>() { "JWWME_002" };
            var cylinder4 = AddComponent<GeneralController>("CYLINDER4", this, data.Clone(), EnumCompanentStatus.OFF, alarms);
            components.Add(cylinder4.data);
            #endregion

            Debug.Log("JW Cooler SYSTEM BULIDED");

        }


    }

}
