using UnityEngine;
using System.Collections;
using System;

public abstract class MathFunctions : ControlStatements
{
    public new float GetResult(){return result;}
    public override void RunThis()
    {
        Debug.Log(result);
        ConsoleUI.AddText(result.ToString());
    }
}
