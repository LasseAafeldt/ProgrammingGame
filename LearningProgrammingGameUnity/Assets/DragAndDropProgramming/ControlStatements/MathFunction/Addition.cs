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
    public override string GetControlType()
    {
        return "Addition";
    }
}
