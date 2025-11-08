using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerInteractor : MonoBehaviour
{
    public int points;
    private int winpointsfinal = 18;
    private int winpointslv1 = 6;
    private int winpointslv2 = 12;
    public TMP_Text pointsText;
    public GameObject Wall12;
    public GameObject Wall13;


    [Header("Sound References")]
    public PlayerController playerCont;


    void Start()
    {
        points = 0;
        Wall12.gameObject.SetActive(true);
        Wall13.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (points == winpointsfinal)
        {
            SceneManager.LoadScene(2);
        }

        else if (points == winpointslv1)
        {
            Wall12.gameObject.SetActive(false);
        }

        else if (points == winpointslv2)
        {
            Wall13.gameObject.SetActive(false);
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
