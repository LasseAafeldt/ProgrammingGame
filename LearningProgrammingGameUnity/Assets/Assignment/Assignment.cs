﻿using UnityEngine;
using System.Collections;
using System;

public abstract class Assignment  {

    protected String description;
    protected int currentTestPosition;
    protected ArrayList correctionList;
    protected ArrayList IsEachCorrect;
    protected bool FinalCorrect;
    public abstract void IsThisResultCorrect(int position, int positionInQueue);
    public String GetDescription() { return description; }

    public bool IsFinalResultTrue()
    {
        foreach (bool i in IsEachCorrect)
        {
            if (!i)
            {
                continue;
            }
            else
                return true;
        }
        return false;
    }
}
