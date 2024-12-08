using UnityEngine;
using System.Collections;
using TMPro;
using Core.Concreates.Component.Base;
using System;
using Core.Concreates.Component.Controller;
using Core.Concreates.Component.Data;
using Core.Abstract.Enum;

namespace Core.Concreates.UI
{
    public class MessageUI : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI text;

        [SerializeField]
        GameObject canvas;

        private ComponentUI componentUI;
        public void ShowWithComponentMessageOnOFF(ComponentUI _componentUI)
        {
            Show("You cannot action to this component, because it is running. If you want to do an action STATUS must be OFF.");
            componentUI = _componentUI;
        }

        public void Show(string val)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            canvas.SetActive(true);
            text.text = val;
            ScoreManager.CreateInstance().Fault(5);
        }

        public void Hide()
        {
            text.text = null;
            canvas.SetActive(false);
            if (componentUI != null)
                componentUI.Close();
        }

    }
}