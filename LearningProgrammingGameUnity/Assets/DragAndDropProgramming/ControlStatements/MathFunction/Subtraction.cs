using UnityEngine;
using System.Collections;
using System;

public class Subtraction : MathFunctions
{
    public Subtraction(float num1, float num2)
    {
        leftSide = num1;
        rightSide = num2;
        result = num1 - num2;
    }
    public override void UpdateResult()
    {
        result = leftSide - rightSide;
    }
    public override string GetControlType()
    {
        return "Subtraction";
    }
    public override void RunThis()
    {
        Debug.Log(result);
    }
}
