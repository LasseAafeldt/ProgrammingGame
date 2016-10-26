using UnityEngine;
using System.Collections;
using System;

public class Variables : ControlStatements
{
    public String VarName = null;
    public new float? leftSide = null;

    public Variables(String name, float? i)
    {
        VarName = name;
        leftSide = i;
    }
    public Variables(String name, String a)
    {
        VarName = name;
        str = a;
    }
    public override String GetVarName()
    {
        return VarName;
    }

    public override void SetVarName(String strng)
    {
        VarName = strng;
    }


    public override string GetControlType()
    {
        return "Variable";
    }
    public void GetValue(out String strng, out float flot)
    {
        strng = str;
        flot = leftSide.Value;        
    }
    public override void UpdateResult()
    {
        result = leftSide.Value + rightSide;
    }
    public override float GetLeft() { return leftSide.Value; }
    public override void SetLeft(float newValue)
    {
        leftSide = newValue;
        UpdateResult();
    }
    public override void SetRight(String strng, int index)
    {
        if(leftSide == null)
        {
            str = strng;
        }
        else
        {
            new Variables(this.VarName, strng).AddToQueue(index);
        }

    }
    public override void RunThis()
    {
        if (VarName != null)
        {
            if (str != null)
                Debug.Log(VarName + " = " + str);
            if (leftSide != null)
                Debug.Log(VarName + " = " + leftSide);
        }
    }
}
