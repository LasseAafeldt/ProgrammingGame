using UnityEngine;
using System.Collections;

public class RedButtonPushed : MonoBehaviour {
    static int playSoundIndex = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float distanceToObj = Vector3.Distance(CanvasHandler.Player.transform.position, gameObject.transform.position);
            if(distanceToObj < 3f)
            {
                //play push animation
                GameObject.Find("red_button").GetComponent<Animator>().SetTrigger("PushedButton");
                if (ManagerScript.IsAllHandedIn())
                {
                    //All assignment solved
                    //play end Scene
                    //NYI

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
	}
}
