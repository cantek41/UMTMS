using Core.Abstract.AlarmSystem;
using Core.Abstract.Enum;
using Core.Concreates.Systems;
using UnityEngine;

namespace Core.Concreates.Component.Data
{
    public class GeneralData : IComponent
    {
        public override void Invoke(object _system)
        {
            CheckAlarm(_system);           
        }
    }
}