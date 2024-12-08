using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UiManager : MonoBehaviour
{
    #region Singleton
    private static UiManager _instance;

    [HideInInspector]
    public static UiManager Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    private void OnDestroy()
    {
        if (this == _instance) { _instance = null; }
    }

    #endregion

    [Header("Interaction")]
    [SerializeField]
    TextMeshProUGUI primaryText;

    [SerializeField]
    TextMeshProUGUI secondaryText;

    [SerializeField]
    GameObject interactionPanel;


    [Header("Menu")]
    [SerializeField]
    GameObject menuPanel;

    int mouseCount;

    // Start is called before the first frame update
    void Start()
    {
        mouseCount = 0;
    }

    public void ShowInteractionPanel(string primaryMessage, string secondaryMessage, bool useEKey = true, bool useRKey = true)
    {
        if (useEKey)
        {
            primaryText.text = "E - " + primaryMessage;
        }
        else
        {
            primaryText.text = primaryMessage;
        }

        if (secondaryMessage != "")
        {
            if (useRKey)
            {
                secondaryText.text = "R - " + secondaryMessage;
            }
            else
            {
                secondaryText.text = secondaryMessage;
            }
            secondaryText.gameObject.SetActive(true);
        }
        else
        {
            secondaryText.text = "";
            secondaryText.gameObject.SetActive(false);
        }
        
        interactionPanel.SetActive(true); 
    }

    public void HideInteractionPanel()
    {
        interactionPanel.SetActive(false);
    }
    public bool OpenMenu()
    {
        menuPanel.SetActive(true);
        mouseCount += 1;

        CheckMouse();
        return menuPanel.activeInHierarchy;
    }

    public bool CloseMenu()
    {
        menuPanel.SetActive(false);
        mouseCount -= 1;

        CheckMouse();
        return menuPanel.activeInHierarchy;
    }

    public void CheckMouse()
    {
        if (mouseCount < 0)
            mouseCount = 0;

        if (mouseCount > 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
