using UnityEngine;
using System.Collections;
using System;

public class Division : ControlStatements
{
    private float num1;
    private float num2;
    private float result;
    public Division(float num1, float num2)
    {
        this.num1 = num1;
        this.num2 = num2;
        result = num1 / num2;
    }

    public float GetResult()
    {
        return result;
    }
    public override string GetType()
    {
        return "Division";
    }

    public override void RunThis()
    {
        Debug.Log(result);
    }
}
