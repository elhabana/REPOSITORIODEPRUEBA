using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerInteractor : MonoBehaviour
{
    [Header("Points")]
    public int points;
    private int winpointsfinal = 24;
    private int winpointslv1 = 6;
    private int winpointslv2 = 12;
    private int winpointslv3 = 18;
    public TMP_Text pointsText;

    [Header("Rigid Body")]
    public Rigidbody rb1;
    public Rigidbody rb2;
    public Rigidbody rb3;

    [Header("Game Objects")]
    public GameObject mission1;
    public GameObject mission2;
    public GameObject mission3;
    public GameObject mission4;
    public GameObject lavaWall1;
    public GameObject lavaWall2;
    public GameObject lavaWall3;


    [Header("Sound References")]
    public PlayerController playerCont;


    void Start()
    {
        points = 0;
        rb1.useGravity = false;
        rb2.useGravity = false;
        rb3.useGravity = false;
        mission1.gameObject.SetActive(true);
        mission2.gameObject.SetActive(false);
        mission3.gameObject.SetActive(false);
        lavaWall1.gameObject.SetActive(true);
        lavaWall2.gameObject.SetActive(true);
        lavaWall3.gameObject.SetActive(true);
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
            rb1.useGravity = true;
            mission1.gameObject.SetActive(false);
            mission2.gameObject.SetActive(true);
            lavaWall1.gameObject.SetActive(false);
        }

        else if (points == winpointslv2)
        {
            rb2.useGravity = true;
            mission2.gameObject.SetActive(false);
            mission3.gameObject.SetActive(true);
            lavaWall2.gameObject.SetActive(false);
        }

        else if (points == winpointslv3)
        {
            rb3.useGravity = true;
            mission3.gameObject.SetActive(false);
            mission4.gameObject.SetActive(true);
            lavaWall3.gameObject.SetActive(false);

        }
            pointsText.text = "Points: " + points.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            points++;

            // The option, that is commented, below this message uses more RAM
            // Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            playerCont.PlaySFX(1);
        }
    }
}
