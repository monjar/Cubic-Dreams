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
    private void Start()
    {
        audioManager = AudioManager.GetInstance();
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
        hintsPanel.SetActive(!hintsPanel.activeInHierarchy);
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