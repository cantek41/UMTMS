using System;
using System.Collections.Generic;

namespace Core.NetWork.ViewModel.Response
{
    [Serializable]
    public class UserInfoVM
    {
        public int id { get; set; }
        public string title { get; set; }
        public string country { get; set; }
        public string action { get; set; }
        // public List<ScenarioInUserVM> scenarios { get; set; }
        public float avarageScore { get; set; }
    }
}
