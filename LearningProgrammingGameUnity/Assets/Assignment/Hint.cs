using UnityEngine;
using System.Collections;
using System;
public class Hint {
    int currentHint; 
    private ArrayList hints;
    public Hint(String hint1)
    {
        hints = new ArrayList();
        currentHint = 0;
        hints.Add("HINT: " + hint1);
    }
    public Hint(String hint1, String hint2)
    {
        hints = new ArrayList();
        currentHint = 0;
        hints.Add("HINT: " + hint1);
        hints.Add("HINT: " + hint2);
    }
    public Hint(String hint1, String hint2, String hint3)
    {
        hints = new ArrayList();
        currentHint = 0;
        hints.Add("HINT: " + hint1);
        hints.Add("HINT: " + hint2);
        hints.Add("HINT: " + hint3);
    }
    public Hint(String hint1, String hint2, String hint3, String hint4)
    {
        hints = new ArrayList();
        currentHint = 0;
        hints.Add("HINT: " + hint1);
        hints.Add("HINT: " + hint2);
        hints.Add("HINT: " + hint3);
        hints.Add("HINT: " + hint4);
    }
    public void AddHint(String hint)
    {
        hints.Add("HINT: " + hint);
    }
    public String GetHintAt(int i)
    {
        if (hints.Count > i)
            return (String)hints[i];
        else
            return null;
    }
    public String GetNextHint()
    {
        currentHint++;
        if (hints.Count > currentHint - 1)
            return (String)hints[currentHint - 1];
        else
        {
            currentHint = 0;
            return (String)hints[currentHint];
        }
    }
}
