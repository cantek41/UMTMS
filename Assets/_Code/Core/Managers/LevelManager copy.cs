using System.Collections;
using System.Collections.Generic;
using Core.Base;
using UnityEngine;
using UnityEngine.SceneManagement;
using Core.Concreates.Scenario;

namespace Core.Concreates.Managers
{


    /// <summary>
    /// Opeartion Currenc Scene and Scenario and choise level
    /// Scenario equal level
    /// It works all scenes (Menu and Game Scene)
    /// </summary>
    public class _LevelManager : SingletonMonoBehaviour<_LevelManager>
    {
        private ScenarioVM scenarioData;

        [SerializeField]
        private List<TextAsset> AllScenario;

        private static int activeScenarioNumber;

        public void ReloadCurrentScene()
        {
           // SystemManager.Instance.Build();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        public void SetActiveScenarioNumber(int scenario)
        {
            activeScenarioNumber = scenario;
        }

        public ScenarioVM GetScenario()
        {
       //     if (scenarioData == null)
                SetScenario();
            return scenarioData;

        }


        public void SetScenario()
        {
            
            var scenarioText = AllScenario[activeScenarioNumber].text;
            scenarioData = JsonUtility.FromJson<ScenarioVM>(scenarioText);

        }


        /// <summary>
        /// Chiose scenario,level 
        /// <param name="scenerioJson">scenario json asset</param>
        /// </summary>
        public void ChangeScenebyScenario()
        {
            SceneManager.LoadScene(1); // GameScene index = 1
            SetScenario();
        }
    }
}