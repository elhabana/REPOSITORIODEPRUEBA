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
    public Rigidbody rb1;
    public Rigidbody rb2;
    public GameObject mission1;
    public GameObject mission2;
    public GameObject mission3;
    public GameObject tallWall1;
    public GameObject tallWall2;


    [Header("Sound References")]
    public PlayerController playerCont;


    void Start()
    {
        points = 0;
        rb1.useGravity = false;
        rb2.useGravity = false;
        mission1.gameObject.SetActive(true);
        mission2.gameObject.SetActive(false);
        mission3.gameObject.SetActive(false);
        tallWall1.gameObject.SetActive(true);
        tallWall2.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (points == winpointsfinal)
        {
            SceneManager.LoadScene(2);
            mission3.gameObject.SetActive(false);
        }

        else if (points == winpointslv1)
        {
            rb1.useGravity = true;
            mission1.gameObject.SetActive(false);
            mission2.gameObject.SetActive(true);
            tallWall1.gameObject.SetActive(false);
        }

        else if (points == winpointslv2)
        {
            rb2.useGravity = true;
            mission2.gameObject.SetActive(false);
            mission3.gameObject.SetActive(true);
            tallWall2.gameObject.SetActive(false);
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
