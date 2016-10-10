using UnityEngine;
using System.Collections;
using System;

public class Addition : ControlStatements
{
    private float num1;
    private float num2;
    private float result;
    public Addition(float num1, float num2)
    {
        this.num1 = num1;
        this.num2 = num2;
        result = num1 + num2;
    }
    public override string GetType()
    {
        return "Addition";
    }
    public float GetResult()
    {
        return result;
    }
    public override void RunThis()
    {
        Debug.Log(result);
    }
}
