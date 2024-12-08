using System;
using Core.Concreates.Component.Base;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Concreates.Actuator
{
    public class GeneralThings : InteractableController
    {
        [SerializeField]
        public UnityEvent action;

        public override void Interact(Transform t)
        {
            action.Invoke();
        }
    }
}
