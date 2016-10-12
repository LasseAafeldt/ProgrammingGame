using UnityEngine;
using System.Collections;
using System;

public class IfElseStatement : ControlStatements
{
    private float leftSide;
    private float rightSide;
    private string condition;
    private bool result;
    public IfElseStatement(float left, string condition, float right)
    {
        leftSide = left;
        rightSide = right;
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
        return "IfElseStatement";
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
