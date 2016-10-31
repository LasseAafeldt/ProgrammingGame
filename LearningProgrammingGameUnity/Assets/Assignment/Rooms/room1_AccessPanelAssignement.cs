using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class room1_AccessPanelAssignement : Assignment {
    public room1_AccessPanelAssignement()
    {
        description = "Write the 4 digit password code. Each digit must have its own slot.";
        FinalCorrect = true;
		correctionList = new ArrayList ();
		IsEachCorrect = new ArrayList ();
        correctionList.Add(9.0f);
        correctionList.Add(5.0f);
        correctionList.Add(8.0f);
        correctionList.Add(3.0f);
        hints = new Hint("You can drag items from the drag panel to the drop panel.",
            "The password code is hidden inside the room.", 
            "Add more hints here...");
        ConsoleUI.AddText(hints.GetNextHint());
    }

    public override void IsThisResultCorrect(int positionInCorrection, int positionInQueue)
    {
        if (correctionList.Count > positionInCorrection) {
            if (RunQueue.GetAt(positionInQueue).GetResult() == (float)correctionList[positionInCorrection])
                IsEachCorrect.Add(true);
            else
                IsEachCorrect.Add(false);
        }
        else 
            IsEachCorrect.Add(false);
        //Debug.Log(RunQueue.GetAt(positionInQueue).GetResult() + " " + correctionList[positionInCorrection]);
    }

    //LOADER
    // Use this for initialization
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {

    }

    public override void load()
    {
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            if (i != GameObject.Find("DragSlot9").transform.GetSiblingIndex())
                obj.transform.GetChild(i).gameObject.SetActive(false);
            else
                activeChildCount++;
        }
        //Debug.Log (new room1_AccessPanelAssignement ().GetDescription ());
        GameObject.Find("HeaderText").GetComponent<Text>().text = new room1_AccessPanelAssignement().GetDescription();
        this.scaleDragPanel();
        obj = GameObject.Find("DropPanel");
        for (int i = 4; i < obj.transform.childCount; i++)
        {
            obj.transform.GetChild(i).gameObject.SetActive(false);
        }

    }
}
