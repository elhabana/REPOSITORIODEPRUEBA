using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerInteractor : MonoBehaviour
{
    [Header("Points")]
    public int points;
    private int[] winpoints = new int[4] { 6, 12, 18, 24 };
    public TMP_Text pointsText;

    [Header("Rigid Body")]
    public Rigidbody[] rb = new Rigidbody[3];

    [Header("Game Objects")]
    public GameObject[] mission = new GameObject[4];
    public GameObject[] lavaWall = new GameObject[3];


    [Header("Sound References")]
    public PlayerController playerCont;


    void Start()
    {
        points = 0;
        rb[0].useGravity = false;
        rb[1].useGravity = false;
        rb[2].useGravity = false;
        mission[0].gameObject.SetActive(true);
        mission[1].gameObject.SetActive(false);
        mission[2].gameObject.SetActive(false);
        lavaWall[0].gameObject.SetActive(true);
        lavaWall[1].gameObject.SetActive(true);
        lavaWall[2].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (points == winpoints[3])
        {
            SceneManager.LoadScene(2);
        }

        else if (points == winpoints[0])
        {
            rb[0].useGravity = true;
            mission[0].gameObject.SetActive(false);
            mission[1].gameObject.SetActive(true);
            lavaWall[0].gameObject.SetActive(false);
        }

        else if (points == winpoints[1])
        {
            rb[1].useGravity = true;
            mission[1].gameObject.SetActive(false);
            mission[2].gameObject.SetActive(true);
            lavaWall[1].gameObject.SetActive(false);
        }

        else if (points == winpoints[2])
        {
            rb[2].useGravity = true;
            mission[2].gameObject.SetActive(false);
            mission[3].gameObject.SetActive(true);
            lavaWall[2].gameObject.SetActive(false);

        }
            pointsText.text = "Points: " + points.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            points++;
            other.gameObject.SetActive(false);
            playerCont.PlaySFX(1);
            // The option, that is commented, below this message uses more RAM
            // Destroy(other.gameObject);
        }
    }
}
