using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSounds : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
       audioSource = GetComponent<AudioSource>();
       
    }

    private void OnMovement(InputValue input)
    {
        audioSource.clip = SoundBank.instance.stepAudio;
        audioSource.Play();
    }

    private void OnMovementStop(InputValue input)
    {
        audioSource.Stop();
    }







    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
