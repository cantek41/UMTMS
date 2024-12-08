using Core.Concreates.Systems;

namespace Core.Concreates.Component.Data
{
    public class GeneratorData : IComponent
    {
       
        public override void Invoke(object _system)
        {
             CheckAlarm(_system);
        }
    }
}