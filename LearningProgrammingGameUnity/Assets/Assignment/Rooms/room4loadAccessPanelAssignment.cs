using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class room4loadAccessPanelAssignment : MonoBehaviour {
    protected GameObject obj;
    protected int activeChildCount;
    public static float distanceToObj = 5;
    private static int ID = 4;
    // Use this for initialization
    void Start()
    {
        activeChildCount = 0;
        obj = gameObject;
    }
    void Update()
    {
        distanceToObj = Vector3.Distance(CanvasHandler.Player.transform.position, obj.transform.position);

        //Debug.Log(distanceToObj);
        if (distanceToObj < room1loadAccessPanelAssignment.interactionDistance) {
            if(Input.GetKeyDown("e") && CanvasHandler.DragAndDropCanvas.activeInHierarchy != true)
            {
                PressEToInteract.currentToolTipText = "";
               	ManagerScript.ActiveID = ID;
                CanvasHandler.DragAndDropCanvas.SetActive(true);
                RunQueue.ResetQueue();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                CharacterControll.canMove = false;
                CameraMousePan.canMove = false;
                this.load();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
			Debug.Log ("Active id: " + ManagerScript.ActiveID);
			if (ManagerScript.ActiveID == 4) {
				if (room3AccessPanelAssignement.IsFinalResultTrue ()) {
					//play sound after player solves the assignment and presses Q
					if (CanvasHandler.Player.GetComponent<AudioSource> ().isPlaying) {
						CanvasHandler.Player.GetComponent<AudioSource> ().Stop ();
					}
					CanvasHandler.Player.GetComponent<AudioSource> ().PlayOneShot (AudioHandler.wellDoneInOffice);
					AudioHandler.isWellDoneInOffice = !AudioHandler.isWellDoneInOffice;
				}
			}
            //ManagerScript.ResetID();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            CanvasHandler.DragAndDropCanvas.SetActive(false);
            CharacterControll.canMove = true;
            CameraMousePan.canMove = true;
            CanvasHandler.ResetCanvas();
            
        }
    }

    public void load() {
        Debug.Log("Room 3 load");
        activeChildCount = 0;

		//Sets the number of arrows shown in the drop panel to one. 
		for(int i = 0; i < CanvasHandler.arrowDragPanel.transform.childCount; i++){
			CanvasHandler.arrowDragPanel.transform.GetChild (i).gameObject.SetActive(false);
		}
        for (int i = 0; i < CanvasHandler.DragPanel.transform.childCount; i++){
				CanvasHandler.DragPanel.transform.GetChild(i).gameObject.SetActive(false);
		}
        for (int i = 1; i < CanvasHandler.DropPanel.transform.childCount; i++)
        {
            CanvasHandler.DropPanel.transform.GetChild(i).gameObject.SetActive(false);
        }

        //i variable button
        GameObject emptyGameobj = new GameObject();
        GameObject copyObject = Instantiate(
            CanvasHandler.VariableButton,
            CanvasHandler.DropPanel.transform.GetChild(0))
            as GameObject;
        copyObject.transform.GetChild(3).GetComponent<RectTransform>().localPosition = new Vector3(
            copyObject.transform.GetChild(3).GetComponent<RectTransform>().localPosition.x - 18, 0, 0);
        Destroy(copyObject.GetComponent<DragHandler>());
        Destroy(copyObject.transform.GetChild(2).gameObject);
        copyObject.transform.GetChild(1).GetComponent<Text>().text = "books = ";
        copyObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("DragAndDropPanel/dragThingRight");
        copyObject.transform.GetChild(1).Translate(
            copyObject.transform.GetChild(1).GetComponent<Text>().GetComponent<RectTransform>().localPosition.x - 40,
            copyObject.transform.GetChild(1).GetComponent<Text>().GetComponent<RectTransform>().localPosition.y,
            copyObject.transform.GetChild(1).GetComponent<Text>().GetComponent<RectTransform>().localPosition.z);
        emptyGameobj = new GameObject();
        emptyGameobj.transform.SetParent(CanvasHandler.DropPanel.transform.GetChild(0).transform.GetChild(0));
        emptyGameobj.transform.SetSiblingIndex(2);
        copyObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        copyObject.transform.localScale = new Vector3(1f, 1f, 0);

        //Debug.Log (new room1_AccessPanelAssignement ().GetDescription ());
        CanvasHandler.HeaderText.GetComponent<Text> ().text = new room3AccessPanelAssignement().GetDescription ();
		CanvasHandler.scaleDragPanel (activeChildCount);

        new Variables("Number of books", (string)null).AddToQueue(0);
    }
}
