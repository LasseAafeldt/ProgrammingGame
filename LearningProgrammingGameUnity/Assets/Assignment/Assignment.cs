using UnityEngine;
using System.Collections;
using System;

public abstract class Assignment  {

    protected String description;
    protected int currentTestPosition;
    protected ArrayList correctionList;
    protected ArrayList IsEachCorrect;
    protected bool IsFinalCorrect;
    public abstract bool IsThisResultCorrect(int position, int positionInQueue);
    public String GetDescription() { return description; }
}
