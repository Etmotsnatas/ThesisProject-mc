//using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    [SerializeField] int mouseSens;
    [SerializeField] Camera playerCamera;
    float xRotation, yRotation;
    float mouseX, mouseY;


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

       
    }

    private void OnLook(InputValue input)
    {
        mouseX = input.Get<Vector2>().x;
        mouseY = input.Get<Vector2>().y;

    }
}
