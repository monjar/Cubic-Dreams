using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var audioManager = AudioManager.GetInstance();
        audioManager.Stop("Ambient");
        audioManager.Play("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
