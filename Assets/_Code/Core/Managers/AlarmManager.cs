using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Core.Abstract.AlarmSystem;
using Core.Base;
using TMPro;
using UnityEngine;

namespace Core.Concreates.Managers
{
    public class AlarmManager : MonoBehaviour //SingletonMonoBehaviour<AlarmManager>
    {
        bool PressACKNOWLEDGEButton = false;

        bool isLoad = false;

        public static AlarmManager Instance()
        {
            return FindFirstObjectByType<AlarmManager>();
        }

        void Awake()
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("AlarmManager");
            checkedMore();
            PressACKNOWLEDGEButton = false;
            isLoad = false;
            ReadAllAlarm();
        }

        static void checkedMore()
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("AlarmManager");
            while (objs.Length > 1)
            {
                Destroy(objs[0]);
            }
        }

        private AlarmLight alarmLight;
        private AlarmLight warningLight;
        private AlarmVoice alarmVoice;
        private AlarmScreen MessageScreen;
        private AlarmModel alarmList;
        private Alarm _alarm_;

        public TextAsset alarmJson;

        public void Start()
        {
            isLoad = false;
            Debug.Log("Alarm Manager Start");
            warningLight = new AlarmLight(GameObject.FindGameObjectsWithTag("warningLight"));
            alarmLight = new AlarmLight(GameObject.FindGameObjectsWithTag("alarmLight"));
            alarmVoice = AlarmVoice.CreateInstance(GameObject.FindGameObjectsWithTag("horn"));
            MessageScreen = AlarmScreen.CreateInstance(
                GameObject.FindGameObjectWithTag("MOPAScreenText").GetComponent<TextMeshProUGUI>()
            );
        }

        public void ReadAllAlarm()
        {
            alarmList = new();
            checkEmptyAlarm = false;
            load("Alarms/LOAlarmPump");
            load("Alarms/LOAlarmCooler");
            load("Alarms/LOAlarmFilter");
            load("Alarms/CCAlarm");
            load("Alarms/FOAlarm");
            load("Alarms/JWAlarm");
            load("Alarms/JWAlarmEngine");
            load("Alarms/AirAlarm");
            load("Alarms/BoilerAlarm");
            load("Alarms/ELCAlarm");
            load("Alarms/SteeringAlarm");

            void load(string resourceName)
            {
                var alarmJsonText = Resources.Load<TextAsset>(resourceName).text;
                var a = JsonUtility.FromJson<AlarmModel>(alarmJsonText);
                alarmList.Alarms.AddRange(a.Alarms);
            }
            setAlarmsSetting();
            isLoad = true;
        }

        void OnDestroy()
        {
            Kill();
        }

        public void Kill()
        {
            alarmVoice.Kill();
            MessageScreen.Kill();
        }

        public void setAlarmsSetting()
        {
            foreach (var alarm in alarmList.Alarms)
            {
                alarm.Status = EnumAlarmStatus.PASSIVE;
            }
        }

        public Alarm GetAlarmWithCode(string code)
        {
            if (alarmList == null)
                if (alarmList == null)
                    return null;
            return alarmList.Alarms.Find(x => x.Code == code);
        }

        public void Update()
        {
            CheckAlarm();
            isLoad = true;
        }

        public void ChangeAlarmStatus(Alarm alarm)
        {
            var _alarm = alarmList.Alarms.Find(x => x.Code == alarm.Code);
            _alarm.Status = alarm.Status;
        }

        bool checkEmptyAlarm = false;
        bool checkAllControl = false;

        public void CheckAlarm()
        {
            checkAllControl = false;
            message = string.Empty;
            if (alarmList == null)
                return;
            foreach (var item in alarmList.Alarms)
            {
                if (
                    item.Status == EnumAlarmStatus.ACTIVE
                    || item.Status == EnumAlarmStatus.ACKNOWLEDGE
                )
                {
                    checkAllControl = true;
                    show(item);
                }
            }
            checkEmptyAlarm = checkAllControl;
            if (PressACKNOWLEDGEButton && !checkAllControl)
                Debug.Log("PRESS");

            if (!checkEmptyAlarm)
            {
                alarmLight.Stop();
                warningLight.Stop();
                alarmVoice.Stop();
                MessageScreen.setColor(Color.green);
            }
        }

        public bool getAlarmStatus(){
            return checkEmptyAlarm || alarmLight.getStatus() || warningLight.getStatus();
        }
        public bool getAlarmLoadStatus(){
            return isLoad;
        }

        string message = string.Empty;

        public void show(Alarm alarm)
        {
            if (alarm.Status == EnumAlarmStatus.ACTIVE && !PressACKNOWLEDGEButton)
            {
                alarmLight.Start();
                warningLight.Stop();
                alarmVoice.Start();
                MessageScreen.setColor(Color.red);
            }
            else
            {
                alarmLight.Stop();
                warningLight.Start();
                alarmVoice.Stop();
                MessageScreen.setColor(Color.yellow);
            }

            message = String.Concat(message, "\n", alarm.Code, "-", alarm.MOPMessage);
            MessageScreen.print(message);
        }

        public void PressACKNOWLEDGE()
        {
            PressACKNOWLEDGEButton = true;
            alarmVoice.Stop();
            alarmLight.Stop();
            warningLight.Stop();
            MessageScreen.setColor(Color.yellow);
            foreach (var item in alarmList.Alarms)
            {
                if (item.Status == EnumAlarmStatus.ACTIVE)
                {
                    item.Status = EnumAlarmStatus.ACKNOWLEDGE;
                    warningLight.Start();
                    ChangeAlarmStatus(item);
                }
            }
        }
    }
}
