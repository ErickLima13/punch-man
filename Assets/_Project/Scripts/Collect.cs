using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private ControlRagdoll controlRagdoll;

    private void Start()
    {
        controlRagdoll = GetComponentInParent<ControlRagdoll>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PickUpDoll pickUpDoll))
        {
            pickUpDoll.AddDoll(controlRagdoll.mainTransform);
            Destroy(gameObject, 0.3f);
        }
    }
}
