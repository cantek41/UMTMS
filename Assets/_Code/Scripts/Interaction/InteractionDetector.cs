using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionDetector : MonoBehaviour
{
    public Camera MainCamera;
    public LayerMask DetectionLayer;
    [SerializeField]
    LayerMask blockingLayer;
    public int RayLenght = 2;
    InteractionReciver currentlyHovered;

    bool setUpDone;

    int layermasks;

    UiManager uiManager;

    GameObject currentlyHoveredGameobject;

    // Start is called before the first frame update
    void Start()
    {
       
        currentlyHovered = null;
       
        setUpDone = true;
        layermasks = LayerMask.GetMask("Interactable", "BlockInteraction");

        uiManager = UiManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (!setUpDone)
            return;

        CheckForInteraction();
    }

    void CheckForInteraction()
    {
      
        Ray ray = MainCamera.ViewportPointToRay(Vector3.one / 2f);
        Debug.DrawRay(ray.origin, ray.direction * 2f, Color.red);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, RayLenght, layermasks))
        {
            if (hit.collider.tag == "InteractionBlocker")
            {
                HideInteractionPanel();
                return;
            }
                
            InteractionReciver hitObject; //= hit.collider.GetComponent<InteractionReciver>();
            hit.collider.TryGetComponent<InteractionReciver>(out hitObject);

            if(hitObject == null)
            {
                if(currentlyHovered != null)
                    currentlyHovered.UnFocus();

                currentlyHovered = null;
            }
            else if (hitObject != null && hitObject != currentlyHovered)
            {
                if (!hitObject.CanInteract)
                    return;

                //Debug.Log("Hit an interactable object");
                //if (hitObject != currentlyHovered)
                    currentlyHovered = hitObject;

                currentlyHovered.Focus();
            }
        }
        else
        {
            HideInteractionPanel();
            //mangerTest.HideInteractionPanel();
            //if (currentlyHovered != null)
            //{
            //    currentlyHovered.UnFocus();
            //}
            //currentlyHovered = null;
        }

        //if(currentlyHovered != null)
        //{
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        currentlyHovered.UnFocus();
        //        currentlyHovered.PrimaryUse();
        //        UpdateFocusInteraction();
        //    }
        //    if (Input.GetKeyDown(KeyCode.R))
        //    {
        //        currentlyHovered.UnFocus();
        //        currentlyHovered.SecondaryUse();
        //        UpdateFocusInteraction();

        //    }
            
        //}
    }

    public void TryPrimaryAction()
    {
        if (currentlyHovered == null)
            return;

        //currentlyHovered.UnFocus();
        currentlyHovered.PrimaryUse();

    }

    public void TrySecondaryAction()
    {
        if (currentlyHovered == null)
            return;
  
        //currentlyHovered.UnFocus();
        currentlyHovered.SecondaryUse();
    }

    void HideInteractionPanel()
    {
        uiManager.HideInteractionPanel();
        if (currentlyHovered != null)
        {
            currentlyHovered.UnFocus();
        }
        currentlyHovered = null;
    }

    public void UpdateFocusInteraction()
    {
        if(currentlyHovered != null)
            currentlyHovered.Focus();
    }
}
