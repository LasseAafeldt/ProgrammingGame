using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class room7loadAccessPanelAssignment : MonoBehaviour{
    protected GameObject obj;
    protected int activeChildCount;
    public static float distanceToObj;
    private static int ID = 7;
    public static float interactionDistance;
    // Use this for initialization
    void Start()
    {
        interactionDistance = 3;
        activeChildCount = 0;
        obj = gameObject;
    }
    void Update()
    {
        distanceToObj = Vector3.Distance(CanvasHandler.Player.transform.position, obj.transform.position);
        //Debug.Log(distanceToObj);
        if (distanceToObj < interactionDistance) {
            if(Input.GetKeyDown("e") && CanvasHandler.DragAndDropCanvas.activeInHierarchy != true)
            {
                PressEToInteract.currentToolTipText = "";
                CanvasHandler.DragAndDropCanvas.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                ManagerScript.CanMove = false;
                ConsoleUI.ResetText();
                ManagerScript.SetActiveID(ID);
                this.load();
            }
        }
		if (Input.GetKeyDown(KeyCode.Q) && ManagerScript.GetActiveID() == 7)
        {
			if (room7AccessPanelAssignement.IsFinalResultTrue ()) {
				//play sound after player solves the assignment and presses Q
				Debug.Log("IsFInalResult = " + room7AccessPanelAssignement.IsFinalResultTrue());
                if (CanvasHandler.Player.GetComponent<AudioSource>().isPlaying)
                {
                    CanvasHandler.Player.GetComponent<AudioSource>().Stop();

                }
                if (!AudioHandler.isPlayerSolvesLastTask)
                {
                    Debug.Log("Sound source = " + AudioHandler.isPlayerSolvesLastTask);
                    CanvasHandler.Player.GetComponent<AudioSource>().PlayOneShot(AudioHandler.playerSolvesLastTask);
                    AudioHandler.isPlayerSolvesLastTask = !AudioHandler.isPlayerSolvesLastTask;
                }
            }
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            CanvasHandler.DragAndDropCanvas.SetActive(false);
            ManagerScript.CanMove = true;
            RunQueue.ResetQueue();
            CanvasHandler.ResetCanvas();
        }
    }

    public void load() {
        Debug.Log("Room 7 load");
        activeChildCount = 0;
        //Debug.Log(obj);
        for (int i = 0; i < CanvasHandler.DragPanel.transform.childCount; i++){
            //Debug.Log("i = " + i +" " + GameObject.Find ("DragSlot10").transform.GetSiblingIndex ());
            //Debug.Log(i == GameObject.Find("DragSlot10").transform.GetSiblingIndex());
            if (i == GameObject.Find("DragSlot10").transform.GetSiblingIndex() ||
                i == GameObject.Find("DragSlot11").transform.GetSiblingIndex() ||
                i == GameObject.Find("DragSlot12").transform.GetSiblingIndex())
            {
                activeChildCount++;
            }
            else
            {
                //Debug.Log("Deactivated " + CanvasHandler.DragPanel.transform.GetChild(i));
                CanvasHandler.DragPanel.transform.GetChild(i).gameObject.SetActive(false);
            }
		}
		CanvasHandler.scaleDragPanel (activeChildCount);
		//Debug.Log (new room1_AccessPanelAssignement ().GetDescription ());
		CanvasHandler.HeaderText.GetComponent<Text> ().text = new room7AccessPanelAssignement ().GetDescription ();
        int numberOfActiveInDropPanel = 3;
        for (int i = numberOfActiveInDropPanel; i < CanvasHandler.DropPanel.transform.childCount; i++)
        {
            CanvasHandler.DropPanel.transform.GetChild(i).gameObject.SetActive(false);
        }
        //Sets the number of arrows shown in the drop panel to one. 
        for (int i = activeChildCount; i < CanvasHandler.arrowDragPanel.transform.childCount; i++)
        {
            CanvasHandler.arrowDragPanel.transform.GetChild(i).gameObject.SetActive(false);
        }
        GameObject.Find("DragSlot11").transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = "For Each Fuse";
        GameObject.Find("DragSlot12").transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = "If Fuse Is Damaged";
        GameObject.Find("DragSlot10").transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = "Change Fuse";

    }
}
