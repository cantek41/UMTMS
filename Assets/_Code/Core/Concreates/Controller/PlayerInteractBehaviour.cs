using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Core.Base;
using Core.Abstract;

namespace Core.Concreates.Component.Base
{
    public class PlayerInteractBehaviour : MonoBehaviour
    {
        public float interactRange = 1f;
        private List<IInteractable> interactables;

        private PlayerMenuUI playerMenuUI;

        public Transform InteractSource;
        public float radius;

        public void Start()
        {
            playerMenuUI = GameObject.Find("PlayerMenuUI").GetComponent<PlayerMenuUI>();
        }

        // Update is called once per frame
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                IInteractable interactable = GetInteractableObjectWithCam();
                if (interactable != null)
                {
                    interactable.Interact(transform);
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (playerMenuUI != null)
                {
                    playerMenuUI.Show();
                }
            }

        }

         public IInteractable GetInteractableObjectWithCam()
        {
            RaycastHit hit;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            IInteractable closest = null;

            if (Physics.Raycast(ray, out hit, interactRange))
            {

                if (hit.collider.TryGetComponent(out IInteractable interactable))
                {
                    closest = interactable;
                }

            }
            return closest;

        }

        public IInteractable GetInteractableObject()
        {
            interactables = new List<IInteractable>();
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out IInteractable interactable))
                {
                    interactables.Add(interactable);
                }

            }
            IInteractable closest = null;
            foreach (var interactable in interactables)
            {
                if (closest == null)
                {
                    closest = interactable;
                }
                else
                {
                    if (Vector3.Distance(transform.position, interactable.transform.position)
                        < Vector3.Distance(transform.position, closest.transform.position))
                        closest = interactable;
                }
            }
            return closest;

        }

    }
}
