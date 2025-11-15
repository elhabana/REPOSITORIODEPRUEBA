using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;

public class FullScreen : MonoBehaviour
{
    public Toggle toggle;

    public TMP_Dropdown resolutionDropDown;
    Resolution[] resolutions;


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

        ReviewResolution();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FullScreenOn(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }


    public void ReviewResolution()
    {
      
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();
     
        HashSet<string> uniqueResolutionStrings = new HashSet<string>();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        int currentIndex = 0;

     
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

        
            if (uniqueResolutionStrings.Add(option))
            {
         
                options.Add(option);

            
                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                  
                    currentResolutionIndex = currentIndex;
                }

                currentIndex++;
            }
        }
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
        int savedResolutionIndex = PlayerPrefs.GetInt("numberResolution", 0);
       
        if (savedResolutionIndex >= 0 && savedResolutionIndex < options.Count)
        {
            resolutionDropDown.value = savedResolutionIndex;
        }
        else
        {
            resolutionDropDown.value = currentResolutionIndex;
        }
    }

    public void ChangeResolution(int resolutionIndex)
    {
        PlayerPrefs.SetInt("numberResolution", resolutionDropDown.value);

        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
