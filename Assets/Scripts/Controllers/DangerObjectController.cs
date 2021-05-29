using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerObjectController : MonoBehaviour
{
    private bool IsDestroyed;
    private int i;
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
        if (IsDestroyed) return;
        MovingObjectController movingObjectController = other.GetComponent<MovingObjectController>();
        if (movingObjectController)
        {
            Destroy(other.gameObject);
            i++;
            if(i >= 2)
            {
                IsDestroyed = true;
            }
        }
    }
}