using System;
namespace Core.Abstract.AlarmSystem
{
    public class AlarmHistory
    {
        private Alarm alarm { get; set; }
        private DateTime setTime { get; set; }

        public AlarmHistory(Alarm _alarm)
        {
            alarm = _alarm;
            setTime = DateTime.Now;
        }
       
    }
}

