using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
#pragma warning disable 
public class room7AccessPanelAssignement : Assignment {
    public room7AccessPanelAssignement()
    {
        description = "Change all the damaged fuses.";
		correctionList = new ArrayList ();
		IsEachCorrect = new ArrayList ();

        hints = new Hint("You can drag items from the drag panel to the drop panel.",
            ".", 
            "Add more hints here...");
        ConsoleUI.AddText(hints.GetNextHint());
    }

    public static void IsEachResultCorrect()
    {
        IsEachCorrect.Clear();
        for(int i = 0; i < 3; i++)
            IsEachCorrect.Add(false);
        //Debug.Log("Checking each" + RunQueue.GetSize());
        if (GameObject.Find("DropSlot1").transform.GetChild(0).Equals(GameObject.Find("DragSlot11")))
        {
            IsEachCorrect[0] = true;
        }
        if (GameObject.Find("DropSlot2").transform.GetChild(0).Equals(GameObject.Find("DragSlot12")))
        {
            IsEachCorrect[1] = true;
        }
        if (GameObject.Find("DropSlot3").transform.GetChild(0).Equals(GameObject.Find("DragSlot10")))
        {
            IsEachCorrect[2] = true;
        }
    }
}
