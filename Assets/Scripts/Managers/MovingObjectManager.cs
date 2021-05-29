using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class MovingObjectManager : Singleton<MovingObjectManager>
{
    [ShowInInspector]
    public List<MovingObject> MovingObjects = new List<MovingObject>();
}
