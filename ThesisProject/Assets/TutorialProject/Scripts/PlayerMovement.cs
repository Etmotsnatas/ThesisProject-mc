using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody charachterRB;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float startMovementSpeed = 5f;
    [SerializeField] private float jumpForce = 200f;

    private Vector3 movementInput;
    private bool isJumping = false;
    private bool isGrounded = false;
    private bool isSprinting = false;

    void Start()
    {
        if (charachterRB == null)
            charachterRB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Calculate movement direction
        Vector3 move = transform.right * movementInput.x + transform.forward * movementInput.z;
        Vector3 newVelocity = new Vector3(move.x * movementSpeed, charachterRB.linearVelocity.y, move.z * movementSpeed);
        charachterRB.linearVelocity = newVelocity;
        isJumping = false;
        if (!isSprinting) 
           movementSpeed = startMovementSpeed;
        else
            movementSpeed = startMovementSpeed * 2;

    }

    private void OnMovement(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();
        movementInput = new Vector3(inputVec.x, 0, inputVec.y);
    }

    private void OnJump(InputValue input)
    {
        if (!isJumping && isGrounded)
        {
            charachterRB.AddForce(0, jumpForce, 0);
            isJumping = true;
        }
    }
    private void OnSprint(InputValue input)
    {
        isSprinting = true;
        
    }

    private void OnSprintStop(InputValue input)
    {
        isSprinting = false;
    }

    // Simple ground check using collision
    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.8f)
            {
                isGrounded = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}