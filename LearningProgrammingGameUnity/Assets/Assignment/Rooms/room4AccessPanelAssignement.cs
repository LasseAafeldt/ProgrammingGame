using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
#pragma warning disable 
public class room4AccessPanelAssignement : Assignment {
    public static float temperature;
    public room4AccessPanelAssignement()
    {
        description = "Set the temperature to the Out temperature minus the In temperature";
		correctionList = new ArrayList ();
		IsEachCorrect = new ArrayList ();
        hints = new Hint("","You can see the In and Out temperatures on the Thermometer.", "Use '.' as digit sign.");
        ConsoleUI.AddText(hints.GetNextHint());
        temperature = 38.1f - 5.3f;

    }

    public static void IsEachResultCorrect()
    {
        IsEachCorrect.Clear();
		IsEachCorrect.Add(false);
        if (RunQueue.GetAt(0).GetRight() == temperature)
			IsEachCorrect[0] = true;
    }
}
