using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuItem : MonoBehaviour
{
    public TextMeshPro textObject;

    private Material mat;
    public SceneChanger sceneChanger;
    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        if (name != "ExitButton")
        {
            textObject = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        }
    }

    private void OnMouseEnter()
    {
        AudioManager.GetInstance().Play("HoverInButtonSound");
        mat.EnableKeyword("_EMISSION");
        mat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
        mat.SetColor("_EmissionColor", new Color(154,0,0));
    }


    private void OnMouseExit()
    {
        mat.DisableKeyword("_EMISSION");
    }

    private void OnMouseDown()
    {
        AudioManager.GetInstance().Play("ClickButtonSound");
        if (name == "PlayButton")
        {
            sceneChanger.FadeToScene("GameScene");
        }
        else if (name == "CameraButton")
        {
            print("PIGPIUG");
            Settings.isPresoective = !Settings.isPresoective;
            if (Settings.isPresoective)
            {
                textObject.SetText("Perspective");
            }
            else
            {
                textObject.SetText("Orthographic");
            }
        }
        else if (name == "ExitButton")
        {
            Application.Quit();
        } 
    }
}