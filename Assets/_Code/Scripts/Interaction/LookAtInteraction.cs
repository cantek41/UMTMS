using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtInteraction : InteractionReciver
{
    [SerializeField]
    GameObject cam;

    bool isZoomedIn;

    PlayerData playerData;
    protected override void DoStart()
    {
        base.DoStart();
        playerData = PlayerData.Instance;
    }

    public override void PrimaryUse()
    {
        if (isZoomedIn)
        {
            isZoomedIn = false;
            cam.SetActive(false);
            playerData.ToggleMovement(true, true);
        }
        else
        {
            isZoomedIn = true;
            cam.SetActive(true);
            playerData.ToggleMovement(false, false);
        }
    }
}
