using UnityEngine;
using System.Collections;
using System;

public class room1_AccessPanelAssignement : Assignment {

    public room1_AccessPanelAssignement()
    {
        description = " descripe panel assignment in room one... ";
        IsFinalCorrect = false;
        correctionList.Add(9.0f);
        correctionList.Add(5.0f);
        correctionList.Add(8.0f);
        correctionList.Add(3.0f);
    }

    public override bool IsThisResultCorrect(int positionInCorrection, int positionInQueue)
    {
        currentTestPosition = 0;
        if (RunQueue.GetAt(positionInQueue).GetResult() == (float)correctionList[currentTestPosition])
        {
            IsEachCorrect.Add(true);
        }
        else
            IsEachCorrect.Add(false);

        foreach (bool i in IsEachCorrect) {
            if (!i)
            {
                IsFinalCorrect = true;
            }
        }
        return IsFinalCorrect;
    }
}
