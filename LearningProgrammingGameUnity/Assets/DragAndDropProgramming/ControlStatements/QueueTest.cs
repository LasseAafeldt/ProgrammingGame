using UnityEngine;
using System.Collections;
    
public class QueueTest : MonoBehaviour{
    // Use this for initialization
    void Start()
    {
        new ForLoop(2).AddToQueue();
        new Addition(2, 3).AddToQueue();
        new Subtraction(2, 3).AddToQueue();
        new IfElseStatement(1,">",2).AddToQueue();
        new Division(2, 3).AddToQueue();
        new Multiplication(2, 3).AddToQueue();
        RunQueue.run();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
