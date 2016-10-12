using UnityEngine;
using System.Collections;
    
public class QueueTest : MonoBehaviour{
    // Use this for initialization
    void Start()
    {
        new ForLoop(2).AddToQueue(0);
        new Addition(2, 3).AddToQueue(1);
        new Subtraction(2, 3).AddToQueue(2);
        new IfElseStatement(1,">",2).AddToQueue(3);
        new Division(2, 3).AddToQueue(4);
        new Multiplication(2, 3).AddToQueue(5);
        RunQueue.run();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void test()
    {
        new ForLoop(2).AddToQueue(0);
        new Addition(2, 3).AddToQueue(1);
        new Subtraction(2, 3).AddToQueue(2);
        new IfElseStatement(1, ">", 2).AddToQueue(3);
        new Division(2, 3).AddToQueue(4);
        new Multiplication(2, 3).AddToQueue(5);
        RunQueue.run();
    }
}
