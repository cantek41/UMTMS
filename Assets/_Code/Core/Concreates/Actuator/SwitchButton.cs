using System;
using Core.Abstract.Enum;
using Core.Concreates.Component.Base;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Concreates.Actuator
{
    public class SwitchButton : InteractableController
    {
        [SerializeField]
        public UnityEvent action;

        public bool val = false;
        public float pointON = -90;
        public float pointOFF = 90;
        Vector3 switchAngles;

        void Start()
        {
            switchAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, pointON);
        }

        public EnumXYX rota = EnumXYX.Y;

        public override void Interact(Transform t)
        {
            action.Invoke();
            val = !val;
            UpdateGauge();
        }

        public void UpdateGauge()
        {
            switch (rota)
            {
                case EnumXYX.X:
                    switchAngles.x = GetRotation();
                    break;
                case EnumXYX.Y:
                    switchAngles.y = GetRotation();

                    break;
                case EnumXYX.Z:
                    switchAngles.z = GetRotation();

                    break;
            }
            transform.eulerAngles = switchAngles;
        }

        private float GetRotation()
        {
            return val ? pointON : pointOFF;
        }
    }
}
