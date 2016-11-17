using UnityEngine;
using System.Collections;

public class DoorAnimation : MonoBehaviour {

    public float doorOpenAngle = 90.0f;
    public float doorCloseAngle = 0.0f;
    public float doorAnimSpeed = 2.0f;
    private Quaternion doorOpen = Quaternion.identity;
    private Quaternion doorClose = Quaternion.identity;
    public bool isOpen = false; //false is close, true is open
    private bool doorChangingState = false; //for Coroutine, when start only one
    void Start()
    {
        if (this.gameObject.CompareTag("OpenDoor"))
            isOpen = true;
        else
            isOpen = false; //door is open
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
        while (Quaternion.Angle(transform.localRotation, dest) > 4.0f)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, dest, Time.deltaTime * doorAnimSpeed);
            yield return null;
        }
        doorChangingState = false;
        yield return null;
    }

    public void ChangeState()
    {
        //Debug.Log(this.gameObject + " changing state ");
        //Debug.Log(this.gameObject + " " + doorChangingState);
        //Debug.Log(this.gameObject + " " + doorStatus);
        if (!doorChangingState)
        {
            if (isOpen)
            { //close door
                StartCoroutine(this.moveDoor(doorClose));
                this.isOpen = !this.isOpen;
            }
            else
            { //open door
                StartCoroutine(this.moveDoor(doorOpen));
                this.isOpen = !this.isOpen;
            }
        }
    }

    public void Close()
    {
        //Debug.Log(this.gameObject + " changing state ");
        //Debug.Log(this.gameObject + " " + doorChangingState);
        //Debug.Log(this.gameObject + " " + doorStatus);
        if (!doorChangingState)
        {
            if (isOpen)
            { //close door
                StartCoroutine(this.moveDoor(doorClose));
                this.isOpen = true;
            }
        }
    }
}
