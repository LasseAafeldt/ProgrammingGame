using UnityEngine;
using System.Collections;


public abstract class ControlStatements {
    protected float leftSide;
    protected float rightSide;
    protected float result;
    protected string condition;
    public virtual void UpdateResult()
    {
        result = leftSide + rightSide;
    }
    public float GetLeft() { return leftSide; }
    public void SetLeft(float newValue)
    {
        leftSide = newValue;
        UpdateResult();
    }
    public float GetRight() { return rightSide; }
    public void SetRight(float newValue)
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
        RunQueue.AddToQueue(this, position);
    }
    public void RemoveFromQueue(int position)
    {
        RunQueue.RemoveFromQueue(position);
    }
    public abstract string GetControlType();
    public abstract void RunThis();
}
