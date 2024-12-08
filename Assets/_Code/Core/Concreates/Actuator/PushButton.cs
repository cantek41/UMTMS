using System;
using Core.Concreates.Component.Base;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Concreates.Actuator
{
    public class PushButton : InteractableController
    {
        [SerializeField]
        public UnityEvent action;

        public override void Interact(Transform t)
        {
            if (action != null)
                action.Invoke();
            Repair();
        }
    }
}
