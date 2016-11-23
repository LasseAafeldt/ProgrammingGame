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
				ManagerScript.SetActiveID(ID);
                CanvasHandler.DragAndDropCanvas.SetActive(true);
                RunQueue.ResetQueue();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                ManagerScript.CanMove = false;
                this.load();
            }
        }
		if (Input.GetKeyDown(KeyCode.Q) && ManagerScript.GetActiveID() == 4)
        {
			//Debug.Log ("Active id: " + ManagerScript.GetActiveID());
			if (room4AccessPanelAssignement.IsFinalResultTrue ()) {
				//play sound after player solves the assignment and presses Q

				if (CanvasHandler.Player.GetComponent<AudioSource> ().isPlaying) {
					CanvasHandler.Player.GetComponent<AudioSource> ().Stop ();
				}
				//Debug.Log ("Active id: " + ManagerScript.GetActiveID());
				if(!AudioHandler.isWellDoneInOffice){
					//Debug.Log ("Audio source: " + CanvasHandler.Player.GetComponent<AudioSource> ());
					CanvasHandler.Player.GetComponent<AudioSource> ().PlayOneShot (AudioHandler.wellDoneInOfficeThermo);
					//Debug.Log ("Audio source: " + AudioHandler.wellDoneInOfficeThermo);
					AudioHandler.isWellDoneInOfficeThermo = !AudioHandler.isWellDoneInOfficeThermo;
					//Debug.Log ("Sound: " + AudioHandler.wellDoneInOfficeThermo);
				}
			}
            ManagerScript.ResetID();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            CanvasHandler.DragAndDropCanvas.SetActive(false);
            ManagerScript.CanMove = true;
            CanvasHandler.ResetCanvas();
            
        }
    }

    public void load() {
        Debug.Log("Room 4 load");
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
        copyObject.transform.GetChild(1).GetComponent<Text>().text = "temp = ";
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
        CanvasHandler.HeaderText.GetComponent<Text> ().text = new room4AccessPanelAssignement().GetDescription ();
		CanvasHandler.scaleDragPanel (activeChildCount);

        new Variables("Temperature", (string)null).AddToQueue(0);
    }
}
