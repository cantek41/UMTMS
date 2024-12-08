using System.Collections;
using Core.Abstract;
using Core.Abstract.Enum;
using Core.Component.Data;
using Core.Concreates.Component.Data;
using Core.Concreates.UI;
using UnityEngine;

namespace Core.Concreates.Component.Base
{
    public class InteractableController : BaseController, IInteractable
    {
        protected ComponentUI menuUI;
        protected AudioSource runningVoice;
        protected Animator actionAnimation;
        private string lastPosition;

        public void Awake()
        {
            transform.TryGetComponent<AudioSource>(out runningVoice);
            var gObject = transform.Find("inletValve/valveHandle");
            if (gObject != null)
            {
                if (gObject.TryGetComponent<Animator>(out Animator animator))
                    data.inletValve = new OnOffData(animator);
                data.inletValve.SetStatus(true);
            }
            gObject = transform.Find("outletValve/valveHandle");
            if (gObject != null)
            {
                if (gObject.TryGetComponent<Animator>(out Animator animator))
                    data.outletValve = new OnOffData(animator);
                data.outletValve.SetStatus(true);
            }

            transform.TryGetComponent<Animator>(out actionAnimation);
        }

        protected void VoiceControl()
        {
            if (runningVoice != null)
            {
                switch (data.status)
                {
                    case EnumCompanentStatus.ON:
                        if (!runningVoice.isPlaying)
                            runningVoice.Play();
                        break;
                    case EnumCompanentStatus.OFF:
                        runningVoice.Stop();
                        break;
                }
            }
        }

        public virtual void Interact(Transform t)
        {
            menuUI.Show(this);
        }

        public IEnumerator SetDefault()
        {
            yield return new WaitForSeconds(3);

            if (data.LOdata != null)
                data.LOdata.SetDefault();
            if (data.FOdata != null)
                data.FOdata.SetDefault();
            if (data.JWdata != null)
                data.JWdata.SetDefault();
            if (data.CCoolerData != null)
                data.CCoolerData.SetDefault();
            if (data.AirData != null)
                data.AirData.SetDefault();
            if (data.BData != null)
                data.BData.SetDefault();
        }

        public virtual void Repair()
        {
            if (actionAnimation != null)
                actionAnimation.SetTrigger("repair");
        }

        public virtual void Remove()
        {
            if (actionAnimation != null)
                actionAnimation.SetTrigger("remove");
        }

        public virtual void ReInstall()
        {
            if (actionAnimation != null)
                actionAnimation.SetTrigger("reinstall");
             StartCoroutine(SetDefault());
            
        }

       
        public string ComponentName()
        {
            return componentName;
        }
    }
}
