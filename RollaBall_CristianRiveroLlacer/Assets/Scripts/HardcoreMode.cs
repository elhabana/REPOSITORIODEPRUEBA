using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HardcoreMode : MonoBehaviour
{
    [Header("Hardcore Activates")]
    public static bool hModeEnable;
    public GameObject hModeButton;
    public Button btn;

    [Header("Script References")]
    public PlayerPoints playerPoints;

    [Header("Unlock Text")]
    public GameObject winToUnlock;

    void Start()
    {
        hModeEnable = false;
        btn = hModeButton.GetComponent<Button>();
        btn.interactable = false;
    }


    void Update()
    {
        {
            hModeEnable = playerPoints.hModeCheck;
            HardMode();
            
            if (PlayerPoints.points == 32)
            {
                winToUnlock.gameObject.SetActive(false);
            }
        }
    }

    void HardMode()
    {
        btn.interactable = hModeEnable;
    }
}
