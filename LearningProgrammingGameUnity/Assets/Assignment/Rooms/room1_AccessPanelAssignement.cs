using UnityEngine;
using System.Collections;
using System;

public class room1_AccessPanelAssignement : Assignment {
    public static Hint hints;
    public room1_AccessPanelAssignement()
    {
        description = "Write the 4 digit password code. Each digit must have its own slot.";
        FinalCorrect = true;
		correctionList = new ArrayList ();
		IsEachCorrect = new ArrayList ();
        correctionList.Add(9.0f);
        correctionList.Add(5.0f);
        correctionList.Add(8.0f);
        correctionList.Add(3.0f);
        hints = new Hint("The password code is hidden inside the room.",
            "You can drag items from the drag panel to the drop panel.");
    }

    public override void IsThisResultCorrect(int positionInCorrection, int positionInQueue)
    {
        if (correctionList.Count > positionInCorrection) {
            if (RunQueue.GetAt(positionInQueue).GetResult() == (float)correctionList[positionInCorrection])
            {
                IsEachCorrect.Add(true);
            }
            else
                IsEachCorrect.Add(false);
        }
        else 
            IsEachCorrect.Add(false);

        //Debug.Log(RunQueue.GetAt(positionInQueue).GetResult() + " " + correctionList[positionInCorrection]);
    }
}
