using Core.Abstract;
using Core.Base;
using Core.Concreates.Component.Base;
using Core.Concreates.Managers;
using UnityEngine;

namespace Core.Concreates.Component.Controller
{
    public class AckKnowledgeController : InteractableController
    {
        public void Awake()
        {
            // menuUI = GameObject.FindAnyObjectByType<PanelUI>();
        }

        public override void Interact(Transform t)
        {
            Debug.Log("pressACKNOWLEDGE");
            var alarmManager = FindFirstObjectByType<AlarmManager>();
            alarmManager.PressACKNOWLEDGE();
        }
    }
}
