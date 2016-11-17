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
                ManagerScript.ActiveID = ID;
                CanvasHandler.DragAndDropCanvas.SetActive(true);
                RunQueue.ResetQueue();
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

    public void load() {
        Debug.Log("Room 6 load");
        activeChildCount = 0;
        //set drag panel active
        for (int i = 0; i < CanvasHandler.DragPanel.transform.childCount; i++){
            if (i == GameObject.Find("DragSlot5").transform.GetSiblingIndex() ||
                i == GameObject.Find("DragSlot1").transform.GetSiblingIndex() ||
                i == GameObject.Find("DragSlot3").transform.GetSiblingIndex() ||
                i == GameObject.Find("DragSlot2").transform.GetSiblingIndex())
            {
                activeChildCount++;
            }
            else
                CanvasHandler.DragPanel.transform.GetChild(i).gameObject.SetActive(false); 
		}
        CanvasHandler.scaleDragPanel(activeChildCount);
		CanvasHandler.HeaderText.GetComponent<Text> ().text = new room6AccessPanelAssignement ().GetDescription ();
        //set drop panel slots active
        int numberOfActiveInDropPanel = activeChildCount;
        for (int i = numberOfActiveInDropPanel; i < CanvasHandler.DropPanel.transform.childCount; i++)
        {
            CanvasHandler.DropPanel.transform.GetChild(i).gameObject.SetActive(false);
        }
        //Sets the number of arrows shown in the drag panel. 
        for (int i = activeChildCount; i < CanvasHandler.arrowDragPanel.transform.childCount; i++)
        {
            CanvasHandler.arrowDragPanel.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
