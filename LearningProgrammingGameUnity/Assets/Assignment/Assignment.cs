using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public abstract class Assignment{
    public static Hint hints;
    protected String description;
    protected int currentTestPosition;
    protected ArrayList correctionList;
    protected ArrayList IsEachCorrect;
    protected bool FinalCorrect;
    public abstract void IsThisResultCorrect(int position, int positionInQueue);
    public String GetDescription() { return description; }

    public bool IsFinalResultTrue()
    {
        foreach (bool i in IsEachCorrect)
        {
            if (!i)
            {
                continue;
            }
            else
                return true;
        }
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

    //LOADER:
    protected GameObject obj;
    protected int activeChildCount;
    // Use this for initialization
    protected void Start()
    {
        activeChildCount = 0;
        obj = gameObject;
    }
    // Update is called once per frame
    protected void Update(){ }
    public abstract void load();
    protected void scaleDragPanel()
    {
        if (activeChildCount < 6)
        {
            obj.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 250);
            obj.GetComponent<GridLayoutGroup>().childAlignment = TextAnchor.UpperCenter;
        }
        else
        {
            obj.GetComponent<RectTransform>().sizeDelta = new Vector2(200 * 2, 250);
            obj.GetComponent<GridLayoutGroup>().childAlignment = TextAnchor.MiddleCenter;
        }
    }
}
