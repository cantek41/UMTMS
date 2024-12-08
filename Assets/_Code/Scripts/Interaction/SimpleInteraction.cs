using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleInteraction : InteractionReciver
{
    [SerializeField]
    UnityEvent OnPrimaryEvent;

    [SerializeField]
    UnityEvent OnSecondaryEvent;

    public override void PrimaryUse()
    {
        OnPrimaryEvent?.Invoke();
    }

    public override void OnSecondaryUse()
    {
        //base.OnSecondaryUse();
        OnSecondaryEvent?.Invoke();
    }
}
