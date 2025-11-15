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
        LoadSavedResolution();
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
            string option = resolutions[i].width + " x " + resolutions[i].height + " @" + resolutions[i].refreshRateRatio.value + "Hz";
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

    void LoadSavedResolution()
    {
        int saved = PlayerPrefs.GetInt("resolutionIndex", resolutionsDropDown.value);
        resolutionsDropDown.value = saved;
        resolutionsDropDown.RefreshShownValue();
    }


    public void ChangeResolution(int resolutionIndex)
    {
        PlayerPrefs.SetInt("numberResolution", resolutionsDropDown.value);
        PlayerPrefs.Save();

        FullScreenMode mode = Screen.fullScreen 
            ? FullScreenMode.FullScreenWindow 
            : FullScreenMode.Windowed;

        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, mode, resolution.refreshRateRatio);
    }

}
