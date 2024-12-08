using Core.Abstract;
using Core.Abstract.Enum;
using Core.Component.Data;
using Core.Concreates.Component.Data;
using Core.Concreates.UI;
using UnityEngine;

namespace Core.Concreates.Component.Base
{
    public class MasterSlaveController : BaseController, IInteractable
    {
        protected ComponentUI menuUI;
        protected Animator actionAnimation;
        public InteractableController masterData;
        public InteractableController slaveData;
        public void Awake()
        {
            transform.TryGetComponent<Animator>(out actionAnimation);
        }

        public virtual void Interact(Transform t)
        {
            Debug.Log("dsdsd");
            if (masterData.data.status == EnumCompanentStatus.ON)
            {
                actionAnimation.SetTrigger("slave");
                Debug.Log("slave");
                masterData.data.status = EnumCompanentStatus.OFF;
                slaveData.data.status = EnumCompanentStatus.ON;
            }
            else
            {
                actionAnimation.SetTrigger("master");
                Debug.Log("master");
                masterData.data.status = EnumCompanentStatus.ON;
                slaveData.data.status = EnumCompanentStatus.OFF;
            }
        }

        public string ComponentName()
        {
            return componentName;
        }
    }
}
