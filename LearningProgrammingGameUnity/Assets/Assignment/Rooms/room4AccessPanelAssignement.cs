using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
#pragma warning disable 
public class room4AccessPanelAssignement : Assignment {
    public float temperature = 0.0f;
    public room4AccessPanelAssignement()
    {
        description = "Find every book in this office and enter how many you found.";
		correctionList = new ArrayList ();
		IsEachCorrect = new ArrayList ();
        hints = new Hint("You can drag items from the drag panel to the drop panel.",
            "Add more hints here...");
        ConsoleUI.AddText(hints.GetNextHint());
    }

    public static void IsEachResultCorrect()
    {
        IsEachCorrect.Clear();
        IsEachCorrect.Add(false);
        IsEachCorrect.Add(false);
    }
}
