using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class room2loadAdditionAssignment : MonoBehaviour
{
    protected GameObject obj;
    GameObject console;
    GameObject player;
    protected int activeChildCount;
    // Use this for initialization
    void Start()
    {
        activeChildCount = 0;
        obj = gameObject;
        console = obj;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToConsole = Vector3.Distance(player.transform.position, console.transform.position);
        if (Input.GetKeyDown("e") && distanceToConsole < 1.2f && CanvasHandler.DragAndDropCanvas.activeInHierarchy != true)
        {
            CanvasHandler.DragAndDropCanvas.SetActive(true);
            RunQueue.InitializeQueue();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            CharacterControll.canMove = false;
            CameraMousePan.canMove = false;
            this.load();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
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
        obj = CanvasHandler.DragPanel;

        for (int i = 0; i < obj.transform.childCount; i++)
            obj.transform.GetChild(i).gameObject.SetActive(false);

        //Debug.Log (new room1_AccessPanelAssignement ().GetDescription ());
        CanvasHandler.HeaderText.GetComponent<Text>().text = new room2_AdditionAssignment().GetDescription();
        CanvasHandler.scaleDragPanel(activeChildCount);
        GameObject objDrop = CanvasHandler.DropPanel;
        for (int i = 3; i < objDrop.transform.childCount; i++)
            objDrop.transform.GetChild(i).gameObject.SetActive(false);

        //Debug.Log(CanvasHandler.VariableButton + " "+ CanvasHandler.DropPanel);

        GameObject copyObject = Instantiate(
            CanvasHandler.VariableButton,
            CanvasHandler.DropPanel.transform.GetChild(0))
            as GameObject;
        Destroy(copyObject.GetComponent<DragHandler>());
        copyObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        copyObject.transform.localScale = new Vector3(1f, 1f, 0);

        copyObject = Instantiate(
            CanvasHandler.VariableButton,
            CanvasHandler.DropPanel.transform.GetChild(1))
            as GameObject;
        Destroy(copyObject.GetComponent<DragHandler>());
        copyObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        copyObject.transform.localScale = new Vector3(1f, 1f, 0);
    
        copyObject = Instantiate(
            CanvasHandler.EquationButton,
            CanvasHandler.DropPanel.transform.GetChild(2))
            as GameObject;
        //CanvasHandler.EquationButton.transform.GetChild(0).GetComponent<Text>().text = "hej";
        Destroy(copyObject.GetComponent<DragHandler>());
        copyObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        copyObject.transform.localScale = new Vector3(1f, 1f, 0);
        new Variables("i", null).AddToQueue(0);
        new Variables("j", null).AddToQueue(1);
        new Equation("i + j = 20").AddToQueue(2);
    }

}
