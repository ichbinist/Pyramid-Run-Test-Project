using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Vector2 TappedPosition;
    public Vector2 CurrentPosition;

    private void OnEnable()
    {
      if(!Managers.Instance) return;

    }

    private void OnDisable()
    {
      if(!Managers.Instance) return;

    }

    private void FixedUpdate()
    {
        if (!Managers.Instance) return;
        if (!LevelManager.Instance) return;
        if (Input.GetMouseButtonDown(0))
        {
            TappedPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            CurrentPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            TappedPosition = Vector2.zero;
            CurrentPosition = Vector2.zero;
        }
    }
}
