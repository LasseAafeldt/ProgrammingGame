using UnityEngine;
using System.Collections;
using System;

public class IfStatement : ControlStatements
{
    private new bool result;
    public IfStatement(float left, string condition, float right)
    {
        leftSide = left;
        rightSide = right;
        initIf();
    }
    public override void UpdateResult()
    {
        initIf();
    }
    private void initIf()
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
    public override string GetControlType()
    {
        return "IfStatement";
    }

    public override void RunThis()
    {
        if (result != true)
        {
            RunQueue.IncrementIterator();
        }
    }
}
