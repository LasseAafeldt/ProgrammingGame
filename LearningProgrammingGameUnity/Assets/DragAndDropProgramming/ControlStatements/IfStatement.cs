using UnityEngine;
using System.Collections;
using System;

public class IfStatement : ControlStatements
{
    private new bool result;
    public IfStatement(float? left, string condition, float? right)
    {
		if(left != null)
        	leftSide = left.Value;
		if(right !=null)
        	rightSide = right.Value;
		if (condition != null)
			this.condition = condition;
		if (left != null && right != null)
       	 	initIf();

    }
    public override void UpdateResult()
    {
        initIf();
    }
    private void initIf()
    {
//		Debug.Log ("Checking if statement result " + leftSide + ","+ rightSide + "," + condition);
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
//		Debug.Log("Finished checking if - result = " + result);
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
