using UnityEngine;
using System.Collections;

public class ShowAndHideDragAndDrop : MonoBehaviour {
    public static int WhichAccessPanel;
    GameObject DragAndDropCanvas;
	// Use this for initialization
	void Start () {
        DragAndDropCanvas = GameObject.Find("DragAndDropCanvas");
        DragAndDropCanvas.SetActive(false);
        WhichAccessPanel = -1;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("e") && IsInRange())
        {
            DragAndDropCanvas.SetActive(true);
            RunQueue.InitializeQueue();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            CharacterControll.canMove = false;
            CameraMousePan.canMove = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            DragAndDropCanvas.SetActive(false);
            CharacterControll.canMove = true;
            CameraMousePan.canMove = true;
        }
    }

    private bool IsInRange()
    {
        room1_AccessPanelAssignement roomOne = new room1_AccessPanelAssignement();
        //room2_AdditionAssignment roomTwo = new room2_AdditionAssignment();
        GameObject console = GameObject.Find("AccessPanelRoom1");
        GameObject player = GameObject.Find("Player");
        float distanceToConsole = Vector3.Distance(player.transform.position, console.transform.position);
        //Debug.Log("distance = " + distanceToConsole);
        if (distanceToConsole < 1.2f)
        {
            roomOne.load();
            WhichAccessPanel = 1;
            return true;
        }
        
        console = GameObject.Find("AccessPanelRoom2");
        distanceToConsole = Vector3.Distance(player.transform.position, console.transform.position);
        //Debug.Log("distance = " + distanceToConsole);
        if (distanceToConsole < 1.2f)
        {
            WhichAccessPanel = 2;
            return true;
        }
        WhichAccessPanel = -1;
        return false;
    }
}
