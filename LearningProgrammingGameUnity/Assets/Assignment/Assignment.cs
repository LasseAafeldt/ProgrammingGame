using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public abstract class Assignment{
    public static Hint hints;
    protected String description;
    protected int currentTestPosition;
    protected static ArrayList correctionList;
    protected static ArrayList IsEachCorrect;
    public String GetDescription() { return description; }

    public static bool IsFinalResultTrue()
    {
        int numberOfTrue = 0;
        foreach (bool i in IsEachCorrect)
        {
            if (i)
            {
                numberOfTrue++;
            }
        }
        if (numberOfTrue == IsEachCorrect.Count)
            return true;
        return false;
    }

    public void reset()
    {
        GameObject obj = GameObject.Find("DragPanel");
        if (obj != null)
        {
            for (int i = 0; i < obj.transform.childCount; i++)
            {
                obj.transform.GetChild(i).gameObject.SetActive(true);
            }
            ConsoleUI.ResetText();
        }
    }
}
