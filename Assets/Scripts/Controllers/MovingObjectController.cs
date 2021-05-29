using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectController : MonoBehaviour, MovingObject
{
    private void OnEnable()
    {
      if(!Managers.Instance) return;
        MovingObjectManager.Instance.MovingObjects.Add(this);
    }

    private void OnDisable()
    {
      if(!Managers.Instance) return;
        MovingObjectManager.Instance.MovingObjects.Remove(this);
    }

    public void Move(float Speed)
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }
}
