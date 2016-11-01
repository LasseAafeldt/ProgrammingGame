using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class room1AccessPanelAssignement : Assignment {
    public room1AccessPanelAssignement()
    {
        description = "Write the 4 digit password code. Each digit must have its own slot.";
        FinalCorrect = true;
		correctionList = new ArrayList ();
		IsEachCorrect = new ArrayList ();
        correctionList.Add(9.0f);
        correctionList.Add(5.0f);
        correctionList.Add(8.0f);
        correctionList.Add(3.0f);
        hints = new Hint("You can drag items from the drag panel to the drop panel.",
            "The password code is hidden inside the room.", 
            "Add more hints here...");
        ConsoleUI.AddText(hints.GetNextHint());
    }

    public override void IsThisResultCorrect(int positionInCorrection, int positionInQueue)
    {
        if (correctionList.Count > positionInCorrection) {
            if (RunQueue.GetAt(positionInQueue).GetResult() == (float)correctionList[positionInCorrection])
                IsEachCorrect.Add(true);
            else
                IsEachCorrect.Add(false);
        }
        else 
            IsEachCorrect.Add(false);
        //Debug.Log(RunQueue.GetAt(positionInQueue).GetResult() + " " + correctionList[positionInCorrection]);
    }
}
