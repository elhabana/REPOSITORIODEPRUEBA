using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseCode : MonoBehaviour
{

    public GameObject objectpause;
    public bool Pause = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectpause.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pause == false)
            {
                objectpause.SetActive(true);
                Pause = true;

                Time.timeScale = 0;
                Cursor.visible = true;
            }
            else if (Pause == true)
            {
                Continue();
            }
        }
    }

    public void Continue()
    {
        objectpause.SetActive(false);
        Pause = false;

        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void GoToMenu(string NameMenu)
    {
        SceneManager.LoadScene(NameMenu);
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}
