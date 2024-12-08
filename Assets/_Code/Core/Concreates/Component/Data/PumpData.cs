using Core.Abstract.AlarmSystem;
using Core.Abstract.Enum;
using Core.Concreates.Systems;
using UnityEngine;

namespace Core.Concreates.Component.Data
{
    public class PumpData : IComponent
    {


        //public override IStreamFeed Invoke(IStreamFeed _fluid)
        //{
        //    alarmStatus = PressureOut < WorkingRangeOutput[0] || PressureOut > WorkingRangeOutput[1];
        //    checkAlarm(alarmStatus);
        //    return _fluid;
        //}     
        public override void Invoke(object _system)
        {
            CheckAlarm(_system);
            // pressure[0] +=1;
            if (status == EnumCompanentStatus.ON)
            {
                
            }
        }
    }
}