using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectController : MonoBehaviour, MovingObject
{
    public float SverweSpeed = 0.3f;

    public float StartingX = 3;

    private void OnEnable()
    {
      if(!Managers.Instance) return;
        MovingObjectManager.Instance.AddObject(this);
    }

    private void OnDisable()
    {
      if(!Managers.Instance) return;
        MovingObjectManager.Instance.RemoveObject(this);
    }

    private void Update()
    {
        if (!Managers.Instance) return;
        if (!LevelManager.Instance) return;

        Swerve();
    }

    public void Move(float Speed)
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    public void Swerve()
    {
        transform.position += Vector3.left * (Mathf.Clamp(InputManager.Instance.TappedPosition.x-InputManager.Instance.CurrentPosition.x,-3,3)) * SverweSpeed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, StartingX - 9, StartingX + 9), transform.position.y, transform.position.z);
    }

    public void AlignStartingX(float AlignRate)
    {
        StartingX = (MovingObjectManager.Instance.MovingObjects[0] as MovingObjectController).StartingX + AlignRate;
    }
}
