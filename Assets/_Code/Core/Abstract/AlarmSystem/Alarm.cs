using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Abstract.AlarmSystem
{
    [Serializable]
    public class AlarmModel
    {
        public List<Alarm> Alarms = new();
    }

    [Serializable]
    public class Alarm
    {
        public string Code;
        public string MOPMessage;
        public string Description;
        public float conditionValue;
        public float  refVal;
        public string conditionValueType;
        public string condition;
        public bool IsAlarmActive;

        public EnumAlarmStatus Status = EnumAlarmStatus.PASSIVE;
        private Dictionary<DateTime, EnumAlarmStatus> alarmHistory = new();


        public void checkAlarmStatus()
        {
            switch (condition)
            {
                case ">":
                    IsAlarmActive = refVal > conditionValue;
                    break;
                case "<":
                    IsAlarmActive = refVal < conditionValue;
                    break;
                case "==":
                    IsAlarmActive = refVal == conditionValue;
                    break;
                case "!=":
                    IsAlarmActive = refVal  != conditionValue;
                    break;
                default:
                    IsAlarmActive = false;
                    break;

            }
           
        }

        public void ChangeStatus(EnumAlarmStatus status)
        {
            Status = status;
            alarmHistory.Add(new DateTime(), status);
        }

        public EnumAlarmStatus getStatus()
        {
            return Status;
        }

        public Dictionary<DateTime, EnumAlarmStatus> getHistory()
        {
            return alarmHistory;
        }

        public string getText()
        {
            return Code;
        }
    }
}
