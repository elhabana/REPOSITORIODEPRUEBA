using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;

public class FullScreen : MonoBehaviour
{
    public Toggle toggle;

    public TMP_Dropdown resolutionsDropDown;
    Resolution[] resolutions;
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

        CheckResolution();
        var refresh = new RefreshRate { numerator = 60, denominator = 1 };
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);

    }
    void Update()
    {
        
    }

    public void FullScreenOn(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }


    public void CheckResolution()
    {
        resolutions = Screen.resolutions;
        resolutionsDropDown.ClearOptions();
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

        resolutionsDropDown.AddOptions(options);
        resolutionsDropDown.value = currentResolution;
        resolutionsDropDown.RefreshShownValue();

        resolutionsDropDown.value = PlayerPrefs.GetInt("numberResolution", 0);

    }

    public void ChangeResolution(int resolutionIndex)
    {
        PlayerPrefs.SetInt("numeroResolucion", resolutionsDropDown.value);  

        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
