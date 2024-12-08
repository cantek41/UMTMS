using System;
using Core.Concreates.Systems;
using UnityEngine;

namespace Core.Concreates.Component.Data
{
    public class OnOffData
    {

        /// <summary>
        /// Last status, true - Open, false -> Close
        /// </summary>
        private bool status = false;
        private Animator animation;

        public OnOffData()
        {
        }
        public OnOffData(Animator _animation)
        {
            animation = _animation;
        }

        public void SetStatus(bool _status)
        {
            status = _status;
            if (animation != null)
                animation.SetTrigger("turn");
        }
        public bool GetStatus()
        {
            return status;
        }
        public float GetStatusFloat()
        {
            return Convert.ToSingle(status);
        }


    }
}