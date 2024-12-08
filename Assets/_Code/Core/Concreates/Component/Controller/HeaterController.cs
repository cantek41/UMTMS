using Core.Component.Data;
using Core.Concreates.Component.Data;
using Core.Concreates.Component.Base;
using UnityEngine;
using Core.Concreates.UI;

namespace Core.Concreates.Component.Controller
{

    public class HeaterController : InteractableController
    {


        public void Awake()
        {
            data = new CoolerData();
            menuUI = GameObject.FindAnyObjectByType<CoolerUI>();

            // SetAnimator(ref data.inletValve, "valves/HOT/inlet/valveHandle");
            // SetAnimator(ref data.outletValve, "valves/HOT/outlet/valveHandle");

            transform.TryGetComponent<Animator>(out actionAnimation);
            transform.TryGetComponent<AudioSource>(out runningVoice);

        }

        private void SetAnimator(ref OnOffData valveData, string valveName)
        {
            Animator animator = transform.Find(valveName).GetComponent<Animator>();
            valveData = new OnOffData(animator);
        }

       

    }
}