using UnityEngine;
using System.Collections;
using System;


public class CameraMousePanEnd : MonoBehaviour {
    public static Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 2.0f;
    public float smoothing = 2.0f;
    GameObject character;
    Camera EndScene;
    public static bool canMove = true;

	// Use this for initialization
	void Start () {
        character = this.transform.parent.gameObject;
        EndScene = gameObject.transform.GetChild(0).GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        EndScene.targetDisplay = 1;
        Display.displays[1].Activate();
        
        if (canMove)
        {
            var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
            smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
            smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
            mouseLook += smoothV;
            mouseLook.y = Mathf.Clamp(mouseLook.y,-60,70);
            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        }
    }
}
