﻿using UnityEngine;
using System.Collections;

public class CharacterControll : MonoBehaviour {

    public float speed = 10.0f;
    public static bool canMove = true;
    Transform transformBeingCarried;
    GameObject Parent;
    bool isCarryingItem;
    Vector2 mouseLook;
    Vector2 smoothV;


    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        isCarryingItem = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (canMove)
        {
            float translation = Input.GetAxis("Vertical") * speed;
            float straffe = Input.GetAxis("Horizontal") * speed;
            translation *= Time.deltaTime;
            straffe *= Time.deltaTime;
            transform.Translate(straffe, 0, translation);
        }
        if (isCarryingItem)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                transformBeingCarried.SetParent(Parent.transform.parent.transform.parent);
                Parent.transform.localRotation = Quaternion.identity;
                transformBeingCarried.GetComponent<Rigidbody>().isKinematic = false;
                isCarryingItem = false;
                transformBeingCarried.localScale = new Vector3(1, 1, 1);
            }
            //Debug.Log("pressed mouse");
            //Debug.Log(transformBeingCarried);
            Parent.transform.localRotation = Quaternion.AngleAxis(-CameraMousePan.mouseLook.y, Vector3.right);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("other.parent = " + other.transform.parent);
        //Debug.Log("other = " + other.gameObject);
        if (other.gameObject.CompareTag("ConstructionModule"))
        {
            if (other.gameObject.transform.GetChild(0).CompareTag("MetalPlates"))
            {
                //Debug.Log("metal plates picked up");
                GameObject.Find("DoorAnimationFixerStorage1").GetComponent<DoorAnimation>().ChangeState();
                GameObject.Find("DoorAnimationFixerStorage2").GetComponent<DoorAnimationRevers>().ChangeState();
            }
            Destroy(other.gameObject);
            PressEToInteract.currentCount++;
            PressEToInteract.constructionCounterTooltip = "Construction modules: " + PressEToInteract.currentCount + "/5";
        }
        if (other.transform.parent.gameObject.CompareTag("room5") && !isCarryingItem)
        {
            isCarryingItem = true;
            Parent = GameObject.Find("ItemBeingCarriedParent");
            transformBeingCarried = other.transform.parent;
            transformBeingCarried.GetComponent<Rigidbody>().isKinematic = true;
            transformBeingCarried.SetParent(GameObject.Find("ItemBeingCarriedParent").transform);
            transformBeingCarried.transform.localPosition = new Vector3(0,0, 2f);
            transformBeingCarried.localRotation = Quaternion.identity;
            transformBeingCarried.localScale = new Vector3(1, 0.5f, 1);
        }
        if (other.transform.parent.gameObject.CompareTag("book"))
        {
            Destroy(other.transform.parent.gameObject);
            PressEToInteract.bookCount++;
        }
    }
}
