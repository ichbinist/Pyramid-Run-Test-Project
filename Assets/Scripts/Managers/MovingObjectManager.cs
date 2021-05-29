using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Events;

public class MovingObjectManager : Singleton<MovingObjectManager>
{
    public GameObject GridPrefab;

    public UnityEvent OnObjectAdded = new UnityEvent();
    public UnityEvent OnObjectRemoved = new UnityEvent();

    [ShowInInspector]
    public List<MovingObject> MovingObjects = new List<MovingObject>();

    public float Speed = 1f;

    private void OnEnable()
    {
        OnObjectAdded.AddListener(AlignPiramid);
        OnObjectRemoved.AddListener(AlignPiramid);
    }

    private void OnDisable()
    {
        OnObjectAdded.RemoveListener(AlignPiramid);
        OnObjectRemoved.RemoveListener(AlignPiramid);

    }

    private void Update()
    {
        if (!Managers.Instance) return;
        if (!LevelManager.Instance.IsLevelStarted) return;
        foreach (MovingObject movingObject in MovingObjects)
        {
            movingObject.Move(Speed);
        }
        
    }

    public void AddObject(MovingObject MovingObject)
    {
        MovingObjects.Add(MovingObject);
        OnObjectAdded.Invoke();
    }

    public void RemoveObject(MovingObject MovingObject)
    {
        MovingObjects.Remove(MovingObject);
        OnObjectRemoved.Invoke();

        if(MovingObjects.Count == 0)
        {
            LevelManager.Instance.FinishLevel(false);
        }
    }

    public void AlignPiramid()
    {
        int i = 0;

        foreach (Transform child in GridPrefab.transform)
        {
            
            if(i >= MovingObjects.Count)
            {
                break;
            }

            (MovingObjects[i] as MovingObjectController).transform.position = new Vector3((MovingObjects[0] as MovingObjectController).transform.position.x + child.transform.position.x,child.transform.position.y, (MovingObjects[0] as MovingObjectController).transform.position.z);
            i++;
        }
        i = 0;
        foreach (Transform child in GridPrefab.transform)
        {

            if (i >= MovingObjects.Count)
            {
                break;
            }


            if (i != 0)
                (MovingObjects[i] as MovingObjectController).AlignStartingX(child.transform.position.x);

            i++;
        }
    }
}
