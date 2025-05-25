using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScript : MonoBehaviour
{
    private bool isPaused;
    [SerializeField] GameObject pauseMenuObject, pauseStartMenuObject, menuList;
    private GameObject playerObject;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        //pauseStartMenuObject = GameObject.FindGameObjectWithTag("pauseStartMenu");
        ResetPauseUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnPauseGame(InputValue input)
    {
        Debug.Log("isPaused");
        if (!isPaused)
        {
            PauseGame();
        }
        else
            UnPauseGame();
    }
    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerObject.GetComponent<PlayerInput>().enabled = false;
        pauseMenuObject.SetActive(true);
        pauseStartMenuObject.SetActive(true);
    }
    public void UnPauseGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerObject.GetComponent<PlayerInput>().enabled = true;
        pauseMenuObject.SetActive(false);
       // pauseStartMenuObject.SetActive(false);
        ResetPauseUI();
    }
    void ResetPauseUI ()
    {
        for (int i = 0; i < menuList.transform.childCount; i++)
        {
            menuList.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
