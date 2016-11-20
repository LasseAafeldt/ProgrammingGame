using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
#pragma warning disable 
public class room3AccessPanelAssignement : Assignment {
    public static int maxBooks = 12;
    public static int bookCount;
    public static bool isInsideArea = false;
    public room3AccessPanelAssignement()
    {
        description = "Find every book in this office and enter how many you found.";
		correctionList = new ArrayList ();
		IsEachCorrect = new ArrayList ();
        bookCount = 0;



    hints = new Hint("You can drag items from the drag panel to the drop panel.",
           // "The password code is hidden inside the room.", 
            "A0dd more hints here...");
        ConsoleUI.AddText(hints.GetNextHint());
    }

    public static void IsEachResultCorrect()
    {
        IsEachCorrect.Clear();
        IsEachCorrect.Add(false);
        //Debug.Log("Checking each" + RunQueue.GetSize());
        for (int i = 0; i < RunQueue.GetSize(); i++)
        {
            if (i < correctionList.Count)
            {
                if(RunQueue.GetAt(i) != null)
                {
                    if (bookCount == maxBooks)
                    {
                        IsEachCorrect[0] = true;
                    }
                }
            }
        }
    }
}
