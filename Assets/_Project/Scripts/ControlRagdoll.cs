using System.Collections;
using UnityEngine;

public class ControlRagdoll : MonoBehaviour
{
    [SerializeField] private Collider myCollider;
    [SerializeField] private Collider[] colliders;
    [SerializeField] private GameObject collectPrefab;

    [SerializeField] private Rigidbody mainRigidbody;

    [SerializeField] private Transform spherePos;

    public Transform mainTransform;

    private Rigidbody[] rigidbodies;

    private Animator myAnimator;

    public float forcePunch;

    private void Start()
    {
        colliders = GetComponentsInChildren<Collider>();
        rigidbodies = GetComponentsInChildren<Rigidbody>();
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

        int index = Random.Range(0, rigidbodies.Length);
        rigidbodies[index].AddForce(Vector2.up * forcePunch, ForceMode.Impulse);

        yield return new WaitForSeconds(0.1f);

        myAnimator.enabled = false;
        myCollider.enabled = false;

        yield return new WaitForSeconds(3f);

        print("passou");

        GameObject temp = Instantiate(collectPrefab);
        temp.transform.SetParent(transform);
        temp.transform.position = spherePos.position;

        mainRigidbody.isKinematic = true;

        // Destroy(parent,0.2f);
    }

}
