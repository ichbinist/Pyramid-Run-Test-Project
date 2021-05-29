using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class StartLevelPanel : MonoBehaviour
{
    public GameObject TextObject;

    private void Start()
    {
        TextObject.transform.DOScale(1.5f, 0.75f).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnEnable()
    {
      if(!Managers.Instance) return;
        LevelManager.Instance.OnLevelStarted.AddListener(() => TextObject.SetActive(false));
        SceneController.Instance.OnSceneLoaded.AddListener(() => TextObject.SetActive(true));
    }

    private void OnDisable()
    {
      if(!Managers.Instance) return;
        LevelManager.Instance.OnLevelStarted.RemoveListener(() => TextObject.SetActive(false));
        SceneController.Instance.OnSceneLoaded.RemoveListener(() => TextObject.SetActive(true));
    }

    private void Update()
    {
      if(!Managers.Instance) return;
        if (!LevelManager.Instance.IsLevelStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                LevelManager.Instance.StartLevel();
            }
        }
    }
}
