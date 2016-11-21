using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
#pragma warning disable 
public class room1AccessPanelAssignement : Assignment {
    public room1AccessPanelAssignement()
    {
        description = "Write the 4 digit password code. Each digit must have its own slot.";
		correctionList = new ArrayList ();
		IsEachCorrect = new ArrayList ();
        correctionList.Add(9.0f);
        correctionList.Add(5.0f);
        correctionList.Add(8.0f);
        correctionList.Add(3.0f);

        hints = new Hint("You can drag items from the drag panel to the drop panel.",
            "The password code is hidden inside the room.", 
            "Remember all four digits in the room before hitting play.");
        ConsoleUI.AddText(hints.GetNextHint());
    }

    public static void IsEachResultCorrect()
    {
        IsEachCorrect.Clear();
        foreach (float i in correctionList)
            IsEachCorrect.Add(false);
        //Debug.Log("Checking each" + RunQueue.GetSize());
        for (int i = 0; i < RunQueue.GetSize(); i++)
        {
            if (i < correctionList.Count)
            {
                if(RunQueue.GetAt(i) != null)
                {
                    if (RunQueue.GetAt(i).GetResult() == (float)correctionList[i])
                    {
                        IsEachCorrect[i] = true;
                    }
                }
            }
        }
    }
}
