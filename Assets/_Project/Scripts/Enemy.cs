using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action OnHit;

    private ControlRagdoll controlRagdoll;

    private void Start()
    {
        controlRagdoll = GetComponentInChildren<ControlRagdoll>();

        OnHit += controlRagdoll.ActiveRagdoll;
    }

    public void Hit()
    {
        OnHit?.Invoke();
    }

    private void OnDestroy()
    {
        OnHit -= controlRagdoll.ActiveRagdoll;
    }
}
