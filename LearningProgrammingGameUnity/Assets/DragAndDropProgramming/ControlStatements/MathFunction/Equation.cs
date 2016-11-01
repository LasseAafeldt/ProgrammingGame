using UnityEngine;
using System.Collections;
using System;

public class Equation : MathFunctions {

    public Equation(String strng)
    {
        str = strng;
    }
    public override void RunThis()
    {
        Debug.Log(str);
        ConsoleUI.AddText(str);
    }

    public override string GetControlType()
    {
        return "Equation";
    }
}
