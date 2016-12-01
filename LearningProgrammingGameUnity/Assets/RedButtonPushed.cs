using UnityEngine;
using System.Collections;
using System;

public class RedButtonPushed : MonoBehaviour
{
    static int playSoundIndex = 0;
    static GameObject[] Markers;
    static GameObject Robot;
    static GameObject Camera;
    static GameObject Explosion;
    static Animator RobotAnimator;
    static Transform RobotTransform;
    bool startedEndScene = false;
    public static bool[] parts;
    static bool[] wait;
    // Use this for initialization
    void Start()
    {
        Robot = GameObject.Find("RobotParent");
        RobotAnimator = Robot.transform.GetChild(0).GetComponent<Animator>();
        RobotTransform = Robot.transform;
        Robot.SetActive(false);
        parts = new bool[10];
        Markers = new GameObject[10];
        wait = new bool[10];
        for(int i = 0; i < wait.Length; i++)
        {
            wait[i] = true;
        }
        Markers[0] = GameObject.Find("EndMoveMarker1");
        Explosion = GameObject.Find("Explosion");
        Camera = GameObject.Find("EndSceneCameraAnchor");
        Explosion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("wait 1 =" + wait[1]);
        if (Input.GetKeyDown(KeyCode.E))
        {
            float distanceToObj = Vector3.Distance(CanvasHandler.Player.transform.position, gameObject.transform.position);
            if (distanceToObj < 3f)
            {

                //play push animation
                GameObject.Find("red_button").GetComponent<Animator>().SetTrigger("PushedButton");
                if (ManagerScript.IsAllHandedIn())
                {
                    //All assignment solved
                    //end Scene started
                    CanvasHandler.Player.transform.position = CharacterControll.StartPos;
                    startedEndScene = true;
                    CameraMousePanEnd.SetCameraToEndScene();
                    ManagerScript.CanMove = false;
                    PressEToInteract.Deactivate();
                    Robot.SetActive(true);
                    Robot.transform.position =
                        new Vector3(Robot.transform.GetChild(0).transform.GetChild(0).transform.position.x,
                        Robot.transform.position.y,
                        Robot.transform.GetChild(0).transform.GetChild(0).transform.position.z);
                    parts[0] = false;
                    if (wait[3])
                    {
                        if (CanvasHandler.Player.GetComponent<AudioSource>().isPlaying)
                        {
                            CanvasHandler.Player.GetComponent<AudioSource>().Stop();
                        }
                        CanvasHandler.Player.GetComponent<AudioSource>().PlayOneShot(AudioHandler.lookWindow);
                        wait[3] = !wait[3];
                        contiuneEndScene(5);
                    }

                }
                else
                {
                    //play stoppush sound
                    if (playSoundIndex < 10)
                    {
                        if (CanvasHandler.Player.GetComponent<AudioSource>().isPlaying)
                        {
                            CanvasHandler.Player.GetComponent<AudioSource>().Stop();
                        }
                        CanvasHandler.Player.GetComponent<AudioSource>().PlayOneShot(AudioHandler.stopPushing[playSoundIndex]);
                    }
                    playSoundIndex++;
                }
            }
        }
        if (startedEndScene)
        {
            //Debug.Log("end scene started");
            if (wait[1])
            {
                contiuneEndScene(1);
                wait[1] = !wait[1];
            }
            if (parts[0])
            {
                float degreesPerSec = 50;
                Robot.transform.Rotate(Vector3.up, Time.deltaTime * degreesPerSec, Space.World);
                if (Robot.transform.localRotation.y > 0.7)
                {
                    //Debug.Log("robot has been rotated");
                    parts[0] = false;
                    parts[1] = true;
                }
            }
            if (parts[1])
            {
                if (wait[0])
                {
                    RobotAnimator.SetTrigger("StartWalk");
                    //Debug.Log("start walk");
                    contiuneEndScene(0);
                    wait[0] = !wait[0];
                }
            }
            if (parts[2])
            {

                Robot.transform.position = Vector3.Lerp(
                      RobotTransform.position,
                      Markers[0].transform.position,
                      Time.deltaTime*0.5f);
                //Debug.Log("move robot");
            }
            if (parts[3])
            {
                RobotAnimator.SetTrigger("StopWalk");
                //Debug.Log("stop walk");
                parts[3] = false;
                //parts[4] = true;
            }
            if (parts[4])
            {
                Camera.transform.position = Vector3.Lerp(
                    Camera.transform.position,
                    Markers[0].transform.position,
                    Time.deltaTime * 0.5f);
                //Debug.Log("move camera");
                contiuneEndScene(2);
            }
            if (parts[5])
            {
                CameraMousePanEnd.SetCameraToNormal();
                GameObject.Find("Main Camera").GetComponent<Camera>().targetDisplay = 3;
                GameObject.Find("Camera").GetComponent<Camera>().targetDisplay = 0;
                contiuneEndScene(4);
                if (wait[4])
                {
                    CanvasHandler.Player.GetComponent<AudioSource>().PlayOneShot(AudioHandler.option3);
                    wait[4] = !wait[4];
                }
            }
        }
    }
    void contiuneEndScene(int i)
    {
        if(i == 0)
            StartCoroutine(Wait());
        if(i == 1)
            StartCoroutine(Wait2());
        if (i == 2)
            StartCoroutine(WaitExplosion());
        if(i == 3)
            StartCoroutine(WaitAfterExplosion());
        if(i == 4)
            StartCoroutine(WaitTwoSec());
        if (i == 5)
            StartCoroutine(WaitForSoundOne());

    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        parts[2] = true;
        parts[4] = true;
        parts[1] = false;
    }
    private IEnumerator WaitTwoSec()
    {
        yield return new WaitForSeconds(2f);
        CanvasHandler.ScreenOverlay.SetActive(true);
    }
    private IEnumerator Wait2()
    {
        yield return new WaitForSeconds(1f);
        parts[0] = true;
    }
    private IEnumerator WaitExplosion()
    {
        yield return new WaitForSeconds(9.5f);
        Explosion.SetActive(true);
        contiuneEndScene(3);
    }
    private IEnumerator WaitAfterExplosion()
    {
        yield return new WaitForSeconds(8.7f);
        parts[5] = true;
    }
    private IEnumerator WaitForSoundOne()
    {
        yield return new WaitForSeconds(AudioHandler.lookWindow.length);
        CanvasHandler.Player.GetComponent<AudioSource>().PlayOneShot(AudioHandler.explosion);

    }
}