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

        RevisarResolucion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivaPantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void RevisarResolucion()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string opcion = resolutions[i].width + " x " + resolutions[i].height;
            opciones.Add(opcion);

            if (Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                resolucionActual = i;
            }
        }

        resolutionDropDown.AddOptions(opciones);
        resolutionDropDown.value = resolucionActual;
        resolutionDropDown.RefreshShownValue();

        resolutionDropDown.value = PlayerPrefs.GetInt("numeroResolution", 0);

    }

    public void CambiarResolucion(int IndiceResolucion)
    {
        PlayerPrefs.SetInt("numeroResolution", resolutionDropDown.value);

        Resolution resolution = resolutions[IndiceResolucion];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
