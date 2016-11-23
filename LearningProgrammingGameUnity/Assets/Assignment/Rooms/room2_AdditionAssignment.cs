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

        hints = new Hint("You have to assign values to both j and i.");
    }


    public static void IsEachResultCorrect()
    {

        IsEachCorrect.Clear();
		IsEachCorrect.Add(false);

        if (RunQueue.GetAt(0).GetRight() + RunQueue.GetAt(1).GetRight() == 20)
        {
            IsEachCorrect[0] = true;
        }
    }
    // i = ?;
    // j = ?;
    // i+j = 20

}
