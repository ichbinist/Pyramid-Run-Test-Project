using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjectController : MonoBehaviour
{
    private bool isCollected = false;
    private void OnTriggerEnter(Collider other)
    {
        if (isCollected) return;
        MovingObjectController movingObjectController = other.GetComponent<MovingObjectController>();
        if (movingObjectController)
        {
            isCollected = true;
            transform.rotation = Quaternion.identity;
            gameObject.AddComponent<MovingObjectController>();
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            
            Destroy(this);
        }
    }
}
