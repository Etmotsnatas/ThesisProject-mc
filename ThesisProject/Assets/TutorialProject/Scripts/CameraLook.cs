//using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    [SerializeField] int mouseSens;
    [SerializeField] Camera playerCamera;
    [SerializeField] Transform playerBody;
    [SerializeField] Vector3 thirdPersonOffset = new Vector3(0, 2, -3);
    float xRotation, yRotation;
    float mouseX, mouseY;
    bool isFirstPerson = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
             
        xRotation -= mouseY * Time.deltaTime * mouseSens;
        yRotation += mouseX * Time.deltaTime * mouseSens;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        transform.rotation = Quaternion.Euler(0,yRotation,0);
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation,0,0);

        if (isFirstPerson)
        {
            playerCamera.transform.localPosition = Vector3.zero;
            playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
        else
        {
            Vector3 targetPosition = playerBody.position + Quaternion.Euler(0, playerBody.eulerAngles.y, 0) * thirdPersonOffset;
            playerCamera.transform.position = targetPosition;
            playerCamera.transform.LookAt(playerBody.position + Vector3.up * 1.5f);
        }


    }

    private void OnLook(InputValue input)
    {
        mouseX = input.Get<Vector2>().x;
        mouseY = input.Get<Vector2>().y;

    }
    private void OnToggleView(InputValue input)
    {
        isFirstPerson = !isFirstPerson;
    }
}
