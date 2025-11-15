using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;

public class FullScreen : MonoBehaviour
{
    public Toggle toggle;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

       
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FullScreenOn(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }
<<<<<<< HEAD
=======

    public void ReviewResolution()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolution = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolution = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolution;
        resolutionDropDown.RefreshShownValue();

        resolutionDropDown.value = PlayerPrefs.GetInt("numberResolution", 0);

    }

    public void ChangeResolution(int resolutionIndex)
    {
        PlayerPrefs.SetInt("numberResolution", resolutionDropDown.value);

        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
>>>>>>> parent of 26472b0 (arreglito)
}
