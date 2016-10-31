using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class room2_AdditionAssignment : Assignment
{


    public override void IsThisResultCorrect(int position, int positionInQueue)
    {
    }
    // i = ?;
    // j = ?;
    // i+j = 20

    // Use this for initialization
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void load()
    {
        for (int i = 0; i < obj.transform.childCount; i++)
            obj.transform.GetChild(i).gameObject.SetActive(false);

        //Debug.Log (new room1_AccessPanelAssignement ().GetDescription ());
        GameObject.Find("HeaderText").GetComponent<Text>().text = new room2_AdditionAssignment().GetDescription();
        this.scaleDragPanel();

        GameObject objDrop = GameObject.Find("DropPanel");
        for (int i = 3; i < obj.transform.childCount; i++)
            objDrop.transform.GetChild(i).gameObject.SetActive(false);

        GameObject copyObject = Instantiate(GameObject.Find("VaribleButton"), GameObject.Find("DropPanel").transform) as GameObject;
        Destroy(copyObject.GetComponent<DragHandler>());
        copyObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        copyObject.transform.localScale = new Vector3(1f, 1f, 0);
    }

}
