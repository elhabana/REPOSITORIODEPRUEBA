using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerInteractor : MonoBehaviour
{
    public int points;
    public int winpoints;
    public TMP_Text pointsText;
    public GameObject PlusOne;
   

    [Header("Sound References")]
    public PlayerController playerCont;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        points = 0;
        PlusOne.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (points >= winpoints) 
        {
            SceneManager.LoadScene(2);
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
            PlusOne.SetActive(true);
            playerCont.PlaySFX(1);
        }

    }
}
