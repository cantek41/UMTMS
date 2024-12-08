using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void PrimaryUse();

    void SecondaryUse();

    void Focus();

    void UnFocus();
}
