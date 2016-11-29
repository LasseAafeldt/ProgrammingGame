using UnityEngine;
using System.Collections;

public class CharacterControll : MonoBehaviour {

    public float speed = 10.0f;
    Transform transformBeingCarried;
    GameObject Parent;
    public bool isCarryingItem;
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
        if (ManagerScript.CanMove)
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
				SaveTheBoxes.ActivateAssignment5 ();
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
		if (other.gameObject.CompareTag ("PlaySound")) {
			if(other.gameObject == GameObject.Find("awFredTrigger") &&
				ManagerScript.ConstructionModulesCollected[3] &&
				!AudioHandler.isAwFred){
			GameObject.Find ("DoorAnimationFixerStorage1").GetComponent<DoorAnimation> ().Close ();
			GameObject.Find ("DoorAnimationFixerStorage2").GetComponent<DoorAnimationRevers> ().Close ();

			if (CanvasHandler.Player.GetComponent<AudioSource>().isPlaying)
                {
				    CanvasHandler.Player.GetComponent<AudioSource> ().Stop ();
                }
			    CanvasHandler.Player.GetComponent<AudioSource> ().PlayOneShot (AudioHandler.awFred);
                AudioHandler.isAwFred = !AudioHandler.isAwFred;

            }
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
                Debug.Log("found offices");
                ManagerScript.CanMove = false;
				CanvasHandler.Player.GetComponent<AudioSource> ().PlayOneShot (AudioHandler.hallEdited);
				AudioHandler.isHallEdited = !AudioHandler.isHallEdited;
                contiuneMove(1);
			}
			//Office with book assignment
			if (other.gameObject == GameObject.Find("bookAssignmentTrigger") &&
				!AudioHandler.isBooks) {
				if (CanvasHandler.Player.GetComponent<AudioSource> ().isPlaying) {
					CanvasHandler.Player.GetComponent<AudioSource> ().Stop();
				}
                ManagerScript.CanMove = false;
				CanvasHandler.Player.GetComponent<AudioSource> ().PlayOneShot (AudioHandler.books);
				AudioHandler.isBooks = !AudioHandler.isBooks;
                contiuneMove(0);      
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
			//Office remember thermometer
			if (other.gameObject == GameObject.Find("thermometerTrigger") &&
				!AudioHandler.isDidYouSeeThermometer) {
				if (CanvasHandler.Player.GetComponent<AudioSource> ().isPlaying) {
					CanvasHandler.Player.GetComponent<AudioSource> ().Stop();
				}
				CanvasHandler.Player.GetComponent<AudioSource> ().PlayOneShot (AudioHandler.didYouSeeThermometer);
				AudioHandler.isDidYouSeeThermometer = !AudioHandler.isDidYouSeeThermometer;
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
			if (ManagerScript.ConstructionModulesCollected [1] && //collected the book construction module but not handed it in
				!ManagerScript.ConstructionModulesHandedIn [1] ||
				ManagerScript.ConstructionModulesCollected [2] && //collected the wires construction module but not handed it in
				!ManagerScript.ConstructionModulesHandedIn [2] || 
				ManagerScript.ConstructionModulesCollected [3] && //collected the book construction module but not handed it in
				!ManagerScript.ConstructionModulesHandedIn [3] ||
				ManagerScript.ConstructionModulesCollected [0] && //collected the wires construction module but not handed it in
				!ManagerScript.ConstructionModulesHandedIn [0])
			{
				CanvasHandler.ControlRoomBlocker.SetActive (false);
			}
			//control room trigger - explanation of assignment... something
			if (other.gameObject == GameObject.Find("controlRoomTrigger") &&
				!AudioHandler.isFactoryControlRoom) {
				if (CanvasHandler.Player.GetComponent<AudioSource> ().isPlaying) {
					CanvasHandler.Player.GetComponent<AudioSource> ().Stop();
				}
				CanvasHandler.Player.GetComponent<AudioSource> ().PlayOneShot (AudioHandler.factoryControlRoom);
				AudioHandler.isFactoryControlRoom = !AudioHandler.isFactoryControlRoom;
			}

		}
    }

    void contiuneMove(int i)
    {
        if (i == 0)
        {
            StartCoroutine(WaitForSound(AudioHandler.books));
            //Debug.Log("books");
        }
        if (i == 1)
        {
            StartCoroutine(WaitForSound(AudioHandler.hallEdited));
            //Debug.Log("hallway");
        }

    

    }

    private IEnumerator WaitForHallway()
    {
        yield return new WaitForSeconds(AudioHandler.hallEdited.length);
        ManagerScript.CanMove = true;
    }

    private IEnumerator WaitForSound(AudioClip sound)
    {
        yield return new WaitForSeconds(sound.length);
        ManagerScript.CanMove = true;
    }
}
