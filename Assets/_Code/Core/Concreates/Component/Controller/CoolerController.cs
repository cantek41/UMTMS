using Core.Component.Data;
using Core.Concreates.Component.Base;
using Core.Concreates.Component.Data;
using Core.Concreates.UI;
using UnityEngine;

namespace Core.Concreates.Component.Controller
{
    public class CoolerController : InteractableController
    {
        public void Awake()
        {
            data = new CoolerData();
            menuUI = GameObject.FindAnyObjectByType<CoolerUI>();

            SetAnimator(ref data.inletValve, "valves/HOT/inlet/valveHandle");
            SetAnimator(ref data.outletValve, "valves/HOT/outlet/valveHandle");
            SetAnimator(ref data.inletCOOLValve, "valves/COOL/inlet/valveHandle");
            SetAnimator(ref data.outletCOOLValve, "valves/COOL/outlet/valveHandle");

            data.inletValve.SetStatus(true);
            data.outletValve.SetStatus(true);
            data.inletCOOLValve.SetStatus(true);
            data.outletCOOLValve.SetStatus(true);

            transform.TryGetComponent<Animator>(out actionAnimation);
            transform.TryGetComponent<AudioSource>(out runningVoice);
        }

        private void Update()
        {
            if (
                data.inletValve.GetStatus()
                && data.outletValve.GetStatus()
                && data.inletCOOLValve.GetStatus()
                && data.outletCOOLValve.GetStatus()
            )
            {
                data.status = Abstract.Enum.EnumCompanentStatus.ON;
            }
            else
            {
                data.status = Abstract.Enum.EnumCompanentStatus.OFF;
            }
        }

        private void SetAnimator(ref OnOffData valveData, string valveName)
        {
            Animator animator = transform.Find(valveName).GetComponent<Animator>();
            valveData = new OnOffData(animator);
        }
    }
}
