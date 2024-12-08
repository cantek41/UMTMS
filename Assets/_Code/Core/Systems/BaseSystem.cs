using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Abstract.Enum;
using Core.Component;
using Core.Component.Data.Stream;
using Core.Concreates.Component.Base;
using Core.Concreates.Component.Controller;
using Core.Concreates.Component.Data;
using UnityEngine;

namespace Core.Concreates.Systems
{
    public abstract class BaseSystem
    {
        public List<IComponent> components;

        public abstract void Build();

        public void Execute()
        {
            foreach (var c in components)
            {
                c.Invoke(this);
            }
        }

        protected void AddModul(InteractableController master, InteractableController slave)
        {
            AutomaticSwitch pumpSwitch = new AutomaticSwitch();
            master.data.status = EnumCompanentStatus.ON;
            slave.data.status = EnumCompanentStatus.OFF;
            pumpSwitch.SetMasterSlave(master, slave);
            components.Add(pumpSwitch);
        }

        protected InteractableController CreateComponent<T>(
            string tag,
            string label,
            object system,
            SystemData data,
            EnumCompanentStatus status,
            List<string> alarmList
        )
            where T : InteractableController
        {
            GameObject component = GameObject.FindGameObjectWithTag(tag);
            if (component == null)
            {
                Debug.LogError("Not Found " + tag);
                return null;
            }
            if (!component.TryGetComponent(out T _controller))
                component.AddComponent<T>();
            if (!component.TryGetComponent(out BoxCollider _collider))
                component.AddComponent<BoxCollider>();

            var controller = component.GetComponent<T>();
            foreach (var alarm in alarmList)
            {
                controller.data.AddAlarm(alarm);
            }
            controller.componentName ??= label;
            //controller.menuUI ??= GameObject.FindObjectOfType<CompanentUI>();
            controller.data.status = status;
            setDataBySystem(controller.data, system, data);
            return controller;
        }

        protected InteractableController AddComponent<T>(
            string name,
            object system,
            SystemData data,
            EnumCompanentStatus status,
            List<string> alarmList
        )
            where T : InteractableController
        {
            Debug.Log(name);
            GameObject component = GameObject.Find(name);
            var controller = component.GetComponent<T>();
            if (alarmList != null)
                foreach (var alarm in alarmList)
                {
                    controller.data.AddAlarm(alarm);
                }
            controller.data.status = status;
            setDataBySystem(controller.data, system, data);
            return controller;
        }

        private void setDataBySystem(IComponent component, object system, SystemData data)
        {
            switch (system)
            {
                case LOSystem:
                    component.LOdata = data;
                    break;
                case FOSystem:
                    component.FOdata = data;
                    break;
                case JWCoolerSystem:
                    component.JWdata = data;
                    break;
                case CentralCoolerSystem:
                    component.CCoolerData = data;
                    break;
                case AirSystem:
                    component.AirData = data;
                    break;
                case BoilerSystem:
                    component.BData = data;
                    break;
                case ElectricSystem:
                    component.ElectricData = data;
                    break;
                 case SteeringSystem:
                    component.SData = data;
                    break;
            }
        }
    }
}
