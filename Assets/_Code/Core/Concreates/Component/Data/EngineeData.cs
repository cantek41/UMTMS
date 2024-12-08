using Core.Concreates.Systems;
using UnityEngine;

namespace Core.Concreates.Component.Data
{
    public class EngineeData : IComponent
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

           // CheckAlarm( _system);
            // switch (_system)
            // {
            //     case LOSystem:
            //         masterData = LOdata;
            //         break;
            //     case FOSystem:
            //         masterData = FOdata;
            //         break;
            // }
            // Debug.Log("Pump data Invoke");
            // checkAlarm();
        }
    }
}