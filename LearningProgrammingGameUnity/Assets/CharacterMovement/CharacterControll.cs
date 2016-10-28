using UnityEngine;
using System.Collections;

public class CharacterControll : MonoBehaviour {

    public float speed = 10.0f;
    public static bool canMove = true;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        if (canMove)
        {
            float translation = Input.GetAxis("Vertical") * speed;
            float straffe = Input.GetAxis("Horizontal") * speed;
            translation *= Time.deltaTime;
            straffe *= Time.deltaTime;
            transform.Translate(straffe, 0, translation);
        }
	}
}
