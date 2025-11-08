using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public Material material;

    public void LoadScene(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ExitGame() 
    {
        material.color = Color.red;
        Debug.Log("Has cerrado el juego");
        Application.Quit();
    }

}

