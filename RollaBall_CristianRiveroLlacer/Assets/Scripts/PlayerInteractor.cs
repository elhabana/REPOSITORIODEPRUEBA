using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerInteractor : MonoBehaviour
{
    public int points;
    public int winpointsfinal;
    public int winpointslv1;
    public int winpointslv2;
    public TMP_Text pointsText;
   

    [Header("Sound References")]
    public PlayerController playerCont;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (points >= winpointsfinal) 
        {
            SceneManager.LoadScene(2);
        }

        else if (points >= winpointslv1)
        {
            SceneManager.LoadScene(5);
        }

        else if (points >= winpointslv2)
        {
            SceneManager.LoadScene(0);
        }

        pointsText.text = "Points: " + points.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            points++;

            // Esta Opcion Consume mas RAM,
            // Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            playerCont.PlaySFX(1);
        }

    }
}
