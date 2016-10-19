using UnityEngine;
using System.Collections;
using System;

public class Variables : ControlStatements
{
    public struct Value
    {
        public Value(String stre)
        {
            str = stre;
            flot = null;
        }
        public Value(float? i)
        {
            flot = i;
            str = null;
        }
        public String str;
        public float? flot;
    }

    private Value values;
    public Variables(float? i)
    {
        values = new Value(i);
    }
    public Variables(String a)
    {
        values = new Value(a);
    }

    public override string GetControlType()
    {
        return "Variable";
    }
    public Value GetValue()
    {
        return values;
    }
    public override void RunThis()
    {
        if(values.str != null)
            Debug.Log(values.str);
        if (values.flot != null)
            Debug.Log(values.flot);
    }
}
