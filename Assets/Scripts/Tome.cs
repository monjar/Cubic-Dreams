using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tome : MonoBehaviour
{
    private string hint;
    private new ParticleSystem particleSystem;
    private new Light light;
    private bool isSeen = false;
    private void Start()
    {
        transform.GetChild(1).TryGetComponent(out particleSystem);
        transform.GetChild(3).TryGetComponent(out light);
    }
    // Start is called before the first frame update
    private void Update()
    {
        if (isSeen && light.intensity > 0)
        {
            light.intensity -= 0.1f;
        }
    }

    public string GetHint()
    {
        isSeen = true;
        return hint;
    }

    public void SetHint(string newHint)
    {
        hint = "\"" + newHint + "\"";
    }

    public void TurnOffEffect()
    {
        particleSystem.Stop();
    }

    public bool IsSeen()
    {
        return isSeen;
    }
}
