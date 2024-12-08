using System.Collections;
using System.Collections.Generic;
using Core.Base;
using Core.Concreates.Systems;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Concreates.Managers
{
    public class SystemManager : MonoBehaviour// SingletonMonoBehaviour<SystemManager>
    {

        private List<BaseSystem> AllSystem;
        public bool loadIsComplated;


        public void Start()
        {
            Debug.Log("System manager start");
            AllSystem = new();
            AllSystem.Add(LOSystem.getInstance());
            AllSystem.Add(CentralCoolerSystem.getInstance());
            AllSystem.Add(JWCoolerSystem.getInstance());
            AllSystem.Add(FOSystem.getInstance());
            AllSystem.Add(AirSystem.getInstance());
            AllSystem.Add(BoilerSystem.getInstance());
            AllSystem.Add(ElectricSystem.getInstance());
            AllSystem.Add(SteeringSystem.getInstance());
            Build();
        }

        public void Build()
        {
            Debug.Log("System manager Build");
            foreach (var item in AllSystem)
            {
                item.Build();
            }
        }

        public void Update()
        {
            Debug.Log("System manager update");
            foreach (var item in AllSystem)
            {
                item.Execute();
            }
        }

    }

}



