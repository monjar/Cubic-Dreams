using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightHandler : MonoBehaviour
{
    public Light light;

    private bool isTurnedOn;
    // Start is called before the first frame update
    void Start()
    {
        this.isTurnedOn = false;
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            this.light.intensity = 10f;
        }
        else
        {
            this.light.intensity = 6f;
            
        }
        this.light.bounceIntensity = 2;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void activate()
    {
        this.isTurnedOn = true;
        this.light.intensity = 24f;
    }
    
    public void deActivate()
    {
        this.isTurnedOn = false;
        this.light.intensity = 6f;
    }

    public bool isActive()
    {
        return this.isTurnedOn;
    }
}
