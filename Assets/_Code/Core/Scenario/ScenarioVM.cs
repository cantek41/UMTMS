using System.Collections.Generic;

namespace Core.Concreates.Scenario
{
    [System.Serializable]

    public class ScenarioVM
    {
        public string title;
        public float time;
        public string description;
        public string DocLink;
        public List<ScenarioComponentVM> components;
    }
}