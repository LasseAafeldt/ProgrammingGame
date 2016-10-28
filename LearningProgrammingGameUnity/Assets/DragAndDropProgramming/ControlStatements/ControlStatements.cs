using UnityEngine;
using System.Collections;
using System;

//abstract, cannot instantiate but create methods that are inheritet
public abstract class ControlStatements {
    protected float leftSide;
    protected float rightSide;
    public String str = null;
    protected float result;
    protected string condition;
    public virtual void UpdateResult()
    {
        result = leftSide + rightSide;
    }
    public virtual float GetResult() { return result; }
    public virtual float GetLeft() { return leftSide; }
    public virtual void SetLeft(float newValue)
    {
        leftSide = newValue;
        UpdateResult();
    }
    public virtual String GetVarName() { return null; }
    public virtual void SetVarName(String strng) { }
    public void SetRight(String strng)
    {
        str = strng;
    }
    public virtual void SetRight(String strng, int index) { }
    public float GetRight() { return rightSide; }
    public virtual void SetRight(float newValue)
    {
        rightSide = newValue;
        UpdateResult();
    }
    public void SetCondition(string condition)
    {
        this.condition = condition;
        UpdateResult();
    }
    public void AddToQueue(int position)
    {
        //Debug.Log("Trying to add " + this.GetControlType() + " to queue at position " + position);
        RunQueue.AddToQueue(this, position);
    }
    public void RemoveFromQueue(int position)
    {
        RunQueue.RemoveFromQueue(position);
    }
    public abstract string GetControlType();
    public abstract void RunThis();
}
