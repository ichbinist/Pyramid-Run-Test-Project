using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    public UnityEvent OnSceneLoaded = new UnityEvent();
    public void LoadLevel(int Index)
    {
        StartCoroutine(LoadLevelCo(Index));
    }

    public IEnumerator LoadLevelCo(int Index)
    {
        yield return SceneManager.LoadSceneAsync(Index, LoadSceneMode.Additive);
        OnSceneLoaded.Invoke();
    }

    public void UnloadLevel(int Index)
    {
        StartCoroutine(UnloadLevelCo(Index));
    }

    public IEnumerator UnloadLevelCo(int Index)
    {
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(Index));
    }

    public void Start()
    {
        LoadLevel(1);
        LoadLevel(2);
        LevelManager.Instance.CurrentLevelIndex = 2;
    }
}