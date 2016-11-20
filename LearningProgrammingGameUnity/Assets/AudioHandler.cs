using UnityEngine;
using System.Collections;

public class AudioHandler : MonoBehaviour {

    public static AudioClip wakeUpClip;
    public static AudioClip test;
    public static AudioClip bob;
    public static AudioClip lookmodule5Editet;

    // Use this for initialization
    void Start () {
        test = Resources.Load<AudioClip>("Audio/stoppushing");
        wakeUpClip =  Resources.Load<AudioClip>("Audio/Wakeup");
        lookmodule5Editet = Resources.Load<AudioClip>("Audio/lookmodule5Editet");



    }

    // Update is called once per frame
    void Update () {
	}
}
