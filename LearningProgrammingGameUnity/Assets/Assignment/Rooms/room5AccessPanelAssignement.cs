using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
#pragma warning disable 
public class room5AccessPanelAssignement : Assignment {
    public room5AccessPanelAssignement()
    {
        description = "Solve the if-statement on the wall.";
		correctionList = new ArrayList ();
		IsEachCorrect = new ArrayList ();

        hints = new Hint("You have to use the green boxes.");
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
