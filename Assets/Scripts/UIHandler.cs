﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    private AudioManager audioManager;
    public GameObject hintsPanel;
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
    

}
