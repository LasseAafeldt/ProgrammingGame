﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasHandler : MonoBehaviour {
    public static int WhichAccessPanel;
    public static bool IsInRange;
    public static GameObject DragAndDropCanvas;
    public static GameObject DragPanel;
    public static GameObject DropPanel;
    public static GameObject Console;
    public static GameObject Player;
    public static GameObject HeaderText;
    public static GameObject VariableButton;
    public static GameObject AdditionButton;
    public static GameObject EquationButton;
    public static GameObject AccessPanel1;
    public static GameObject ScreenOverlay;
	public static GameObject arrowDragPanel;
    public static GameObject Wires;
    public static GameObject Manual;
	public static GameObject ControlRoomBlocker;
	// Use this for initialization
    void Start () {
        ScreenOverlay = GameObject.Find("ScreenOverlayEnd");
        DragAndDropCanvas = GameObject.Find("DragAndDropCanvas");
        AccessPanel1 = GameObject.Find("AccessPanel1");
        DragPanel = GameObject.Find("DragPanel");
        Console = GameObject.Find("ConsolePanel");
        Player = GameObject.Find("Player");
        DropPanel = GameObject.Find("DropPanel");
        HeaderText = GameObject.Find("HeaderText");
        VariableButton = GameObject.Find("VariableButton");
        AdditionButton = GameObject.Find("AdditionButton");
        EquationButton = GameObject.Find("EquationButton");
		arrowDragPanel = GameObject.Find ("arrowDragPanel");
        Wires = GameObject.Find("WirePile");
        Manual = GameObject.Find("Manuel");
        //SDebug.Log("player = " + ScreenOverlay + "\n DropPanel = " + DropPanel) ;
        RunQueue.InitializeQueue();
        ScreenOverlay.SetActive(false);
        IsInRange = false;
        DragAndDropCanvas.SetActive(false);
        Wires.SetActive(false);
		Manual.SetActive(false);
		ControlRoomBlocker = GameObject.Find ("ControlRoomBlocker");
    }
	
	// Update is called once per frame
	void Update () { }

    public static void ResetCanvas()
    {
        for (int i = 0; i < DragPanel.transform.childCount; i++)
        {
            DragPanel.transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < DropPanel.transform.childCount; i++)
        {
            DropPanel.transform.GetChild(i).gameObject.SetActive(true);
            if (DropPanel.transform.GetChild(i).transform.childCount > 0)
            {
                for (int j = DropPanel.transform.GetChild(i).transform.childCount; j > 0; j--)
                {
                    //Debug.Log("i = " + i + " j = " + j + " child = " + DropPanel.transform.GetChild(i));
                    Destroy(DropPanel.transform.GetChild(i).transform.GetChild(j - 1).gameObject);
                    //Debug.Log("removing " + DropPanel.transform.GetChild(i).transform.GetChild(j - 1).gameObject);
                }
                //Debug.Log("child count " + DropPanel.transform.GetChild(i).transform.childCount);
            }
        }
        ConsoleUI.ResetText();
        HeaderText.GetComponent<Text>().text = "";
        RunQueue.ResetQueue();
    }
    public static void scaleDragPanel(int activeChildCount)
    {
        if (activeChildCount < 6)
        {
            CanvasHandler.DragPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 250);
            CanvasHandler.DragPanel.GetComponent<GridLayoutGroup>().childAlignment = TextAnchor.UpperCenter;
        }
        else
        {
            CanvasHandler.DragPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(200 * 2, 250);
            CanvasHandler.DragPanel.GetComponent<GridLayoutGroup>().childAlignment = TextAnchor.MiddleCenter;
        }
    }
    /*private bool IsInRange()
    {
        GameObject console = GameObject.Find("AccessPanelRoom1");
        GameObject player = GameObject.Find("Player");
        float distanceToConsole = Vector3.Distance(player.transform.position, console.transform.position);
        if (distanceToConsole < 1.2f)
        {
            WhichAccessPanel = 1;
            //RoomHandler.loadAssignment();
            return true;
        }
        
        console = GameObject.Find("AccessPanelRoom2");
        distanceToConsole = Vector3.Distance(player.transform.position, console.transform.position);
        //Debug.Log("distance = " + distanceToConsole);
        if (distanceToConsole < 1.2f)
        {
            WhichAccessPanel = 2;
            //RoomHandler.loadAssignment();
            return true;
        }
        WhichAccessPanel = -1;
        return false;
    }*/
}
