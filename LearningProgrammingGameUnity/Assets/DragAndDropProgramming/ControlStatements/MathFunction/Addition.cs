using UnityEngine;
using System.Collections;
using System;

public class Addition : MathFunctions
{
    public Addition(float num1, float num2)
    {
        leftSide = num1;
        rightSide = num2;
        result = num1 + num2;
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
