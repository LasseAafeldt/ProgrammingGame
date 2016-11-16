﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class room7loadAccessPanelAssignment : MonoBehaviour{
    protected GameObject obj;
    protected int activeChildCount;
    public static float distanceToObj;
    private static int ID = 1;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ManagerScript.ResetID();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            CanvasHandler.DragAndDropCanvas.SetActive(false);
            CharacterControll.canMove = true;
            CameraMousePan.canMove = true;
            CanvasHandler.ResetCanvas();
        }
    }

    public void load() {
        Debug.Log("Room 7 load");
        activeChildCount = 0;
        //Debug.Log(obj);

		//Sets the number of arrows shown in the drop panel to one. 
		for(int i = 1; i < CanvasHandler.arrowDragPanel.transform.childCount; i++){
			CanvasHandler.arrowDragPanel.transform.GetChild (i).gameObject.SetActive(false);
		}

        for (int i = 0; i < CanvasHandler.DragPanel.transform.childCount; i++){
			if (i != GameObject.Find ("DragSlot10").transform.GetSiblingIndex () ||
                i != GameObject.Find("DragSlot11").transform.GetSiblingIndex() ||
                i != GameObject.Find("DragSlot12").transform.GetSiblingIndex())
            {
                CanvasHandler.DragPanel.transform.GetChild(i).gameObject.SetActive(false);
			}
			else
				activeChildCount ++;
		}
		CanvasHandler.scaleDragPanel (activeChildCount);
		//Debug.Log (new room1_AccessPanelAssignement ().GetDescription ());
		CanvasHandler.HeaderText.GetComponent<Text> ().text = new room7AccessPanelAssignement ().GetDescription ();
        int numberOfActiveInDropPanel = 3;
        for (int i = numberOfActiveInDropPanel; i < CanvasHandler.DropPanel.transform.childCount; i++)
        {
            CanvasHandler.DropPanel.transform.GetChild(i).gameObject.SetActive(false);
        }
        GameObject.Find("DragSlot11").transform.GetChild(1).GetComponent<Text>().text = "For Each Fuse";
        GameObject.Find("DragSlot12").transform.GetChild(1).GetComponent<Text>().text = "If Fuse Is Damaged";
        GameObject.Find("DragSlot10").transform.GetChild(1).GetComponent<Text>().text = "Change Fuse";

    }
}
