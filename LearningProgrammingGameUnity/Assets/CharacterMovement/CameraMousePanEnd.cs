using UnityEngine;
using System.Collections;
using System;


public class CameraMousePanEnd : MonoBehaviour {
    public static Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 2.0f;
    public float smoothing = 2.0f;
    Camera EndScene;
    public static bool canMove = true;

	// Use this for initialization
	void Start () {
        EndScene = gameObject.transform.GetChild(0).GetComponent<Camera>();
        //ManagerScript.CanMove = false;
    }

    // Update is called once per frame
    void Update () {
        //SetCameraToEndScene();
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y,-15,10);
        mouseLook.x = Mathf.Clamp(mouseLook.x,-20,20);
        transform.localRotation = Quaternion.Euler(-mouseLook.y,mouseLook.x,0);
    }
    public void SetCameraToEndScene()
    {
        EndScene.targetDisplay = 0;
    }
    public void SetCameraToNormal()
    {
        EndScene.targetDisplay = 1;
    }
}
