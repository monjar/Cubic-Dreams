using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using UnityEngine.AI;
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
    public NavMeshSurface playerNavmesh;
    public NavMeshSurface enemyNavmesh;
    public MapInitializer mapInitializer;
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


        mapInitializer.Initialize();
    }

    private void OnDestroy()
    {
        if (this == _instance)
            _instance = null;
    }

    public void BakeNavmeshes()
    {
        playerNavmesh.BuildNavMesh();
        enemyNavmesh.BuildNavMesh();
    }

    private void Start()
    {
        
        // Screen.SetResolution(1920, (Screen.width * 1920)/Screen.height , true);
        isGameDone = false;
        audioManager = AudioManager.GetInstance();
        audioManager.Stop("MainMenu");
        audioManager.Play("Ambient");
    }

    public bool IsOrdered(List<GameObject> playerBoxes)
    {
        if (playerBoxes.Count != this.colorsOrder.Count)
            return false;
        return !FoundMisplaced(playerBoxes);
    }

    public void SetOrder(string[] ordersArray)
    {
        colorsOrder = new List<string>(ordersArray);
        print(colorsOrder);
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
        audioManager.Play("Fireworks");
        audioManager.Play("WinSound");
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