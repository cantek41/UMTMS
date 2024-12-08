using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Concreates.Managers
{

    public class CameraManager : MonoBehaviour
    {
        Animator cameraAnimator;
        int cameraindex = 0;
        // Start is called before the first frame update
        void Start()
        {
            cameraAnimator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                cameraChange();
                
            }

        }
        void cameraChange()
        {
            cameraindex++;
            if (cameraindex == 4)
                cameraindex = 0;

            switch (cameraindex)
            {
                case 0:
                    cameraAnimator.Play("followCam");
                    break;
                case 1:
                    cameraAnimator.Play("stateCam");
                    break;
                case 2:
                    cameraAnimator.Play("third");
                    break;
            }



        }
    }

}

