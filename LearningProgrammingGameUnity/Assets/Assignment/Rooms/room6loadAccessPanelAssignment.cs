using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class room6loadAccessPanelAssignment : MonoBehaviour{
    protected GameObject obj;
    protected int activeChildCount;
    public static float distanceToObj;
    private static int ID = 6;
    public static float interactionDistance;
    // Use this for initialization
    void Start()
    {
        interactionDistance = 3;
        activeChildCount = 0;
        obj = gameObject;
    }
    void Update()
    {
        distanceToObj = Vector3.Distance(CanvasHandler.Player.transform.position, obj.transform.position);
        if (distanceToObj < interactionDistance) {
            if(Input.GetKeyDown("e") && CanvasHandler.DragAndDropCanvas.activeInHierarchy != true)
            {
                PressEToInteract.currentToolTipText = "";
				ManagerScript.SetActiveID(ID);
                CanvasHandler.DragAndDropCanvas.SetActive(true);
                RunQueue.ResetQueue();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                ManagerScript.CanMove = false;
                this.load();
            }
        }
		if (Input.GetKeyDown(KeyCode.Q) && ManagerScript.GetActiveID() == 6)
        {
            ManagerScript.ResetID();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            CanvasHandler.DragAndDropCanvas.SetActive(false);
            ManagerScript.CanMove = true;
            CanvasHandler.ResetCanvas();
        }
    }

    public void load() {
        Debug.Log("Room 6 load");
        activeChildCount = 0;
        //set drag panel active
        for (int i = 0; i < CanvasHandler.DragPanel.transform.childCount; i++){
            /*if (i == GameObject.Find("DragSlot5").transform.GetSiblingIndex() ||
                i == GameObject.Find("DragSlot1").transform.GetSiblingIndex() ||
                i == GameObject.Find("DragSlot3").transform.GetSiblingIndex() ||
                i == GameObject.Find("DragSlot2").transform.GetSiblingIndex())
            {
                activeChildCount++;
            }
            else*/
            CanvasHandler.DragPanel.transform.GetChild(i).gameObject.SetActive(false); 
		}
        CanvasHandler.scaleDragPanel(activeChildCount);
		CanvasHandler.HeaderText.GetComponent<Text> ().text = new room6AccessPanelAssignement ().GetDescription ();
        //set drop panel slots active
        int numberOfActiveInDropPanel = 6;
        for (int i = numberOfActiveInDropPanel; i < CanvasHandler.DropPanel.transform.childCount; i++)
        {
            CanvasHandler.DropPanel.transform.GetChild(i).gameObject.SetActive(false);
        }
        //Sets the number of arrows shown in the drag panel. 
        for (int i = activeChildCount; i < CanvasHandler.arrowDragPanel.transform.childCount; i++)
        {
            CanvasHandler.arrowDragPanel.transform.GetChild(i).gameObject.SetActive(false);
        }

        // j variable button
        GameObject copyObject = Instantiate(
            CanvasHandler.VariableButton,
            CanvasHandler.DropPanel.transform.GetChild(0))
            as GameObject;
        copyObject.transform.GetChild(3).GetComponent<RectTransform>().localPosition = new Vector3(
             copyObject.transform.GetChild(3).GetComponent<RectTransform>().localPosition.x - 18, 0, 0);
        Destroy(copyObject.GetComponent<DragHandler>());
        Destroy(copyObject.transform.GetChild(2).gameObject);
        copyObject.transform.GetChild(1).GetComponent<Text>().text = "j = ";
        copyObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("DragAndDropPanel/dragThingRight");
        //1,3
        copyObject.transform.GetChild(1).Translate(
            copyObject.transform.GetChild(1).GetComponent<Text>().GetComponent<RectTransform>().localPosition.x - 20,
            copyObject.transform.GetChild(1).GetComponent<Text>().GetComponent<RectTransform>().localPosition.y,
            copyObject.transform.GetChild(1).GetComponent<Text>().GetComponent<RectTransform>().localPosition.z);

        GameObject emptyGameobj = new GameObject();
        emptyGameobj.transform.SetParent(CanvasHandler.DropPanel.transform.GetChild(0).transform.GetChild(0));
        emptyGameobj.transform.SetSiblingIndex(2);
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
        Destroy(copyObject.transform.GetChild(2).gameObject);
        copyObject.transform.GetChild(1).GetComponent<Text>().text = "i = ";
        copyObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("DragAndDropPanel/dragThingRight");
        copyObject.transform.GetChild(1).Translate(
            copyObject.transform.GetChild(1).GetComponent<Text>().GetComponent<RectTransform>().localPosition.x - 20,
            copyObject.transform.GetChild(1).GetComponent<Text>().GetComponent<RectTransform>().localPosition.y,
            copyObject.transform.GetChild(1).GetComponent<Text>().GetComponent<RectTransform>().localPosition.z);
        emptyGameobj = new GameObject();
        emptyGameobj.transform.SetParent(CanvasHandler.DropPanel.transform.GetChild(1).transform.GetChild(0));
        emptyGameobj.transform.SetSiblingIndex(2);
        copyObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        copyObject.transform.localScale = new Vector3(1f, 1f, 0);

        //equation text (if)
        copyObject = Instantiate(
            CanvasHandler.EquationButton,
            CanvasHandler.DropPanel.transform.GetChild(2))
            as GameObject;
        copyObject.transform.GetChild(1).GetComponent<Text>().text = "if i + j > 20";
        Destroy(copyObject.GetComponent<DragHandler>());
        copyObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        copyObject.transform.localScale = new Vector3(1f, 1f, 0);

        //equation text 
        copyObject = Instantiate(
            CanvasHandler.EquationButton,
            CanvasHandler.DropPanel.transform.GetChild(3))
            as GameObject;
        copyObject.transform.GetChild(1).GetComponent<Text>().text = "Bad Stuff will happen";
        Destroy(copyObject.GetComponent<DragHandler>());
        copyObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        copyObject.transform.localScale = new Vector3(1f, 1f, 0);

        //equation text Else
        copyObject = Instantiate(
            CanvasHandler.EquationButton,
            CanvasHandler.DropPanel.transform.GetChild(4))
            as GameObject;
        copyObject.transform.GetChild(1).GetComponent<Text>().text = "Else";
        Destroy(copyObject.GetComponent<DragHandler>());
        copyObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        copyObject.transform.localScale = new Vector3(1f, 1f, 0);

        //equation text OpenDoor
        copyObject = Instantiate(
            CanvasHandler.EquationButton,
            CanvasHandler.DropPanel.transform.GetChild(5))
            as GameObject;
        copyObject.transform.GetChild(1).GetComponent<Text>().text = "OpenDoor";
        Destroy(copyObject.GetComponent<DragHandler>());
        copyObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        copyObject.transform.localScale = new Vector3(1f, 1f, 0);
        new Variables("j", (string)null).AddToQueue(1);
        new Variables("i", (string)null).AddToQueue(0);
    }
}
