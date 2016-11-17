using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
#pragma warning disable 
public class room6AccessPanelAssignement : Assignment {
    public room6AccessPanelAssignement()
    {
        description = "Fill the drop panel with code. You may only use one if-statement. The code should only output 2 lines in the console.";
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
        if(RunQueue.numberOfRuns == 3)
        {
            IsEachCorrect.Add(true);
        }
    }
}
 