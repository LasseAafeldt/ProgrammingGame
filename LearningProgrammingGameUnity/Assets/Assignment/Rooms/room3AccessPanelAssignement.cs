using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
#pragma warning disable 
public class room3AccessPanelAssignement : Assignment {
    public static int maxBooks = 12;
    public static int bookCount = 0;
    public static bool isInsideArea = false;
    public room3AccessPanelAssignement()
    {
        description = "Find every book in this office and enter how many you found.";
		correctionList = new ArrayList ();
		IsEachCorrect = new ArrayList ();
        hints = new Hint("You can drag items from the drag panel to the drop panel.",
            "Add more hints here...");
        ConsoleUI.AddText(hints.GetNextHint());
		IsEachCorrect.Clear();
		IsEachCorrect.Add(false);
		IsEachCorrect.Add(false);
    }

    public static void IsEachResultCorrect()
    {
        IsEachCorrect.Clear();
        IsEachCorrect.Add(false);
        IsEachCorrect.Add(false);
        if (bookCount == maxBooks)
        {
            IsEachCorrect[0] = true;
        }
        if (RunQueue.GetAt(0).GetRight() == maxBooks)
        {
            IsEachCorrect[1] = true;
        }
    }
}
