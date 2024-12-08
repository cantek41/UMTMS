using UnityEngine;
using TMPro;
using Core.Abstract;
using Core.Concreates.Component.Base;

public class PlayerInteractUI : MonoBehaviour
{

    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private PlayerInteractBehaviour playerInteract;

    private TextMeshProUGUI interactTitle;

    private bool IsWorking;

    public void setIsWorking(bool _IsWorking)
    {
        IsWorking = _IsWorking;
    }


    public void Update()
    {
        if (playerInteract == null)
        {
            return;
        }
        var interactable = playerInteract.GetInteractableObjectWithCam();
        if (interactable != null && !IsWorking)
            Show(interactable);
        else
            Hide();
    }
    // Use this for initialization
    void Show(IInteractable interactable)
    {
        IsWorking = false;
        canvas.SetActive(true);
        interactTitle = canvas.transform.Find("InteractTitle").gameObject.GetComponent<TextMeshProUGUI>();
        interactTitle.text = interactable.ComponentName();

    }

    // Update is called once per frame
    public void Hide()
    {
        canvas.SetActive(false);
    }
}
