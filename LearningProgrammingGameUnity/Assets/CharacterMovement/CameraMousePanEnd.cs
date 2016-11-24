using UnityEngine;
using System.Collections;
using System;


public class CameraMousePanEnd : MonoBehaviour {
    public static Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 2.0f;
    public float smoothing = 2.0f;
    static Camera EndScene;
    public static bool canMove = true;
    public float maxDistLowerY = -10;
    public float maxDistUpperY = 0;
    public float maxDistLowerX = -30;
    public float maxDistUpperX = -10;

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
        mouseLook.y = Mathf.Clamp(mouseLook.y, maxDistLowerY, maxDistUpperY);
        mouseLook.x = Mathf.Clamp(mouseLook.x, maxDistLowerX, maxDistUpperX);
        transform.localRotation = Quaternion.Euler(-mouseLook.y,mouseLook.x,0);
    }
    public static void SetCameraToEndScene()
    {
        EndScene.targetDisplay = 0;
    }
    public static void SetCameraToNormal()
    {
        EndScene.targetDisplay = 1;
    }
}
