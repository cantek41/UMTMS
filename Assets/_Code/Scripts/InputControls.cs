using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.Events;
using System;

public class InputControls : MonoBehaviour
{
    #region Singelton

    private static InputControls _instance;
    [HideInInspector]
    public static InputControls Instance { get { return _instance; } private set { } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;


            controls = GetComponent<PlayerInput>().actions;
            currentMap = controls.actionMaps[0];
        }
    }

    #endregion

    InputActionAsset controls;
    InputActionMap currentMap;

    [HideInInspector]
    public UnityEvent PrimaryActionEvent;
    [HideInInspector]
    public UnityEvent SecondaryActionEvent;
    [HideInInspector]
    public UnityEvent LeftMouseClickEvent;
    [HideInInspector]
    public UnityEvent LeftMouseClickCanceledEvent;
    [HideInInspector]
    public UnityEvent RightMouseClickEvent;
    [HideInInspector]
    public UnityEvent RightMouseClickCanceledEvent;

    [HideInInspector]
    public delegate void mouseScrollDelegate(float value);
    [HideInInspector]
    public mouseScrollDelegate MouseScrollEvent;

    [HideInInspector]
    public UnityEvent Esc_ClickEvent;

    [SerializeField]
    InteractionDetector interactionDetector;

    UiManager uiManager;

    void OnEnable()
    {
        controls.Disable();
        SwitchActionMap("Player");
    }
    void OnDisable()
    {
        controls.Disable();
    }
    public void SwitchActionMap(string nameOfMap)
    {
        InputActionMap map = controls.FindActionMap(nameOfMap);

        if (map == null)
            return;

        if (map.enabled)
            return;

        controls.Disable();
        map.Enable();
        currentMap = map;
    }

    // Start is called before the first frame update
    void Start()
    {
        uiManager = UiManager.Instance;
        //interactionDetector = playerData.InteractionDetector;

        InputActionMap playerMap = controls.FindActionMap("Player");
        InputActionMap menuMap = controls.FindActionMap("Menu");
        //InputActionMap inventoryMap = controls.FindActionMap("Inventory");
        //InputActionMap UIMap = controls.FindActionMap("UI");

        //Actions
        playerMap.FindAction("PrimaryInteraction").performed += PrimaryInteraction;
        playerMap.FindAction("SecondaryInteraction").performed += SecondaryInteraction;

        //playerMap.FindAction("Q_Event").performed += Q_Event;
        //playerMap.FindAction("Crouch").performed += Crouch_Event;

        //Esc
        playerMap.FindAction("OpenMenu").performed += Esc_Event;

        //Mouse
        playerMap.FindAction("LeftMouseClick").performed += LeftMouseClick;
        playerMap.FindAction("LeftMouseClick").canceled += LeftMouseClickCanceled;

        playerMap.FindAction("RightMouseClick").performed += RightMouseClick;
        playerMap.FindAction("RightMouseClick").canceled += RightMouseClickCanceled;


        //playerMap.FindAction("MouseScrollY").performed += x => mouseScrollDelegate(x.ReadValue<float>);
        playerMap.FindAction("MouseScrollY").performed += MouseScroll_Event;

        //Key number Press
        //playerMap.FindAction("KeyPress1").performed += KeyPress1;
        //playerMap.FindAction("KeyPress2").performed += KeyPress2;
        //playerMap.FindAction("KeyPress3").performed += KeyPress3;
        //playerMap.FindAction("KeyPress4").performed += KeyPress4;
        //playerMap.FindAction("KeyPress5").performed += KeyPress5;

        // == Menu ==
        menuMap.FindAction("CloseMenu").performed += CloseMenuPanel;
    }

    void PrimaryInteraction(CallbackContext ctx)
    {
        interactionDetector.TryPrimaryAction();

        PrimaryActionEvent?.Invoke();
    }

    void SecondaryInteraction(CallbackContext ctx)
    {
        interactionDetector.TrySecondaryAction();

        SecondaryActionEvent?.Invoke();
    }

    //void Q_Event(CallbackContext ctx)
    //{
    //    Q_ClickEvent?.Invoke();
    //}

    void Esc_Event(CallbackContext ctx)
    {
        if (uiManager.OpenMenu())
        {
            SwitchActionMap("Menu");
        }
    }

    void Crouch_Event(CallbackContext ctx)
    {

    }

    void LeftMouseClick(CallbackContext ctx)
    {
        LeftMouseClickEvent?.Invoke();
    }

    void LeftMouseClickCanceled(CallbackContext ctx)
    {
        LeftMouseClickCanceledEvent?.Invoke();
    }

    void RightMouseClick(CallbackContext ctx)
    {
        RightMouseClickEvent?.Invoke();
    }

    void RightMouseClickCanceled(CallbackContext ctx)
    {
        RightMouseClickCanceledEvent?.Invoke();
    }

    void MouseScroll_Event(CallbackContext ctx)
    {
        //Debug.Log("ss: " + ctx.ReadValue<float>());
        MouseScrollEvent(ctx.ReadValue<float>());
    }

    public void CloseMenuPanel(CallbackContext ctx)
    {
        if (!uiManager.CloseMenu())
        {
            SwitchActionMap("Player");
        }
    }


}
