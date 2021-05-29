using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class LevelManager : Singleton<LevelManager>
{
    public int CurrentLevelIndex;

    public bool IsLevelStarted;
    public UnityEvent OnLevelStarted = new UnityEvent();
    public UnityEvent OnLevelFinished = new UnityEvent();

    public UnityEvent OnSceneSuccess = new UnityEvent();
    public UnityEvent OnSceneFail = new UnityEvent();

    public void StartLevel()
    {
        IsLevelStarted = true;
        OnLevelStarted.Invoke();
    }
    public void FinishLevel(bool GameState)
    {
        IsLevelStarted = false;
        OnLevelFinished.Invoke();

        if (GameState)
        {
            OnSceneSuccess.Invoke();
            SceneController.Instance.UnloadLevel(CurrentLevelIndex);

            CurrentLevelIndex++;
            if(SceneManager.sceneCount <= CurrentLevelIndex)
            {
                CurrentLevelIndex = 2;
            }

            SceneController.Instance.LoadLevel(CurrentLevelIndex);

        }
        else
        {
            OnSceneFail.Invoke();
            SceneController.Instance.UnloadLevel(CurrentLevelIndex);
            SceneController.Instance.LoadLevel(CurrentLevelIndex);
        }
    }
}