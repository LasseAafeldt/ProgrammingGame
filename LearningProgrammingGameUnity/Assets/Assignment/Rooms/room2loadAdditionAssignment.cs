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
        Debug.Log(distanceToObj); 
        if (distanceToObj < 3f) {
            if (Input.GetKeyDown("e") && CanvasHandler.DragAndDropCanvas.activeInHierarchy != true)
            {
                ManagerScript.ActiveID = ID;
                CanvasHandler.DragAndDropCanvas.SetActive(true);
                RunQueue.InitializeQueue();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                CharacterControll.canMove = false;
                CameraMousePan.canMove = false;
                this.load();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ManagerScript.ResetID();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            CanvasHandler.DragAndDropCanvas.SetActive(false);
            CharacterControll.canMove = true;
            CameraMousePan.canMove = true;
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

        //Debug.Log(CanvasHandler.VariableButton + " "+ CanvasHandler.DropPanel);

        // j variable button
        GameObject copyObject = Instantiate(
            CanvasHandler.VariableButton,
            CanvasHandler.DropPanel.transform.GetChild(0))
            as GameObject;
        Destroy(copyObject.GetComponent<DragHandler>());
        Destroy(copyObject.transform.GetChild(2).gameObject);
        copyObject.transform.GetChild(1).GetComponent<Text>().text = "j = ";
        GameObject emptyGameobj = new GameObject();
        emptyGameobj.transform.SetParent(CanvasHandler.DropPanel.transform.GetChild(0).transform.GetChild(0));
        emptyGameobj.transform.SetSiblingIndex(1);
        copyObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        copyObject.transform.localScale = new Vector3(1f, 1f, 0);

        //i variable button
        copyObject = Instantiate(
            CanvasHandler.VariableButton,
            CanvasHandler.DropPanel.transform.GetChild(1))
            as GameObject;
        Destroy(copyObject.GetComponent<DragHandler>());
        Destroy(copyObject.transform.GetChild(2).gameObject);
        copyObject.transform.GetChild(1).GetComponent<Text>().text = "i = ";
        copyObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("DragAndDropPanel/dragThingRight");
        emptyGameobj = new GameObject();
        emptyGameobj.transform.SetParent(CanvasHandler.DropPanel.transform.GetChild(1).transform.GetChild(0));
        emptyGameobj.transform.SetSiblingIndex(1);
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
		new Variables("j", (string) null).AddToQueue(1);
		new Variables("i", (string) null).AddToQueue(0);
        new Equation("i + j = 20").AddToQueue(2);
    }

}
