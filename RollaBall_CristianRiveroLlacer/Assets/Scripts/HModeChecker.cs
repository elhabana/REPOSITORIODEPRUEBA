using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HModeChecker : MonoBehaviour
{
    public bool hModeChecker;

    void Start()
    {
        hModeChecker = HardcoreMode.hModeEnable;
    }
}
