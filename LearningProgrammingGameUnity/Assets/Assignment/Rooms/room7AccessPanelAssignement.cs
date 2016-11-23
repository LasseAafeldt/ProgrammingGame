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
            "You have to check all fuses to see which fuses are damaged.",
			"The damaged fuses should then be changed");
        //ConsoleUI.AddText(hints.GetNextHint());
		IsEachCorrect.Clear();
		IsEachCorrect.Add(false);

    }

    public static void IsEachResultCorrect()
    {
        IsEachCorrect.Clear();
        for(int i = 0; i < 3; i++)
            IsEachCorrect.Add(false);
        //Debug.Log("Checking each" + RunQueue.GetSize());
        String textt = GameObject.Find("DropSlot1").transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text;
        if (textt.Equals("For Each Fuse"))
        {
            IsEachCorrect[0] = true;
            //Debug.Log("first true");
        }
        textt = GameObject.Find("DropSlot2").transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text;
        if (textt.Equals("If Fuse Is Damaged"))
        {
            IsEachCorrect[1] = true;
            //Debug.Log("second true");
        }
        textt = GameObject.Find("DropSlot3").transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text;
        if (textt.Equals("Change Fuse"))
        {
            IsEachCorrect[2] = true;
            //Debug.Log("third true");
        }
    }
}
 