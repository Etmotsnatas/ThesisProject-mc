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
        isSprinting = false;
        while (!isSprinting) 
           movementSpeed = startMovementSpeed;
        
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
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class PlayerMovement : MonoBehaviour
//{
//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    Rigidbody characterRB;
//    Vector3 movementInput, movementVector;
//    bool isSprinting, isCrouching;

//    [SerializeField] float movementSpeed, startMovementSpeed;

//   // Animator animator;
//    void Start()
//    {

//        characterRB = GetComponent<Rigidbody>();
//       // animator = GetComponent<Animator>();
//        startMovementSpeed = movementSpeed;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (isSprinting)
//        {
//            movementSpeed = 300;
//        }
//        else if (isCrouching)
//        {
//            movementSpeed = 50;
//        }
//        else
//        {
//            movementSpeed = startMovementSpeed;
//        }
//        if (movementInput != null)
//        {
//            movementVector = (transform.right * movementInput.x) + (transform.forward * movementInput.z);
//            movementVector.y = 0;
//            movementVector *= (Time.fixedDeltaTime * movementSpeed);
//        }
//        movementVector.y = characterRB.linearVelocity.y;
//        characterRB.linearVelocity = movementVector;

//    }
//    private void OnMovement(InputValue input)//namnge metoderna rätt för den fattar själv
//    {
//        movementInput = new Vector3(input.Get<Vector2>().x, 0, input.Get<Vector2>().y);
//        //animator.SetBool("isMoving", true);//string för att hitta boolen
//    }
//    private void OnMovementStop(InputValue input)
//    {
//        movementInput = Vector3.zero;
//        //animator.SetBool("isMoving", false);
//    }
//    private void OnJump()
//    {
//        characterRB.AddForce(0, 200, 0);
//    }
//    private void OnSprint()
//    {
//        if (!isSprinting)
//        {
//            isSprinting = true;
//            isCrouching = false;
//        }
//        else
//        {
//            isSprinting = false;
//        }
//    }
//    private void OnCrouch()
//    {
//        if (!isCrouching)
//        {
//            isCrouching = true;
//            isSprinting = false;
//        }
//        else
//        {
//            isCrouching = false;
//        }
//    }

//}