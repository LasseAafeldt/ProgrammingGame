using UnityEngine;
using System.Collections;
using System;

public class Variables : ControlStatements
{
    public Variables(String name, float? i)
    {
        VarName = name;
		if (i != null) {
			rightSide = i.Value;
			result = i.Value;
		}
        str = null;
    }
    public Variables(String name, String a)
    {
        VarName = name;
        str = a;
    }
    public override float GetResult()
    {
        //Debug.Log(this.result + " name = " + this.GetVarName());
        return this.result;
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
        flot = rightSide;        
    }
    public override void UpdateResult()
    {
        result = rightSide;
    }

    public override void SetRight(float newValue)
    {
        rightSide = newValue;
        //Debug.Log("set right to " + newValue);
        str = null;
        UpdateResult();
    }
    public override void SetRight(String strng, int index)
    {
        new Variables(this.VarName, strng).AddToQueue(index);
    }
    public override void RunThis()
    {
        if (VarName != null)
        {
            if (str != null)
            {
                ConsoleUI.AddText(VarName + " = " + str);
            }
            else
            {
                ConsoleUI.AddText(VarName + " = " + rightSide);
            }
        }
    }
}
