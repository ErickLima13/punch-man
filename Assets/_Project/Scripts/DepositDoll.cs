using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositDoll : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PickUpDoll pickUp))
        {
            pickUp.RemoveDoll();
        }
    }


}
