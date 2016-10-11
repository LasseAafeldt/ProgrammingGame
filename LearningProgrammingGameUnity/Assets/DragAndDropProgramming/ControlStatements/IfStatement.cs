using UnityEngine;
using System.Collections;
using System;

public class IfStatement : ControlStatements {

    private float leftSide;
    private float rightSide;
    private string condition;
    private bool result;
    public IfStatement(bool result)
    {
        this.result = result;
    }
    public IfStatement(float left, string condition, float right)
    {
        leftSide = left;
        rightSide = right;
        if (condition.Equals("<") && leftSide < rightSide)
        {
            result = true;
        }
        else if (condition.Equals(">") && leftSide > rightSide)
        {
            result = true;
        }
        else if (condition.Equals(">=") && leftSide >= rightSide)
        {
            result = true;
        }
        else if (condition.Equals("<=") && leftSide <= rightSide)
        {
            result = true;
        }
        else if (condition.Equals("==") && leftSide == rightSide)
        {
            result = true;
        }
        else if (condition.Equals("!=") && leftSide != rightSide)
        {
            result = true;
        }
        else
        {
            result = false;
        }
    }
    public override string GetType()
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
