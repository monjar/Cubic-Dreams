using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class UIHandler : MonoBehaviour
{
    private AudioManager audioManager;
    public GameObject hintsPanel;
    public GameObject pauseMenu;
    public Animator hintsAnimator;
    private bool isHintsOpen = false;

    private void Start()
    {
        audioManager = AudioManager.GetInstance();
    }

    float deltaTime = 0.0f;
 
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }
 
    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;
 
        GUIStyle style = new GUIStyle();
 
        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = Color.white;
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
    public void hoverSound()
    {
        audioManager.Play("HoverInButtonSound");
    }

    public void clickSound()
    {
        audioManager.Play("ClickButtonSound");
    }

    public void quit()
    {
        Application.Quit();
    }

    public void ToggleHints()
    {
        if (isHintsOpen)
        {
            hintsAnimator.SetTrigger("Close");
            isHintsOpen = false;
        }
        else
        {
            hintsAnimator.SetTrigger("Open");
            isHintsOpen = true;   
        }

    }

    public void TogglePause()
    {
        if (Time.timeScale > 0.5f)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }
}