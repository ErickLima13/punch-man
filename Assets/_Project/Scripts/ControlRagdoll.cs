using System.Collections;
using UnityEngine;

public class ControlRagdoll : MonoBehaviour
{
    [SerializeField] private Collider myCollider;
    [SerializeField] private Collider[] colliders;

    private Animator myAnimator;

    private void Start()
    {
        colliders = GetComponentsInChildren<Collider>();
        myAnimator = GetComponent<Animator>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
    }

    public void ActiveRagdoll()
    {
        StartCoroutine(DelayRagdoll());
    }

    private IEnumerator DelayRagdoll()
    {
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }

        yield return new WaitForSeconds(0.1f);

        myAnimator.enabled = false;

        yield return new WaitForSeconds(0.6f);

        myCollider.enabled = false;
    }

}
