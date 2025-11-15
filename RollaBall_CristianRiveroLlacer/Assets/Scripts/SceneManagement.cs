using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public Material material;
    public HModeChecker hChecker;

    public void LoadScene(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ExitGame() 
    {
        Debug.Log("You closed the game.");
        Application.Quit();
    }

    public void LoadGameMode()
    {
        if (hChecker.hModeChecker)
        {
            SceneManager.LoadScene(7);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}

