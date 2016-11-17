using UnityEngine;
using System.Collections;

public class room5Trigger : MonoBehaviour {

    ArrayList TriggerList = new ArrayList();
	void Start() { }
	
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerStay(Collider other)
    {
        if (!TriggerList.Contains(other) && 
            other.CompareTag("room5") && 
            other.GetComponent<Rigidbody>().isKinematic == false)
        {
            TriggerList.Add(other);
            //Debug.Log("TriggerList size = " + TriggerList.Count + " Added " + other);
            if (TriggerList.Count >= 3)
            {
                GameObject.Find("DoorAnimationFixerStorage1").GetComponent<DoorAnimation>().ChangeState();
                GameObject.Find("DoorAnimationFixerStorage2").GetComponent<DoorAnimationRevers>().ChangeState();
                //Debug.Log("door open!");
                //Add sound here
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (TriggerList.Contains(other))
        {
            TriggerList.Remove(other);
            //Debug.Log("TriggerList size = " + TriggerList.Count + " removed " + other);
            if (TriggerList.Count < 3)
            {
                GameObject.Find("DoorAnimationFixerStorage1").GetComponent<DoorAnimation>().Close();
                GameObject.Find("DoorAnimationFixerStorage2").GetComponent<DoorAnimationRevers>().Close();
                //Debug.Log("door close");
                //Add sound here
            }
        }
    }
}
