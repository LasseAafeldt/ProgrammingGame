using UnityEngine;
using System.Collections;
using System;

public class Addition : MathFunctions
{
    public Addition(float? left, float? right)
    {
		if(left != null)
			leftSide = left.Value;
		if(right !=null)
			rightSide = right.Value;
		if (left != null && right != null)
			result = left.Value + right.Value;
    }
    public Addition(string first, string second)
    {
        str = first;
        VarName = second;
        result = 0;
        leftSide = 0;
        rightSide = 0;
    }
    public override string GetControlType()
    {
        return "Addition";
    }
}
