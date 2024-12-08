using System;
using Core.Concreates.Component.Base;
using Core.Concreates.Systems;

namespace Core.Concreates.Component.Data
{
    public class AutomaticSwitch : IComponent
    {
        private InteractableController master;
        private InteractableController slave;


        public bool IsMaster { get; set; }

        public void SetMasterSlave(InteractableController _master, InteractableController _slave)
        {
            master = _master;
            slave = _slave;
            IsMaster = true;
        }
        public override void Invoke(object _system)
        {
            if (IsMaster)
                master.data.Invoke(_system);
            else
                slave.data.Invoke(_system);
        }
    }
}