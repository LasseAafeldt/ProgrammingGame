using UnityEngine;
using System.Collections;
using System;

public class Division : MathFunctions
{
    public Division(float num1, float num2)
    {
        leftSide = num1;
        rightSide = num2;
        result = num1 / num2;
    }
    public override void UpdateResult()
    {
        result = leftSide / rightSide;
    }
    public override string GetControlType()
    {
        return "Division";
    }

    public override void RunThis()
    {
        Debug.Log(result);
    }
}
