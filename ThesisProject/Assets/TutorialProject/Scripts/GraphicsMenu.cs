using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class GraphicsMenu : MonoBehaviour
{
    private GameObject playerObject;
    [SerializeField] TMP_Dropdown resolutionDropDown;
    [SerializeField] Slider mouseSensitivitySlider;
    [SerializeField] TMP_Text sensitivityValueTxt;
    private Resolution [] resolutions;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        PopulateResDropDown();
    }

    public void ChangeSensitivity()
    {
        int newSensitivity = (int)mouseSensitivitySlider.value;
        sensitivityValueTxt.text = newSensitivity.ToString();
        playerObject.GetComponent<F_PlayerLook>().mouseSensitivity = newSensitivity;
    }

    public void ToggleFullScren()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    void PopulateResDropDown()
    {
        int currentResIndex = 0;

        List<string> options = new List<string>();

        resolutions = Screen.resolutions;

        for(int i = 0; i < resolutions.Length; i++)
        {
            options.Add(resolutions[i].width + "x" + resolutions[i].height);
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResIndex = i;
            }
        }

        resolutionDropDown.ClearOptions();
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResIndex;
        resolutionDropDown.RefreshShownValue();

    }

    void ChangeResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
