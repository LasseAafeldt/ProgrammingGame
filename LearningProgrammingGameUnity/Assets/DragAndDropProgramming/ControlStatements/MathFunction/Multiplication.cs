using UnityEngine;
using System.Collections;
using System;

public class Multiplication : MathFunctions
{

    public Multiplication(float num1, float num2)
    {
        leftSide = num1;
        rightSide = num2;
        result = num1 * num2;
    }
    public override void UpdateResult()
    {
        result = leftSide * rightSide;
    }
    public override string GetControlType()
    {
        return "Multiplication";
    }
}
