using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class LevelsManager : MonoBehaviour
{
    private static LevelsManager _instance;


    public string mapName;
    public GameObject levelsPrefab;
    public new CameraMovementPC camera;
    public List<GameObject> buttons;
    private int targetIndex;
    private int enemiesCount;


    public static LevelsManager GetInstance()
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

    private void Start()
    {
        buttons = new List<GameObject>();
        Initialize();
    }

    public void Initialize()
    {
        TextAsset[] maps = Resources.LoadAll("Maps").Cast<TextAsset>().ToArray();

        for (var index = 0; index < maps.Length; index++)
        {
            var levelpos = new Vector3(-4f + index * 1.2f, 0, 0);
            var button = Instantiate(levelsPrefab, levelpos, Quaternion.identity);
            button.name = "LevelButton";
            button.transform.GetChild(2).gameObject.GetComponent<TextMeshPro>().SetText(maps[index].name.Substring(4));
            button.GetComponent<MenuItem>().mapName = maps[index].name;
            button.transform.GetChild(1).gameObject.GetComponent<TextMeshPro>().SetText((index + 1) + "");
            buttons.Add(button);
            if (index == 0)
            {
                camera.target = button.transform;
                targetIndex = 0;
            }
        }
        var pos = new Vector3(-4f + maps.Length * 1.2f, 0, 0);
        var soon = Instantiate(levelsPrefab, pos, Quaternion.identity);
        soon.transform.GetChild(2).gameObject.GetComponent<TextMeshPro>().SetText("Coming soon...");
        soon.transform.GetChild(1).gameObject.GetComponent<TextMeshPro>().SetText((maps.Length + 1)+"");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            NextLevel();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            PrevLevel();
        }
    }

    public void NextLevel()
    {
        targetIndex = ((targetIndex + 1) % buttons.Count);
        camera.target = buttons[targetIndex].transform;
    }

    public void PrevLevel()
    {
        targetIndex = targetIndex == 0 ? buttons.Count - 1 : targetIndex - 1;
        camera.target = buttons[targetIndex].transform;
    }
}