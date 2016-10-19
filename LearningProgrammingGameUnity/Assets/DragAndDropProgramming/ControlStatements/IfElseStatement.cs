using UnityEngine;
using System.Collections;
using System;

public class IfElseStatement : ControlStatements
{
    private new bool result;
    public IfElseStatement(float left, string condition, float right)
    {
        leftSide = left;
        rightSide = right;
        initIfElse();
    }
    public override string GetControlType()
    {
        return "IfElseStatement";
    }
    public override void UpdateResult()
    {
        initIfElse();
    }
    private void initIfElse()
    {
        if (condition.Equals("<") && leftSide < rightSide)
            result = true;
        else if (condition.Equals(">") && leftSide > rightSide)
            result = true;
        else if (condition.Equals(">=") && leftSide >= rightSide)
            result = true;
        else if (condition.Equals("<=") && leftSide <= rightSide)
            result = true;
        else if (condition.Equals("==") && leftSide == rightSide)
            result = true;
        else if (condition.Equals("!=") && leftSide != rightSide)
            result = true;
        else
            result = false;
    }

    public override void RunThis()
    {
        if (result == true)
        {
            RunQueue.Next().RunThis();
            RunQueue.IncrementIterator();
            RunQueue.IncrementIterator();
        }
        else
        {
            RunQueue.IncrementIterator();
        }
    }
}
