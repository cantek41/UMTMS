using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerData : MonoBehaviour
{
    #region Singelton

    private static PlayerData _instance;
    [HideInInspector]
    public static PlayerData Instance { get { return _instance; } private set { } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    #endregion

    [SerializeField]
    FirstPersonController personController;


    public void ToggleMovement(bool state, bool camState)
    {
        personController.ToggleMovement(state, camState);
    }

}
