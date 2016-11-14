using UnityEngine;
using System;
using System.Collections;

public class PressEToInteract : MonoBehaviour {

    String text = "YOUR TEXT HERE";
    public static bool active = false;

    public static String currentToolTipText = "";
    public static String constructionCounterTooltip = "Construction modules: 0/4";
    private static GUIStyle guiStyleFore;
    private static GUIStyle guiStyleBack;
 
    void Start()
    {
        guiStyleFore = new GUIStyle();
        guiStyleFore.normal.textColor = Color.white;
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
            if (currentToolTipText != "")
            {
                x = Screen.width / 2;
                y = Screen.height - 150;
                GUI.Label(new Rect(x - 149, y + 40, 300, 60), currentToolTipText, guiStyleBack);
                GUI.Label(new Rect(x - 150, y + 40, 300, 60), currentToolTipText, guiStyleFore);
            }
            x = 60;
            y = 60;
            GUI.Label(new Rect(x, y, 300, 60), constructionCounterTooltip, guiStyleBack);
            GUI.Label(new Rect(x, y, 300, 60), constructionCounterTooltip, guiStyleFore);
        }
    }
}
