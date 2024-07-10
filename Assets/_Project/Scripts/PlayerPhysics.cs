using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPhysics : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector2 myInput;
    private CharacterController characterController;
    private Transform myCamera;
    private Animator myAnimator;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        myAnimator = GetComponentInChildren<Animator>();
        myCamera = Camera.main.transform;
    }

    private void Update()
    {
        RotationPlayer();
        characterController.Move(transform.forward * myInput.magnitude * speed * Time.deltaTime);
        characterController.Move(Vector3.down * 9.81f * Time.deltaTime);
        myAnimator.SetFloat("Blend", myInput.magnitude);
    }

    public void Move(InputAction.CallbackContext value)
    {
        myInput = value.ReadValue<Vector2>();
    }

    private void RotationPlayer()
    {
        Vector3 forward = myCamera.TransformDirection(Vector3.forward);
        Vector3 right = myCamera.TransformDirection(Vector3.right);

        Vector3 targetDirection = myInput.x * right + myInput.y * forward;

        if (myInput != Vector2.zero && targetDirection.magnitude > 0.1f)
        {
            Quaternion freeRotation = Quaternion.LookRotation(targetDirection.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(transform.eulerAngles.x, freeRotation.eulerAngles.y, transform.eulerAngles.z)), 10 * Time.deltaTime);
        }
    }
}
