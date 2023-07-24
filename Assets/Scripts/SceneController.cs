using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController _instance;
    
    [Header("Modify if the scene needs to change automatically")]
    public bool hasToChange;
    public float timeToChange;
    public string sceneName;
    public static SceneController Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("SceneChanger is null");
            }
            return _instance;
        }
    }

    public void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        if (hasToChange)
        {
            ChangeBySeconds();
        }        
    }

    public void ChangeBySeconds()
    {
        StartCoroutine(CoroutineChangeSceneByTime(sceneName,timeToChange));
    }

    private IEnumerator CoroutineChangeSceneByTime(string sceneName, float timer = 0f) 
    {
        yield return new WaitForSeconds(timer);
        ChangeScene(sceneName);
    }

    public void ChangeScene(string nameScene) 
    {
        SceneManager.LoadScene(nameScene);
    }
    
    public void ChangeSceneByTime(string sceneName, float timer = 0f)
    {
        StartCoroutine(CoroutineChangeSceneByTime(sceneName, timer));
    }
    
    public void ChangeSceneAsync(string nameScene)
    {
        StartCoroutine(LoadSceneAsync(nameScene));
    }

    private IEnumerator LoadSceneAsync(string nameScene)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nameScene);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
    
}
