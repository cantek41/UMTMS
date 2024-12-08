using System.Collections;
using System.Collections.Generic;
using Core.Abstract;
using Core.Concreates.Component.Data;
using UnityEngine;

namespace Core.Concreates.Component.Base
{
    public abstract class BaseController : MonoBehaviour, IEntity
    {
        public string componentName;
        public IComponent data;
        

        public void OFF()
        {
            data.status = Abstract.Enum.EnumCompanentStatus.OFF;
        }

        public void ON()
        {
            data.status = Abstract.Enum.EnumCompanentStatus.ON;
        }

        public void noting() { }
    }
}
