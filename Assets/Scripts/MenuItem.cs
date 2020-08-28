using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuItem : MonoBehaviour
{
    public TextMeshPro textObject;

    private Material mat;
    public SceneChanger sceneChanger;
    public MainMenu mainMenu;
    public Camera camera;
    public string mapName;

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
        if (!IsPointerOverUIObject())
        {
            AudioManager.GetInstance().Play("HoverInButtonSound");
            mat.EnableKeyword("_EMISSION");
            mat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
            mat.SetColor("_EmissionColor", new Color(154, 0, 0));
        }
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    private void OnMouseExit()
    {
        mat.DisableKeyword("_EMISSION");
    }

    private void OnMouseDown()
    {
        if (!IsPointerOverUIObject())
        {
            AudioManager.GetInstance().Play("ClickButtonSound");
            if (name == "PlayButton")
            {
                sceneChanger.FadeToScene("LevelsScene");
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
            else if (name == "Gamopedia")
            {
                mainMenu.TogglePedia();
            }else if (name == "HowToButton")
            {
                mainMenu.ToggleHow();
            }else if (name == "AboutMeButton")
            {
                mainMenu.ToggleAbout();
            }else if (name == "LevelButton")
            {
                Settings.mapName = mapName;
                GameObject.FindWithTag("SceneTransition").TryGetComponent(out sceneChanger);
                sceneChanger.FadeToScene("GameScene");
            }
        }
    }
}