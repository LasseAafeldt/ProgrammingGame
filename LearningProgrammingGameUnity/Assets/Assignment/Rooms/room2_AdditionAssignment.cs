using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class room2_AdditionAssignment : Assignment
{
    public room2_AdditionAssignment()
    {
        description = "Set the two variables such that the equation is true";
        correctionList = new ArrayList();
        IsEachCorrect = new ArrayList();
        hints = new Hint("You can drag items from the drag panel to the drop panel.",
            "The password code is hidden inside the room.",
            "Add more hints here...");
    }


    public static void IsEachResultCorrect()
    {

        IsEachCorrect.Clear();
        if (RunQueue.GetAt(0).GetRight() + RunQueue.GetAt(1).GetRight() == 20)
        {
            IsEachCorrect.Add(true);
        }
        else
            IsEachCorrect.Add(false);

    }
    // i = ?;
    // j = ?;
    // i+j = 20

}
