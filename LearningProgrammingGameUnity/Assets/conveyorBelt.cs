using UnityEngine;
using System.Collections;

public class conveyorBelt : MonoBehaviour
{

    float speed = 15f;
    bool on = true;
    Vector2 offset = new Vector2(0f, 0f);




    void OnCollisionStay(Collision obj)
    {
        float beltVelocity = speed * Time.deltaTime * 10;
        obj.gameObject.GetComponent<Rigidbody>().velocity = beltVelocity * transform.forward;
    }

    void Update()
    {
        offset += new Vector2(0, 0.1f) * Time.deltaTime;
        //GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
    }
}
