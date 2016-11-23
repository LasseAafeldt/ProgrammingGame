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
        hints = new Hint("You can see the In and Out temperature on the Thermometer");
        ConsoleUI.AddText(hints.GetNextHint());
		temperature = 38.1f - 5.3f;
		IsEachCorrect.Clear();
		IsEachCorrect.Add(false);
    }

    public static void IsEachResultCorrect()
    {
        
        IsEachCorrect.Clear();
		IsEachCorrect.Add(false);
		Debug.Log (RunQueue.GetAt (0).GetRight ());
		Debug.Log (temperature);
        if(RunQueue.GetAt(0).GetRight() == temperature)
			IsEachCorrect[0] = true;
    }
}
