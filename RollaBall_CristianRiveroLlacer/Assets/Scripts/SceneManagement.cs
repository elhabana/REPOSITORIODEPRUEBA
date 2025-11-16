using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneManagement : MonoBehaviour
{
    public Material material;
    public static bool hardMode;
    public TMP_Text timeText;

    void Start()
    {
        float t = PlayerInteractor.finalTime;
        int min = Mathf.FloorToInt(t / 60f);
        int sec = Mathf.FloorToInt(t % 60f);

        if (timeText != null)
            timeText.text = $"Tiempo: {min:00}:{sec:00}";
    }

    public void LoadScene(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LoadGameplay()
    {
        if (hardMode == true)
        {
            SceneManager.LoadScene(7);
        }

        else if (hardMode == false)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void ExitGame() 
    {
        Debug.Log("You closed the game.");
        Application.Quit();
    }
    
    public void SetHardModeOn()
    {
        hardMode = true;
        SceneManager.LoadScene(7);
    }

    public void SetHardModeOff()
    {
        hardMode = false;
        SceneManager.LoadScene(1);
    }
}

