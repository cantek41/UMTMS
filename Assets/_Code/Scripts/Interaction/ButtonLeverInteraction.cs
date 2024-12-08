using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonLeverInteraction : InteractionReciver
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    bool isAToggle;

    [SerializeField]
    float waitTime;

    [SerializeField]
    UnityEvent OnUseEvent;

    [SerializeField]
    UnityEvent OnToggleFirstEvent;

    [SerializeField]
    UnityEvent OnToggleSecondEvent;

    int toggleState;

    protected override void DoStart()
    {
        base.DoStart();
        toggleState = 0;
    }

    public override void PrimaryUse()
    {
        if (!canExecuteAction)
            return;

        canExecuteAction = false;
        if (isAToggle)
        {
            animator.SetTrigger("Toggle");

            if(toggleState == 0)
            {
                OnToggleFirstEvent?.Invoke();
                StartCoroutine(WaitTime(1));
                toggleState = 1;
            }
            else
            {
                OnToggleSecondEvent?.Invoke();
                StartCoroutine(WaitTime(1));
                toggleState = 0;
            }
        }
        else
        {
            OnUseEvent?.Invoke();
            animator.SetTrigger("Use");
            StartCoroutine(WaitTime(waitTime));
        }
    }

    IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
        canExecuteAction = true;
    }
}
