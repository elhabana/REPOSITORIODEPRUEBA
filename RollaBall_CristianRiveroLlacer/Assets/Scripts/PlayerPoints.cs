using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    [Header("Reference")]
    public static int points;
    public bool hModeCheck;
    
    void Start()
    {
        if (points < 32)
        {
            points = 31;
            hModeCheck = false;
        }
        else if (points == 32)
        {
            Debug.Log("Hardmode Enabled");
        }
        else
        {
            Debug.Log("Error");
        }
    }

    void Update()
    {
        HardModeTrue();
    }

    void HardModeTrue()
    {
        if (points == 32)
        {
            hModeCheck = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp") && points < 32)
        {
            ++points;
            print(points);
        }
    }
}
