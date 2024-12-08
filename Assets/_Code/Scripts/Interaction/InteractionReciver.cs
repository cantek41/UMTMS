using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionReciver : MonoBehaviour, IInteractable
{
    [Header("Ui Display messages")]
    public string PrimaryMessage;
    public string SecondaryMessage;


    //protected AudioManager audioManager;
    protected UiManager uiManager;

    protected bool canInteract;
    public bool CanInteract => canInteract;

    protected bool canExecuteAction;

   //protected PlayerData playerData;

    public virtual void Focus()
    {
        ////if (NeedSpecificItem && playerData.Inventory.CurrentItem.PickUpType != PickUpTypeNeeded)
        ////    UnFocus();



        uiManager.ShowInteractionPanel(PrimaryMessage, SecondaryMessage);
    }

    public abstract void PrimaryUse();

    public virtual void SecondaryUse()
    {
        //if (NeedSpecificItem && playerData.Inventory.CurrentItem.PickUpType != PickUpTypeNeeded)
        //    return;

    }

    public virtual void OnSecondaryUse()
    {

    }

    public virtual void UnFocus()
    {
        uiManager.HideInteractionPanel();
        //UiMangerTest.OnUnFocus();
    }

    // Start is called before the first frame update
    void Start()
    {
        //audioManager = AudioManager.Instance;
        //PlayerManager.Instance.OnPlayerReadyEvent.AddListener(SetPlayerRefrences);
        uiManager = UiManager.Instance;
        ////playerData = PlayerManager.Instance.LocalPlayer;
        canInteract = true;
        canExecuteAction = true;
        DoStart();
    }


    public virtual void SetPlayerRefrences() //All refrences to player / playerdata should be set here
    {
        //playerData = PlayerManager.Instance.LocalPlayer;
    }


    protected virtual void DoStart()
    {

    }


    public void ToggleInteraction(bool status)
    {
        canInteract = status;
    }
}
