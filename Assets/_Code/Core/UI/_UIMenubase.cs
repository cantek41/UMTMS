using System.Numerics;
using Core.Concreates.Component.Base;
using Core.Concreates.Component.Data;
using StarterAssets;
using TMPro;
using UnityEngine;

namespace Core.Concreates.UI
{
    public class _UIMenubase : MonoBehaviour
    {
        protected FirstPersonController player;

        private void Start()
        {
            player = GameObject.FindAnyObjectByType<FirstPersonController>();
        }

        protected void ShowCanvas()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            player.LockCameraPosition = true;
        }

        protected void HideCanvas()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            player.LockCameraPosition = false;
        }
    }
}
