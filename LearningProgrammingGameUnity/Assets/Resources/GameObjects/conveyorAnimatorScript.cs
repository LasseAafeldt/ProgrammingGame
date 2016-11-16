using UnityEngine;
using System.Collections;

public class conveyorAnimatorScript : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (true)
			animator.SetTrigger ("on");
		
	
	}
}
/*if (false)
			animator.SetTrigger ("off");
*/