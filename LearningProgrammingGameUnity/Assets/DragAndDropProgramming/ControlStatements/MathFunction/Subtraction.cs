using UnityEngine;
using System.Collections;
using System;

public class Subtraction : MathFunctions
{
    public Subtraction(float? left, float? right)
    {
		if(left != null)
			leftSide = left.Value;
		if(right !=null)
			rightSide = right.Value;
		if (left != null && right != null)
			result = left.Value - right.Value;
        Debug.Log("Created subtraction");
    }
    public override void UpdateResult()
    {
        result = leftSide - rightSide;
    }
    public override string GetControlType()
    {
        return "Subtraction";
    }
}
