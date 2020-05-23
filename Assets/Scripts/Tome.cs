using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tome : MonoBehaviour
{
    private string hint;

    private bool isSeen = false;

    private void Start()
    {
        this.hint = "well this is a hint...";
    }
    // Start is called before the first frame update
    
    public string GetHint()
    {
        isSeen = true;
        return hint;
    }

    public void SetHint(string newHint)
    {
        hint = newHint;
    }

    public bool IsSeen()
    {
        return isSeen;
    }
}
