using UnityEngine;

namespace Core.Abstract
{
    public interface IInteractable:IEntity
    {
        public string ComponentName();
        public void Interact(Transform t);
     
    }
}