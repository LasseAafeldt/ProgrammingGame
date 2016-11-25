using UnityEngine;
using System;
using System.Collections; 

public class PressEToInteract : MonoBehaviour {

    public static bool active = true;

    public static String currentToolTipText = "";

    public static int currentCount;
    public static String constructionCounterTooltip = "Construction modules: " + currentCount + "/5";
    public static String bookCounterTooltip = "Books collected: " +
        room3AccessPanelAssignement.bookCount;
    private static GUIStyle guiStyleFore;
    private static GUIStyle guiStyleBack;

 
    void Start()
    {
		
        guiStyleFore = new GUIStyle();
        guiStyleFore.normal.textColor = Color.white;
        currentCount = 0;
        guiStyleFore.alignment = TextAnchor.UpperLeft;
        guiStyleFore.wordWrap = true;
        guiStyleFore.fontSize = 22;
        guiStyleBack = new GUIStyle();
        guiStyleBack.normal.textColor = Color.black;
        guiStyleBack.alignment = TextAnchor.UpperLeft;
        guiStyleBack.wordWrap = true;
        guiStyleBack.fontSize = 22;
    }
    void Update()
    {
        
    }
    public static void Deactivate()
    {
        active = false;
    }
    public static void Activate()
    {
        active = true;
    }
    void OnGUI()
    {
        if (active)
        {
            float x;
            float y;
            if (CanvasHandler.DragAndDropCanvas.activeInHierarchy == false)
            {
                float distanceToObj = Vector3.Distance(CanvasHandler.Player.transform.position, gameObject.transform.position);
                if (distanceToObj < room1loadAccessPanelAssignment.interactionDistance)
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
                    //Debug.Log("i made book counter");
                    x = 60;
                    y = 100;
                    GUI.Label(new Rect(x, y, 300, 60), bookCounterTooltip, guiStyleBack);
                    GUI.Label(new Rect(x, y, 300, 60), bookCounterTooltip, guiStyleFore);
                    //bookCounterTooltip
                }
            }
        }
    }
}
