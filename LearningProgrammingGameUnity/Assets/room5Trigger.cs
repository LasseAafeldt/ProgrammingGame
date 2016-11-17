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
            Debug.Log("TriggerList size = " + TriggerList.Count + " Added " + other);
            if (TriggerList.Count >= 3)
            {
                Debug.Log("door open!");
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (TriggerList.Contains(other))
        {
            TriggerList.Remove(other);
            Debug.Log("TriggerList size = " + TriggerList.Count + " removed " + other);
            if (TriggerList.Count < 3)
            {
                Debug.Log("door close");
            }
        }
    }
}
