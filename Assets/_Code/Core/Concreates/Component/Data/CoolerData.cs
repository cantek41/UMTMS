using Core.Abstract.Enum;
using Core.Concreates.Systems;

namespace Core.Concreates.Component.Data
{
    public class CoolerData : IComponent
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
        //    //fluid = _fluid;
        //    //alarmStatus = TemperatureOut > WorkingRangeOutput[1];
        //    //checkAlarm(alarmStatus);
        //    //setValue();
        //    return _fluid;
        //}

    }
}