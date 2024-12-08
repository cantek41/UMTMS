using Core.Abstract.Enum;
using Core.Concreates.Systems;
using UnityEngine;

namespace Core.Concreates.Component.Data
{
    public class FilterData : IComponent
    {
        public override void Invoke(object _system)
        {
                CheckAlarm(_system);

            if (status == EnumCompanentStatus.ON)
            {
            }
        }

        //public override IStreamFeed Invoke(IStreamFeed _fluid)
        //{
        //    alarmStatus = Math.Abs(PressureOut-PressureIn) > 0.4;
        //    checkAlarm(alarmStatus);
        //    return _fluid;
        //}

       

    }
}