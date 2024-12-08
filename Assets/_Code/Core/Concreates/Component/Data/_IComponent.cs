using System;
using System.Collections;
using System.Collections.Generic;
using Core.Abstract.AlarmSystem;
using Core.Abstract.Enum;
using Core.Concreates.Managers;
using Core.Concreates.Systems;
using UnityEngine;

namespace Core.Concreates.Component.Data
{
    public abstract class IComponent
    {
        public EnumCompanentStatus status = EnumCompanentStatus.OFF;
        public EnumCompanentActionStatus actionStatus = EnumCompanentActionStatus.INSTALL;

        public OnOffData inletValve = new();
        public OnOffData outletValve = new();
        public OnOffData inletCOOLValve = new();
        public OnOffData outletCOOLValve = new();
        protected List<string> companentAlarmList = new();

        public SystemData LOdata;
        public SystemData FOdata;
        public SystemData JWdata;
        public SystemData CCoolerData;
        public SystemData AirData;
        public SystemData BData;
        public SystemData ElectricData;
        public SystemData SData;

        public void AddAlarm(string alarmCode)
        {
            if (companentAlarmList.IndexOf(alarmCode) == -1)
                companentAlarmList.Add(alarmCode);
        }

        public abstract void Invoke(object _system);

        protected void CheckAlarm(object _system)
        {
            AlarmManager alarmManager = AlarmManager.Instance();
            foreach (var _alarm in companentAlarmList)
            {
                var alarm = alarmManager.GetAlarmWithCode(_alarm);

                if (alarm == null)
                {
                    Debug.LogError(_alarm + "is not found in Alarms");
                }
                else
                {
                    SetRefValue(_system, alarm);
                    alarm.checkAlarmStatus();
                    SetAlarmStatus(alarmManager,alarm);
                }
            }
        }

        private void SetAlarmStatus(AlarmManager alarmManager,Alarm alarm)
        {
            switch (alarm.Status)
            {
                case EnumAlarmStatus.ACTIVE:
                    if (!alarm.IsAlarmActive)
                    {
                        alarm.Status = EnumAlarmStatus.PASSIVE;
                        alarmManager.ChangeAlarmStatus(alarm);
                    }
                    break;
                case EnumAlarmStatus.PASSIVE:
                    if (alarm.IsAlarmActive)
                    {
                        alarm.Status = EnumAlarmStatus.ACTIVE;
                        alarmManager.ChangeAlarmStatus(alarm);
                    }
                    break;
                case EnumAlarmStatus.ACKNOWLEDGE:
                    if (!alarm.IsAlarmActive)
                    {
                        alarm.Status = EnumAlarmStatus.DELETE;
                        alarmManager.ChangeAlarmStatus(alarm);
                    }
                    break;
                case EnumAlarmStatus.DELETE:
                    alarm.Status = EnumAlarmStatus.PASSIVE;
                    break;
            }
        }

        private void SetRefValue(object _system, Alarm alarm)
        {
            var _data = SetWhichSystem(_system);
            try
            {
                switch (alarm.conditionValueType)
                {
                    case "PRESSURE":
                        alarm.refVal = _data.Pressure;
                        break;
                    case "TEMPERATURE":
                        alarm.refVal = _data.Temperature;
                        break;
                    case "FLOWRATE":
                        alarm.refVal = _data.FlowRate;
                        break;
                    case "VELOCITY":
                        alarm.refVal = _data.FlowVelocity;
                        break;
                    case "CURRENT":
                        alarm.refVal = _data.CURRENT;
                        break;
                    case "FREQUENCY":
                        alarm.refVal = _data.FREQUENCY;
                        break;
                    case "VOLTAGE":
                        alarm.refVal = _data.VOLTAGE;
                        break;
                    case "RESISTANCE":
                        alarm.refVal = _data.RESISTANCE;
                        break;
                    case "STATUS":
                        alarm.refVal = (float)status;
                        break;
                    case "LEVEL":
                        alarm.refVal = _data.LEVEL;
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }
        }

        private SystemData SetWhichSystem(object _system)
        {
            SystemData _data = null;
            switch (_system)
            {
                case LOSystem:
                    _data = LOdata;
                    break;
                case FOSystem:
                    _data = FOdata;
                    break;
                case JWCoolerSystem:
                    _data = JWdata;
                    break;
                case CentralCoolerSystem:
                    _data = CCoolerData;
                    break;
                case AirSystem:
                    _data = AirData;
                    break;
                case BoilerSystem:
                    _data = BData;
                    break;
                case ElectricSystem:
                    _data = ElectricData;
                    break;
                case SteeringSystem:
                    _data = SData;
                    break;
            }
            return _data;
        }
    }
}
