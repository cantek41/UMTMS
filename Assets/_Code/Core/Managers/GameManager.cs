using System;
using System.Collections;
using System.Collections.Generic;
using Core.Base;
using Core.Concreates.Component.Base;
using Core.Concreates.Component.Controller;
using Core.Concreates.Scenario;
using Core.NetWork;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace Core.Concreates.Managers
{
    public class GameManager : MonoBehaviour //SingletonMonoBehaviour<GameManager>
    {
        private TextMeshProUGUI TimerDisplay;
        private TextMeshProUGUI ScenarioNameDisplay;
        public AlarmManager alarmManager;
        public SystemManager systemManager;
        public ScenarioManager scenarioManager;
        GameObject lights;
        private GameResultUI gameResultUI;
        private bool _UIisActive;

        public void Start()
        {
            _UIisActive = false;
            Debug.Log("GameManager Start");
            TimerDisplay = GameObject
                .FindGameObjectWithTag("remineTimeText")
                .GetComponent<TextMeshProUGUI>();
            ScenarioNameDisplay = GameObject
                .FindGameObjectWithTag("ScenarioName")
                .GetComponent<TextMeshProUGUI>();
            scenarioManager.LoadScenario();
            ScenarioNameDisplay.text = scenarioManager.GetScenarioName();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (LevelManager.GetScenarioNumber() == 17)
            {
                GameObject.Find("gasDetection_RH-cable_BROKEN").SetActive(true);
                GameObject.Find("gasDetection_RH-cable").SetActive(false);
            }
            else
            {
                GameObject.Find("gasDetection_RH-cable_BROKEN").SetActive(false);
                GameObject.Find("gasDetection_RH-cable").SetActive(true);
            }

            if (LevelManager.GetScenarioNumber() == 21)
                lights = GameObject.Find("env_light");
            gameResultUI = GameObject.Find("GameResultUI").GetComponent<GameResultUI>();
        }

        public void Update()
        {
            if (alarmManager.getAlarmStatus())
                TimerDisplay.text = scenarioManager.GetRemaingTime();
            if (lights != null)
            {
                if (alarmManager.getAlarmStatus())
                {
                    lights.SetActive(false);
                }
                else
                {
                    lights.SetActive(true);
                }
            }
            FixedUpdate();
        }

        int i = 0;

        private void FixedUpdate()
        {
            if (
                (!alarmManager.getAlarmStatus() || scenarioManager.IsTimeFinished())
                && alarmManager.getAlarmLoadStatus()
                && scenarioManager.checkAllMaster()
                && _UIisActive == false
            )
            {
                i++;
                if (i < 5)
                    return;

                _UIisActive = true;
                var score = ScoreManager
                    .CreateInstance()
                    .CalcScore(scenarioManager.GetRemaingTimeRateTotalTime());
                var star = ScoreManager.CreateInstance().CalcStar();
                Debug.Log("SKORRRR" + score.ToString());
                gameResultUI.Show(score, star);
            }
        }
    }
}
