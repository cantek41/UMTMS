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
    public static class LevelManager
    {
        private static List<TextAsset> AllScenario;
        private static int activeScenarioNumber=0;
        public static void ReadAllScenario()
        {
            AllScenario = new();
            for (int i = 1; i <= 21; i++)
            {
                try
                {
                    AllScenario.Add(Resources.Load<TextAsset>($"Scenarios/Scenario{i}"));
                }
                catch
                {

                }
            }
        }
        public static void ReloadCurrentScene()
        {
            // SystemManager.Instance.Build();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public static void SetActiveScenarioNumber(int scenario)
        {
            activeScenarioNumber = scenario;
        }
        public static int GetScenarioNumber()
        {
            return activeScenarioNumber+1;
        }

        public static ScenarioVM GetScenario(int index)
        {
            var scenarioText = AllScenario[index].text;
            return JsonUtility.FromJson<ScenarioVM>(scenarioText);

        }

        public static ScenarioVM GetScenario()
        {
            var scenarioText = AllScenario[activeScenarioNumber].text;
            return JsonUtility.FromJson<ScenarioVM>(scenarioText);

        }
    }
}