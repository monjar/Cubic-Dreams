
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator animator;
    // Update is called once per frame
    public string nextScene;
    void Update()
    {
        
    }

    public void FadeToScene(string sceneName)
    {
        animator.SetTrigger("FadeOut");
        nextScene = sceneName;
    }

    public void OnFadeFinish()
    {
        SceneManager.LoadScene(nextScene);
    }
}
