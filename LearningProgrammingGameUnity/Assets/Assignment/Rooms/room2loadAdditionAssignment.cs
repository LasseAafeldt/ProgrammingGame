using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class room2loadAdditionAssignment : MonoBehaviour{
    protected GameObject obj;
    public static float distanceToObj;
    protected int activeChildCount;
    private static int ID = 2;

    // Use this for initialization
    void Start()
    {
        activeChildCount = 0;
        obj = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToObj = Vector3.Distance(CanvasHandler.Player.transform.position, obj.transform.position);
        //Debug.Log(distanceToObj); 
        if (distanceToObj < room1loadAccessPanelAssignment.interactionDistance) {
            if (Input.GetKeyDown("e") && CanvasHandler.DragAndDropCanvas.activeInHierarchy != true)
            {
                CanvasHandler.DragAndDropCanvas.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                ConsoleUI.ResetText();
                RunQueue.ResetQueue();
                CanvasHandler.ResetCanvas();
                ManagerScript.SetActiveID(ID);
                ManagerScript.CanMove = false;
                this.load();
            }
        }
		if (Input.GetKeyDown(KeyCode.Q) && ManagerScript.GetActiveID() == 2)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            CanvasHandler.DragAndDropCanvas.SetActive(false);
            ManagerScript.CanMove = true;
            RunQueue.ResetQueue();
            CanvasHandler.ResetCanvas();
        }
    }
    
    public void load()
    {
        Debug.Log("Room 2 load");
        for (int i = 0; i < CanvasHandler.DragPanel.transform.childCount; i++)
            CanvasHandler.DragPanel.transform.GetChild(i).gameObject.SetActive(false);

        //Debug.Log (new room1_AccessPanelAssignement ().GetDescription ());
        CanvasHandler.HeaderText.GetComponent<Text>().text = new room2_AdditionAssignment().GetDescription();
        CanvasHandler.scaleDragPanel(activeChildCount);
        GameObject objDrop = CanvasHandler.DropPanel;

		for(int i = 0; i < CanvasHandler.arrowDragPanel.transform.childCount; i++){
			CanvasHandler.arrowDragPanel.transform.GetChild (i).gameObject.SetActive(false);
		}

        for (int i = 3; i < objDrop.transform.childCount; i++)
            objDrop.transform.GetChild(i).gameObject.SetActive(false);

        // j variable button
        GameObject copyObject = Instantiate(
            CanvasHandler.VariableButton,
            CanvasHandler.DropPanel.transform.GetChild(0))
            as GameObject;
        copyObject.transform.GetChild(3).GetComponent<RectTransform>().localPosition = new Vector3(
             copyObject.transform.GetChild(3).GetComponent<RectTransform>().localPosition.x -18, 0, 0);
        Destroy(copyObject.GetComponent<DragHandler>());
        copyObject.transform.GetChild(2).gameObject.SetActive(false);
        copyObject.transform.GetChild(1).GetComponent<Text>().text = "j = ";
        copyObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("DragAndDropPanel/dragThingRight");
        //1,3
        copyObject.transform.GetChild(1).Translate(
            copyObject.transform.GetChild(1).GetComponent<Text>().GetComponent<RectTransform>().localPosition.x - 20,
            copyObject.transform.GetChild(1).GetComponent<Text>().GetComponent<RectTransform>().localPosition.y,
            copyObject.transform.GetChild(1).GetComponent<Text>().GetComponent<RectTransform>().localPosition.z);

        copyObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        copyObject.transform.localScale = new Vector3(1f, 1f, 0);

        //i variable button
        copyObject = Instantiate(
            CanvasHandler.VariableButton,
            CanvasHandler.DropPanel.transform.GetChild(1))
            as GameObject;
        copyObject.transform.GetChild(3).GetComponent<RectTransform>().localPosition = new Vector3(
            copyObject.transform.GetChild(3).GetComponent<RectTransform>().localPosition.x - 18, 0, 0);
        Destroy(copyObject.GetComponent<DragHandler>());
        copyObject.transform.GetChild(2).gameObject.SetActive(false);
        copyObject.transform.GetChild(1).GetComponent<Text>().text = "i = ";
        copyObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("DragAndDropPanel/dragThingRight");
        copyObject.transform.GetChild(1).Translate(
            copyObject.transform.GetChild(1).GetComponent<Text>().GetComponent<RectTransform>().localPosition.x - 20,
            copyObject.transform.GetChild(1).GetComponent<Text>().GetComponent<RectTransform>().localPosition.y,
            copyObject.transform.GetChild(1).GetComponent<Text>().GetComponent<RectTransform>().localPosition.z);
        copyObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        copyObject.transform.localScale = new Vector3(1f, 1f, 0);
    
        //equation text
        copyObject = Instantiate(
            CanvasHandler.EquationButton,
            CanvasHandler.DropPanel.transform.GetChild(2))
            as GameObject;
        copyObject.transform.GetChild(1).GetComponent<Text>().text = "i + j = 20";
        Destroy(copyObject.GetComponent<DragHandler>());
        copyObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        copyObject.transform.localScale = new Vector3(1f, 1f, 0);

        //Add the things to the queue
		new Variables("i", (string) null).AddToQueue(1);
		new Variables("j", (string) null).AddToQueue(0);
        new Equation("i + j = 20").AddToQueue(2);
    }

}
