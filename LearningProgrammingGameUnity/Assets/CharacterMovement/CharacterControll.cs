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
	void FixedUpdate () {
		//Debug.Log ("assignment ID: " + ManagerScript.ActiveID);
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
            if (other.gameObject.transform.GetChild(0).CompareTag("GasTank"))
            {
                ManagerScript.ConstructionModulesCollected[0] = true;
            }
            if (other.gameObject.transform.GetChild(0).CompareTag("Manual"))
            {
                ManagerScript.ConstructionModulesCollected[1] = true;
            }
            if (other.gameObject.transform.GetChild(0).CompareTag("Wire"))
            {
                ManagerScript.ConstructionModulesCollected[2] = true;
            }
            if (other.gameObject.transform.GetChild(0).CompareTag("MetalPlates"))
            {
                //Debug.Log("metal plates picked up");
                ManagerScript.ConstructionModulesCollected[3] = true;
            }
            if (other.gameObject.transform.GetChild(0).CompareTag("Computer"))
            {
                ManagerScript.ConstructionModulesCollected[4] = true;
            }
            Destroy(other.gameObject);
            PressEToInteract.currentCount++;
            PressEToInteract.constructionCounterTooltip = "Construction modules: " + PressEToInteract.currentCount + "/5";
			AudioHandler.playSoundMissingLast ();
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
            room3AccessPanelAssignement.bookCount++;
            PressEToInteract.bookCounterTooltip = "Books collected: " + room3AccessPanelAssignement.bookCount;
        }
        if (other.gameObject.CompareTag("bookArea"))
        {
            room3AccessPanelAssignement.isInsideArea = true;
        }
        if (other.gameObject.CompareTag("Conveyor"))
        {

        }
		if (other.gameObject.CompareTag ("awFredTrigger")) {
			GameObject.Find ("DoorAnimationFixerStorage1").GetComponent<DoorAnimation> ().Close ();
			GameObject.Find ("DoorAnimationFixerStorage2").GetComponent<DoorAnimationRevers> ().Close ();

			if (CanvasHandler.Player.GetComponent<AudioSource> ().isPlaying)
				CanvasHandler.Player.GetComponent<AudioSource> ().Stop ();

			CanvasHandler.Player.GetComponent<AudioSource> ().PlayOneShot (AudioHandler.awFred);
		}
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("bookArea"))
        {
            //Debug.Log("i set bool to true");
            room3AccessPanelAssignement.isInsideArea = false;
        }
		//Solved the first assignment and enters the main room
		if (other.gameObject.CompareTag ("PlaySound")) {
			if (other.gameObject == GameObject.Find ("leaveStartRoomTrigger") &&
			    !AudioHandler.isLookamodule1Editet) {
				if (CanvasHandler.Player.GetComponent<AudioSource> ().isPlaying) {
					CanvasHandler.Player.GetComponent<AudioSource> ().Stop();
				}
				CanvasHandler.Player.GetComponent<AudioSource> ().PlayOneShot (AudioHandler.lookamodule1Editet);
				AudioHandler.isLookamodule1Editet = !AudioHandler.isLookamodule1Editet;
			}
			//Enters the office hallway
			if (other.gameObject == GameObject.Find("hallwayTrigger") &&
				!AudioHandler.isHallEdited) {
				if (CanvasHandler.Player.GetComponent<AudioSource> ().isPlaying) {
					CanvasHandler.Player.GetComponent<AudioSource> ().Stop();
				}
				CanvasHandler.Player.GetComponent<AudioSource> ().PlayOneShot (AudioHandler.hallEdited);
				AudioHandler.isHallEdited = !AudioHandler.isHallEdited;
			}
			//Office with book assignment
			if (other.gameObject == GameObject.Find("bookAssignmentTrigger") &&
				!AudioHandler.isBooks) {
				if (CanvasHandler.Player.GetComponent<AudioSource> ().isPlaying) {
					CanvasHandler.Player.GetComponent<AudioSource> ().Stop();
				}
				CanvasHandler.Player.GetComponent<AudioSource> ().PlayOneShot (AudioHandler.books);
				AudioHandler.isBooks = !AudioHandler.isBooks;
			}
			//Office thermometer assignment
			if (other.gameObject == GameObject.Find("thermometerColdTrigger") &&
				!AudioHandler.isItIsCold) {
				if (CanvasHandler.Player.GetComponent<AudioSource> ().isPlaying) {
					CanvasHandler.Player.GetComponent<AudioSource> ().Stop();
				}
				CanvasHandler.Player.GetComponent<AudioSource> ().PlayOneShot (AudioHandler.itIsCold);
				AudioHandler.isItIsCold = !AudioHandler.isItIsCold;
			}
			//Office story trigger
			if (other.gameObject == GameObject.Find("officeStoryTrigger") &&
				!AudioHandler.isOfficeFourStory) {
				if (CanvasHandler.Player.GetComponent<AudioSource> ().isPlaying) {
					CanvasHandler.Player.GetComponent<AudioSource> ().Stop();
				}
				CanvasHandler.Player.GetComponent<AudioSource> ().PlayOneShot (AudioHandler.officeFourStory);
				AudioHandler.isOfficeFourStory = !AudioHandler.isOfficeFourStory;
			}
			//Office big red button trigger
			if (other.gameObject == GameObject.Find("bigRedButtonTrigger") &&
				!AudioHandler.isBigRedButton) {
				if (CanvasHandler.Player.GetComponent<AudioSource> ().isPlaying) {
					CanvasHandler.Player.GetComponent<AudioSource> ().Stop();
				}
				CanvasHandler.Player.GetComponent<AudioSource> ().PlayOneShot (AudioHandler.bigRedButton);
				AudioHandler.isBigRedButton = !AudioHandler.isBigRedButton;
			}
			//Play sound when collected one or the two construction modules in the offices
			if (other.gameObject == GameObject.Find("rememberModuleConveyrTrigger") &&
				!AudioHandler.isRememberModule) {
				if (ManagerScript.ConstructionModulesCollected [1] && //collected the book construction module but not handed it in
				   !ManagerScript.ConstructionModulesHandedIn [1] ||
				   ManagerScript.ConstructionModulesCollected [2] && //collected the wires construction module but not handed it in
				   !ManagerScript.ConstructionModulesHandedIn [2]) {
					if (CanvasHandler.Player.GetComponent<AudioSource> ().isPlaying) {
						CanvasHandler.Player.GetComponent<AudioSource> ().Stop ();
					}
					CanvasHandler.Player.GetComponent<AudioSource> ().PlayOneShot (AudioHandler.rememberModule);
					AudioHandler.isRememberModule = !AudioHandler.isRememberModule;
				}
			}
			//play sound after office - "Check out storage room" IF player has not collected the module in the storage room.
			if (!ManagerScript.ConstructionModulesCollected [3] && //if the metal plates construction module is not collected
				ManagerScript.ConstructionModulesHandedIn [1] && //if the book construction module is handed in
				ManagerScript.ConstructionModulesHandedIn [2] && //if the wires construction module is handed in
				!AudioHandler.isGoToStorage) {
				if (CanvasHandler.Player.GetComponent<AudioSource> ().isPlaying) {
					CanvasHandler.Player.GetComponent<AudioSource> ().Stop();
				}
				CanvasHandler.Player.GetComponent<AudioSource> ().PlayOneShot (AudioHandler.goToStorage);
				AudioHandler.isGoToStorage = !AudioHandler.isGoToStorage;
			}

		}
    }
}
