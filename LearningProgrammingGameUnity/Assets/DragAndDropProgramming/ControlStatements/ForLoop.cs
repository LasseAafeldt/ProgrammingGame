using UnityEngine;
using System.Collections;
using System;

public class ForLoop : ControlStatements {

    public ForLoop(float? limit)
    {
        if(limit != null)
            leftSide = (int)limit.Value;
    }

    public override string GetControlType()
    {
        return "ForLoop";
    }

    public override void RunThis()
    {
        for(int i = 0; i < leftSide-1; i++)
        {
            RunQueue.Next().RunThis();
        }
    }
}
