using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightHandler : MonoBehaviour
{
    public Light light;
    private Material material;
    private bool isTurnedOn;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out Renderer renderer);
        material = renderer.material;
        this.isTurnedOn = false;
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            this.light.intensity = 3f;
        }
        else
        {
            this.light.intensity = 3f;
            
        }
        this.light.bounceIntensity = 2;
    }
    

    public void Activate()
    {
        this.isTurnedOn = true;
        float intensity = 3.0f;
        material.EnableKeyword ("_EMISSION");
        Color color = material.GetColor("_EmissionColor");
        material.SetColor("_EmissionColor", color * intensity);
        this.light.intensity = 25f;
    }
    
    public void DeActivate()
    {
        this.isTurnedOn = false;
        float intensity = 3.0f;
        material.EnableKeyword ("_EMISSION");
        Color color = material.GetColor("_EmissionColor");
        material.SetColor("_EmissionColor", color / intensity);
        this.light.intensity = 6f;
    }

    public bool IsActive()
    {
        return this.isTurnedOn;
    }
}
