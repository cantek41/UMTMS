using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotatingVectorType
{
    X,
    Y,
    Z
}

public class RotationInteraction : InteractionReciver
{
    [SerializeField]
    RotatingVectorType RotatingVectorType;

    [SerializeField]
    int rotationAmount = 90;

    [SerializeField]
    bool canRotateBothWays;

    int currentSide;

    bool isRotating;

    public override void PrimaryUse()
    {
        if (canExecuteAction)
        {
            currentSide++;
            if (currentSide > 4)
            {
                currentSide = 1;
            }
            Rotating(false);
            //StartCoroutine(ExecuteAction(true));
        }
    }

    public override void SecondaryUse()
    {
        if (!canExecuteAction)
            return;

        if (canRotateBothWays)
        {
            currentSide--;
            if (currentSide < 0)
            {
                currentSide = 0;
            }
            Rotating(true);
            //StartCoroutine(ExecuteAction(false));
        }
    }

    //private void Update()
    //{
    //    if (isRotating)
    //    {

    //    }
    //}

    //protected IEnumerator ExecuteAction(bool rotateRight)
    //{
    //    canExecuteAction = false;

    //    if (rotateRight)
    //    {
    //        currentSide++;
    //        if (currentSide > 4)
    //        {
    //            currentSide = 1;
    //        }
    //        Rotating(true);
    //    }
    //    else
    //    {
    //        currentSide--;
    //        if (currentSide < 0)
    //        {
    //            currentSide = 0;
    //        }
    //        Rotating(false);
    //    }

    //    yield return new WaitForSeconds(1f);
    //    canExecuteAction = true;
    //}

    void Rotating(bool isRight)
    {
        canExecuteAction = false;
        int a = 0;
        if(isRight)
        {
            a = rotationAmount;
        }
        else
        {
            a -= rotationAmount;
        }

        switch (RotatingVectorType)
        {
            case  RotatingVectorType.X:
                //this.gameObject.transform.Rotate(new Vector3(a, 0, 0), Space.Self);
                StartCoroutine(RotateMe(Vector3.right, a,  0.8f));
                break;
            case RotatingVectorType.Y:
                StartCoroutine(RotateMe(Vector3.up, a, 0.8f));
                //this.gameObject.transform.Rotate(new Vector3(0, a, 0), Space.Self);
                break;
            case RotatingVectorType.Z:
                StartCoroutine(RotateMe(Vector3.forward, a, 0.8f));
                //this.gameObject.transform.Rotate(new Vector3(0, 0, a), Space.Self);
                break;
        }
    }

    //IEnumerator RotateMe(Vector3 byAngles, float inTime)
    IEnumerator RotateMe(Vector3 axis, float angle, float duration = 1.0f)
    {
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation;
        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;
        while(elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = to;

        //var fromAngle = transform.rotation;
        //Debug.Log("From " + fromAngle.ToString());
        //var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        //Debug.Log("To " +  toAngle.ToString());
        //for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        //{
        //    transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
        //    yield return null;
        //}

        //transform.rotation = toAngle;
        canExecuteAction = true;

    }
}
