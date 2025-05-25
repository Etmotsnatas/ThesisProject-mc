using UnityEngine;
using UnityEngine.InputSystem;

public interface Iinteractable
{
    void Interact();
}

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] int interactRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = Camera.main;
    }

    private void OnInteract(InputValue input)
    {
        Ray ray = new Ray
        {
            origin = camera.transform.position,
            direction = camera.transform.forward
        };
        Debug.DrawRay(ray.origin, ray.direction * interactRange);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactRange))
        {
            IIinteractable interactable = hit.collider.GetComponent<IIinteractable>();
            if (interactable != null)
            {                
                interactable.Interact();
            }
        }
    }



    //// Update is called once per frame
    //void Update()
    //{

    //}
}
