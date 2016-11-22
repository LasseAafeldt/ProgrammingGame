using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
#pragma warning disable 
public class room4AccessPanelAssignement : Assignment {
    public static float temperature = 38.1f - 5.3f;
    public room4AccessPanelAssignement()
    {
        description = "Set the temperature to the Out temperature minus the In temperature";
		correctionList = new ArrayList ();
		IsEachCorrect = new ArrayList ();
        hints = new Hint("You can see the In and Out temperature on the Thermometer");
        ConsoleUI.AddText(hints.GetNextHint());
    }

    public static void IsEachResultCorrect()
    {
        
        IsEachCorrect.Clear();
        if(RunQueue.GetAt(0).GetRight() == temperature)
            IsEachCorrect.Add(true);
        else
            IsEachCorrect.Add(false);
    }
}
