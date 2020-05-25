using System;
using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private List<string> colorsOrder;
    public Animator gameOverAnimator;
    public Animator wonAnimator;
    public GameObject endGameParticles;
    public CameraMovementPC cameraHandler;
    public AudioManager audioManager;
    public SceneChanger sceneChanger;
    private bool isGameDone;
    public static GameManager GetInstance()
    {
        return _instance;
    }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    private void OnDestroy()
    {
        if (this == _instance)
            _instance = null;
    }

    private void Start()
    {
        isGameDone = false;
        audioManager = AudioManager.GetInstance();
        audioManager.Stop("MainMenu");
        audioManager.Play("Ambient");
        this.colorsOrder = new List<string>( /*new [] {"green", "white", "green", "blue", "orange", "purple", "red"}*/);
        //TODO Get orders from File
    }

    public bool IsOrdered(List<GameObject> playerBoxes)
    {
        if (playerBoxes.Count != this.colorsOrder.Count)
            return false;
        return !FoundMisplaced(playerBoxes);
    }

    private bool FoundMisplaced(List<GameObject> playerBoxes)
    {
        for (var index = 0; index < playerBoxes.Count; index++)
            if (IsBoxOutOfOrder(playerBoxes, index))
                return true;
        return false;
    }

    public void WinGame()
    {
        isGameDone = true;
        cameraHandler.ResetZoom();
        var particles = endGameParticles.GetComponentsInChildren<ParticleSystem>();
        foreach (var particle in particles)
            particle.Play();

        GameObject.FindGameObjectWithTag("Portal").transform.GetChild(3).TryGetComponent(out ParticleSystem ray);
        ray.Play();
        wonAnimator.SetTrigger("Show");
        // wonImage.SetActive(true);
    }

    public void GameOver()
    {
        isGameDone = true;
        gameOverAnimator.SetTrigger("Show");
    }

    public void GoBackToMainMenu()
    {
        
        Time.timeScale = 1;
        
        sceneChanger.FadeToScene("MainMenu");
    }

    public void PlayAgain()
    {
        
        Time.timeScale = 1;
        var scene = SceneManager.GetActiveScene();
        sceneChanger.FadeToScene(scene.name);
    }

    private bool IsBoxOutOfOrder(List<GameObject> playerBoxes, int index)
    {
        return !playerBoxes[index].tag.ToLower().Equals(this.colorsOrder[index].ToLower());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool IsGameDone()
    {
        return isGameDone;
    }
}