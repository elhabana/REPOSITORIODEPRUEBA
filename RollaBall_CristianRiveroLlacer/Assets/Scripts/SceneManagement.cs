using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public Material material;
    public static bool hardMode;

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

