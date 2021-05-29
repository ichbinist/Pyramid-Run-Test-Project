using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineController : MonoBehaviour
{
    private bool IsFinished;
    private void OnEnable()
    {
        if (!Managers.Instance) return;

    }

    private void OnDisable()
    {
        if (!Managers.Instance) return;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsFinished) return;
        MovingObjectController movingObjectController = other.GetComponent<MovingObjectController>();
        if (movingObjectController)
        {
            LevelManager.Instance.FinishLevel(true);
            IsFinished = true;
        }
    }
}
