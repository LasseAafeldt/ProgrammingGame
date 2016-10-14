using UnityEngine;
using System.Collections;
using System;

public class Subtraction : MathFunctions
{
    public Subtraction(float num1, float num2)
    {
        this.num1 = num1;
        this.num2 = num2;
        result = num1 - num2;
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
