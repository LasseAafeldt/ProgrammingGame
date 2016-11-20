using UnityEngine;
using System;
using System.Collections;

public class PressEToInteract : MonoBehaviour {

    public static bool active = false;

    public static String currentToolTipText = "";
    public static int currentCount;
    public static String constructionCounterTooltip = "Construction modules: " + currentCount + "/5";
    public static String bookCounterTooltip = "Books collected modules: " + room3AccessPanelAssignement.bookCount + "/5";
    private static GUIStyle guiStyleFore;
    private static GUIStyle guiStyleBack;
 
    void Start()
    {
        guiStyleFore = new GUIStyle();
        guiStyleFore.normal.textColor = Color.white;
        currentCount = 0;
        guiStyleFore.alignment = TextAnchor.UpperCenter;
        guiStyleFore.wordWrap = true;
        guiStyleFore.fontSize = 20;
        guiStyleBack = new GUIStyle();
        guiStyleBack.normal.textColor = Color.black;
        guiStyleBack.alignment = TextAnchor.UpperCenter;
        guiStyleBack.wordWrap = true;
        guiStyleBack.fontSize = 20;
        //Debug.Log("fore = " + guiStyleFore + " back = " + guiStyleBack);
    }
    void Update()
    {
        
    }

    void OnGUI()
    {
        float x;
        float y;
        if (CanvasHandler.DragAndDropCanvas.activeInHierarchy == false)
        {

            if (room1loadAccessPanelAssignment.distanceToObj < room1loadAccessPanelAssignment.interactionDistance|| 
                room2loadAdditionAssignment.distanceToObj < room1loadAccessPanelAssignment.interactionDistance ||
                room3loadAccessPanelAssignment.distanceToObj < room1loadAccessPanelAssignment.interactionDistance||
                room6loadAccessPanelAssignment.distanceToObj < room1loadAccessPanelAssignment.interactionDistance ||
                room7loadAccessPanelAssignment.distanceToObj < room1loadAccessPanelAssignment.interactionDistance)
            {
                PressEToInteract.currentToolTipText = "Press E to interact";
                x = Screen.width / 2;
                y = Screen.height - 150;
                GUI.Label(new Rect(x - 149, y + 40, 300, 60), currentToolTipText, guiStyleBack);
                GUI.Label(new Rect(x - 150, y + 40, 300, 60), currentToolTipText, guiStyleFore);
            }
            else
                PressEToInteract.currentToolTipText = "";
            x = 60;
            y = 60;
            GUI.Label(new Rect(x, y, 300, 60), constructionCounterTooltip, guiStyleBack);
            GUI.Label(new Rect(x, y, 300, 60), constructionCounterTooltip, guiStyleFore);

            if(room3AccessPanelAssignement.isInsideArea == true)
            {
                Debug.Log("i made book counter");
                x = 60;
                y = 60;
                GUI.Label(new Rect(x, y, 300, 60), bookCounterTooltip, guiStyleBack);
                GUI.Label(new Rect(x, y, 300, 60), bookCounterTooltip, guiStyleFore);
            }
        }
    }
}
