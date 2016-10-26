using UnityEngine;
using System.Collections;

public class ShowAndHideDragAndDrop : MonoBehaviour {
    GameObject DragAndDropCanvas;
	// Use this for initialization
	void Start () {
        DragAndDropCanvas = GameObject.Find("DragAndDropCanvas");
        DragAndDropCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("e"))
        {
            DragAndDropCanvas.SetActive(true);
            RunQueue.InitializeQueue();
            Cursor.lockState = CursorLockMode.None;
            CharacterControll.canMove = false;
            CameraMousePan.canMove = false;
        }
        if (Input.GetKeyDown("q"))
        {
            DragAndDropCanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            CharacterControll.canMove = true;
            CameraMousePan.canMove = true;
        }
    }
}
