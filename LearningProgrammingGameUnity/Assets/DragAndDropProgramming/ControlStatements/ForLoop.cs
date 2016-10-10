using UnityEngine;
using System.Collections;
using System;

public class ForLoop : ControlStatements {
   
    private int limit = 0;

    public ForLoop(int limit)
    {
        this.limit = limit;
    }

    public override string GetType()
    {
        return "ForLoop";
    }

    public override void RunThis()
    {
        for(int i = 0; i < limit; i++)
        {
            RunQueue.Next().RunThis();
        }
    }
}
