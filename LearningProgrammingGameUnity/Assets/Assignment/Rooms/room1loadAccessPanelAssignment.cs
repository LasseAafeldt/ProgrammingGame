using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class room1loadAccessPanelAssignment : MonoBehaviour{
    protected GameObject obj;
    private GameObject player;
    private GameObject console;
    protected int activeChildCount;
    private static int ID = 1;
    // Use this for initialization
    void Start()
    {
        ID = 1;
        activeChildCount = 0;
        obj = gameObject;
        console = obj;
        player = GameObject.Find("Player");
    }
    void Update()
    {
        float distanceToConsole = Vector3.Distance(player.transform.position, console.transform.position);
        if (Input.GetKeyDown("e") && distanceToConsole < 1.2f && CanvasHandler.DragAndDropCanvas.activeInHierarchy != true)
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
        Debug.Log("Room 1 load");
        activeChildCount = 0;
        obj = CanvasHandler.DragPanel;
        //Debug.Log(obj);
        for (int i = 0; i < obj.transform.childCount; i++){
			if(i != GameObject.Find("DragSlot9").transform.GetSiblingIndex())
				obj.transform.GetChild(i).gameObject.SetActive(false);
			else
				activeChildCount ++;
		}
		//Debug.Log (new room1_AccessPanelAssignement ().GetDescription ());
		CanvasHandler.HeaderText.GetComponent<Text> ().text = new room1AccessPanelAssignement ().GetDescription ();
		CanvasHandler.scaleDragPanel (activeChildCount);
        GameObject objDrop = CanvasHandler.DropPanel;
        for (int i = 4; i < objDrop.transform.childCount; i++)
        {
            objDrop.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
