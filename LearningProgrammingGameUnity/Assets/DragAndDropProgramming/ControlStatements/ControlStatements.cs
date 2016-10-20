﻿using UnityEngine;
using System.Collections;
using System;


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
