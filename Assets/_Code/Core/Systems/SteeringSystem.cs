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

    public class SteeringSystem : BaseSystem
    {
        private static SteeringSystem instance;

        private SteeringSystem()
        {
            components = new();
        }

        public static BaseSystem getInstance()
        {
            if (instance == null)
            {
                instance = new SteeringSystem();
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
            var data = new SystemData(0.21f, 40, 1.8f, 320);
            data.CURRENT = 10;
            
            #region Generator
            var alarms = new List<string>() { "ALR_SG_001", "ALR_SG_002"};
            var steering = AddComponent<SteeringController>("steeringgearunit1", this, data.Clone(), EnumCompanentStatus.ON, alarms);
            components.Add(steering.data);
            #endregion

           
            Debug.Log("ElectricSystem SYSTEM BULIDED");

        }


    }

}
