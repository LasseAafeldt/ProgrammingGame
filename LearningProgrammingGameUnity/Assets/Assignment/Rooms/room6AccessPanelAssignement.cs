using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
#pragma warning disable 
public class room6AccessPanelAssignement : Assignment {
    public room6AccessPanelAssignement()
    {
        description = "Prevent the Bad Stuff from happening!";
		correctionList = new ArrayList ();
		IsEachCorrect = new ArrayList ();

        hints = new Hint(".",
            ".", 
            ".");
        ConsoleUI.AddText(hints.GetNextHint());
    }

    public static void IsEachResultCorrect()
    {
        IsEachCorrect.Clear();
        //should be less than 20 to be correct
        Debug.Log(RunQueue.GetAt(0).GetRight());
        Debug.Log(RunQueue.GetAt(1).GetRight());
        Debug.Log(RunQueue.GetAt(0).GetRight() + RunQueue.GetAt(1).GetRight());
        if (RunQueue.GetAt(0).GetRight() + RunQueue.GetAt(1).GetRight() >= 20)
        {
            IsEachCorrect.Add(false);
        }
        else
            IsEachCorrect.Add(true);
    }
}
 