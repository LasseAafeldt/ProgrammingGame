using UnityEngine;
using System.Collections;
using System;

public abstract class MathFunctions : ControlStatements
{
    protected float num1;
    protected float num2;
    protected float result;
    public float GetLeft(){return num1;}
    public float GetRight(){return num2;}
    public float GetResult(){return result;}

}
