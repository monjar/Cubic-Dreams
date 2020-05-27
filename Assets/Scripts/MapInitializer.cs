using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class MapInitializer : MonoBehaviour
{
    private static MapInitializer _instance;


    public string mapName;
    public GameObject wallPrefab;

    public GameObject[] boxPrefabs;
    public GameObject stairsPrefab;
    public GameObject tomePrefab;
    public GameObject portalPrefab;
    public GameObject player;
    public GameManager gameManager;
    public GameObject enemyPrefab;
    private int enemiesCount;
    public static MapInitializer GetInstance()
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
    }
    
    public void Initialize()
    {
        
        enemiesCount = 0;
        player = GameObject.FindWithTag("Player");
        // string selectedMap = null;
        // foreach (var map in maps)
        // {
        //     if (map.name == mapName)
        //     {
        //         selectedMap = map.text;
        //     }
        //
        //     
        // }
        TextAsset selectedMap = Resources.Load("Maps/" + mapName) as TextAsset;
        StringReader reader = new StringReader(selectedMap.text);
        string line;
        string[] separatingStrings = {",", " ", "(", ")", ":"};
        while ((line = reader.ReadLine()) != null)
        {
            var arguments = line.Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries);
            switch (arguments[0].ToLower())
            {
                case "wall":
                    var wallPos = new Vector3(float.Parse(arguments[1]), float.Parse(arguments[3]) + 1,
                        float.Parse(arguments[2]));
                    GameObject wall = Instantiate(wallPrefab, wallPos, Quaternion.identity);
                    wall.name = "wall";
                    break;
                case "stairs":
                    var stairsPos = new Vector3(float.Parse(arguments[1]), float.Parse(arguments[3]) + 1,
                        float.Parse(arguments[2]));
                    Quaternion stairsRotation;
                    if (arguments[4].ToLower() == "up")
                    {
                        stairsRotation = Quaternion.Euler(0, 180, 0);
                    }
                    else if (arguments[4].ToLower() == "down")
                    {
                        stairsRotation = Quaternion.Euler(0, 0, 0);
                    }
                    else if (arguments[4].ToLower() == "right")
                    {
                        stairsRotation = Quaternion.Euler(0, -90, 0);
                    }
                    else
                    {
                        stairsRotation = Quaternion.Euler(0, 90, 0);
                    }

                    GameObject stairs = Instantiate(stairsPrefab, stairsPos, stairsRotation);
                    stairs.name = "stairs";

                    break;
                case "light":
                    GameObject selectedPrefab = null;
                    foreach (var b in boxPrefabs)
                    {
                        if (b.name.ToLower() == arguments[4].ToLower())
                        {
                            selectedPrefab = b;
                            break;
                        }
                    }

                    var boxPos = new Vector3(float.Parse(arguments[1]), float.Parse(arguments[3]) + 1,
                        float.Parse(arguments[2]));
                    GameObject box = Instantiate(selectedPrefab, boxPos, Quaternion.identity);
                    box.name = arguments[4].ToLower();
                    if (!selectedPrefab) throw new Exception();


                    break;
                case "tome":
                    var tomePos = new Vector3(float.Parse(arguments[1]), float.Parse(arguments[3]) + 1,
                        float.Parse(arguments[2]));
                    Quaternion tomeRotation;
                    if (arguments[4].ToLower() == "down")
                    {
                        tomeRotation = Quaternion.Euler(0, 180, 0);
                        tomePos += new Vector3(0, 0, 0.25f);
                    }
                    else if (arguments[4].ToLower() == "up")
                    {
                        tomeRotation = Quaternion.Euler(0, 0, 0);
                        tomePos += new Vector3(0, 0, -0.25f);
                    }
                    else if (arguments[4].ToLower() == "left")
                    {
                        tomeRotation = Quaternion.Euler(0, -90, 0);
                        tomePos += new Vector3(0.25f, 0, 0);
                    }
                    else
                    {
                        tomeRotation = Quaternion.Euler(0, 90, 0);
                        tomePos += new Vector3(-0.25f, 0, 0);
                    }

                    var tomeObj = Instantiate(tomePrefab, tomePos, tomeRotation);
                    tomeObj.TryGetComponent(out Tome tome);
                    tome.SetHint(GetHintFromLine(line));
                    tomeObj.name = "tome";
                    break;
                case "portal":
                    var portalPos = new Vector3(float.Parse(arguments[1]), float.Parse(arguments[3]) + 1,
                        float.Parse(arguments[2]));
                    Quaternion portalRotation;
                    if (arguments[4].ToLower() == "up")
                    {
                        portalRotation = Quaternion.Euler(0, 180, 0);
                        portalPos += new Vector3(0, 0, -0.5f);
                    }
                    else if (arguments[4].ToLower() == "down")
                    {
                        portalRotation = Quaternion.Euler(0, 0, 0);
                        portalPos += new Vector3(0, 0, 0.5f);
                    }
                    else if (arguments[4].ToLower() == "right")
                    {
                        portalRotation = Quaternion.Euler(0, -90, 0);
                        portalPos += new Vector3(-0.5f, 0, 0);
                    }
                    else
                    {
                        portalRotation = Quaternion.Euler(0, 90, 0);
                        portalPos += new Vector3(0.5f, 0, 0);
                    }

                    var portalObj = Instantiate(portalPrefab, portalPos, portalRotation);

                    portalObj.name = "portal";
                    break;
                case "order":
                    gameManager.SetOrder(arguments.Skip(1).Take(arguments.Length - 1).ToArray());
                    break;
                case "player":
                    print(player.transform.position);
                    player.transform.position = new Vector3(float.Parse(arguments[1]), float.Parse(arguments[3]) + 0.5f,
                        float.Parse(arguments[2]));
                    
                    print(player.transform.position);
                    break;
                case "enemy":
                    var enemyPos = new Vector3(float.Parse(arguments[1]), float.Parse(arguments[3]) + 0.45f,
                        float.Parse(arguments[2]));
                    
                    Quaternion enemyRotation;
                    if (arguments[4].ToLower() == "down")
                    {
                        enemyRotation = Quaternion.Euler(0, 180, 0);
                    }
                    else if (arguments[4].ToLower() == "up")
                    {
                        enemyRotation = Quaternion.Euler(0, 0, 0);
                    }
                    else if (arguments[4].ToLower() == "left")
                    {
                        enemyRotation = Quaternion.Euler(0, -90, 0);
                    }
                    else
                    {
                        enemyRotation = Quaternion.Euler(0, 90, 0);
                    }

                    GameObject enemy = Instantiate(enemyPrefab, enemyPos, enemyRotation);
                    enemy.name = "enemy "+ (++enemiesCount);

                    break;
                default:
                    print("Wrong");
                    break;
            }
        }
        gameManager.bakeNavmeshes();
        reader.Close();
    }

    private static string GetHintFromLine(string line)
    {
        return line.Split(new[] {'\"'}, StringSplitOptions.RemoveEmptyEntries)[1];
    }

    // Update is called once per frame
    void Update()
    {
    }
}