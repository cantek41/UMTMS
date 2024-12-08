using System;
using System.Collections;
using System.Collections.Generic;
using Castle.Components.DictionaryAdapter.Xml;
using Core.Abstract.Enum;
using Core.Base;
using Core.Component.Data;
using Core.Concreates.Component.Base;
using Core.Concreates.Component.Data;
using Core.Concreates.Scenario;
using UnityEngine;

namespace Core.Concreates.Managers
{
    public class ScenarioManager : MonoBehaviour // SingletonMonoBehaviour<ScenarioManager>
    {
        TimeSpan timeSpan;
        private ScenarioVM scenerio;
        float totalScenarioTime;
        float remainScenarioTime;

        /// <summary>
        /// Load Scenario by scenario index
        /// Scenario have to came from manuely
        /// in fact that, it should be create with code
        /// inside this method
        /// </summary>
        public void LoadScenario()
        {
            LevelManager.ReadAllScenario();
            ScoreManager.CreateInstance().SetDefault();
            scenerio = LevelManager.GetScenario();
            GameObject gameobject;
            Debug.Log("LOAD SCENARIO" + scenerio.title);
            totalScenarioTime = scenerio.time;
            remainScenarioTime = scenerio.time;
            foreach (var item in scenerio.components)
            {
                gameobject = GameObject.Find(item.objectNAME);
                SystemData _data = null;
                Debug.Log(item.objectNAME);

                // try
                // {
                switch (item.system)
                {
                    case "LOData":
                        _data = gameobject.GetComponent<BaseController>().data.LOdata;
                        break;
                    case "FOData":
                        _data = gameobject.GetComponent<BaseController>().data.FOdata;
                        break;
                    case "AirData":
                        _data = gameobject.GetComponent<BaseController>().data.AirData;
                        break;
                    case "JWData":
                        _data = gameobject.GetComponent<BaseController>().data.JWdata;
                        break;
                    case "CCoolWaterData":
                        _data = gameobject.GetComponent<BaseController>().data.CCoolerData;
                        break;
                    case "BData":
                        _data = gameobject.GetComponent<BaseController>().data.BData;
                        break;
                    case "ElectricData":
                        _data = gameobject.GetComponent<BaseController>().data.ElectricData;
                        break;
                    case "SData":
                        _data = gameobject.GetComponent<BaseController>().data.SData;
                        break;
                }

                SetValue(gameobject, item, _data);
                // }
                // catch (Exception ex)
                // {
                //     Debug.LogError(ex.Message);
                // }
            }
        }

        private void SetValue(GameObject gameobject, ScenarioComponentVM item, SystemData data)
        {
            switch (item.valueType)
            {
                case "PRESSURE":
                    data.Pressure = item.value;
                    break;
                case "TEMPERATURE":
                    data.Temperature = item.value;
                    break;
                case "FLOWRATE":
                    data.FlowRate = item.value;
                    break;
                case "VELOCITY":
                    data.FlowVelocity = item.value;
                    break;
                case "CURRENT":
                    data.CURRENT = item.value;
                    break;
                case "FREQUENCY":
                    data.FREQUENCY = item.value;
                    break;
                case "VOLTAGE":
                    data.VOLTAGE = item.value;
                    break;
                case "RESISTANCE":
                    data.RESISTANCE = item.value;
                    break;
                case "STATUS":
                    gameobject.GetComponent<BaseController>().data.status = (EnumCompanentStatus)
                        item.value;
                    break;
                case "LEVEL":
                    data.LEVEL = item.value;
                    break;
            }
        }

        /// get remaining time
        public string GetRemaingTime()
        {
            if (scenerio == null)
                return null;
            remainScenarioTime -= Time.deltaTime;
            timeSpan = TimeSpan.FromSeconds(remainScenarioTime);
            return timeSpan.ToString("m':'ss");
        }

        ///Game over due to time
        public bool IsTimeFinished()
        {
            //Debug.Log("remainScenarioTime:"+remainScenarioTime.ToString());
            return remainScenarioTime <= 0;
        }

        public float GetRemaingTimeRateTotalTime()
        {
            if (remainScenarioTime <= 0)
                return 0;
            return remainScenarioTime / totalScenarioTime;
        }

        public string GetScenarioName()
        {
            return scenerio.title;
        }

        List<string> allMaster = new List<string>
        {
            "LOMasterFilter",
            "boilerMasterPump1",
            "AirMasterComporessor",
            "AirMasterRecevior",
            "BoilerMaster",
            "CCMasterPump",
            "CCMasterFilter",
            "ELCMasterGenerator",
            "ELCSmoke",
            "FOMasterPump",
            "FOAutoFilter",
            "FOHeater",
            "FOMasterFilter",
            "JWMasterCooler",
            "JWMasterFilter",
            "CYLINDER5",
            "LOMasterPump",
            "LOMasterCooler",
            "LOMasterFilter",
            "steeringgearunit1",
            "EmergencyGenerator"
        };

        public bool checkAllMaster()
        {
            var result = true;
            foreach (var m in allMaster)
            {
                var gameObject = GameObject.Find(m);
                var d = gameObject.GetComponent<BaseController>().data;
                result &= d.status == EnumCompanentStatus.ON;
            }
            return result;
        }
    }
}
