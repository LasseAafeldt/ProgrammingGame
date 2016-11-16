using UnityEngine;
using System.Collections;

public class DoorAnimation : MonoBehaviour {

    public float doorOpenAngle = 90.0f;
    public float doorCloseAngle = 0.0f;
    public float doorAnimSpeed = 2.0f;
    private Quaternion doorOpen = Quaternion.identity;
    private Quaternion doorClose = Quaternion.identity;
    public bool doorStatus = false; //false is close, true is open
    private bool doorChangingState = false; //for Coroutine, when start only one
    void Start()
    {
        doorStatus = false; //door is open, maybe change
                            //Initialization your quaternions
        doorOpen = Quaternion.Euler(0, doorOpenAngle, 0);
        doorClose = Quaternion.Euler(0, doorCloseAngle, 0);
        //Find only one time your player and get him reference
    }
    void Update()
    {

    }
    public IEnumerator moveDoor(Quaternion dest)
    {
        doorChangingState = true;
        //Check if close/open, if angle less 4 degree, or use another value more 0
        while (Quaternion.Angle(transform.localRotation, dest) > 4.0f)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, dest, Time.deltaTime * doorAnimSpeed);
            //UPDATE 1: add yield
            yield return null;
        }
        doorChangingState = false;
        //UPDATE 1: add yield
        yield return null;
    }

    public void ChangeState()
    {
        //If press F key on keyboard
        if (!doorChangingState)
        {
            if (doorStatus)
            { //close door
                StartCoroutine(this.moveDoor(doorClose));
            }
            else
            { //open door
                StartCoroutine(this.moveDoor(doorOpen));
            }
        }
    }
}
