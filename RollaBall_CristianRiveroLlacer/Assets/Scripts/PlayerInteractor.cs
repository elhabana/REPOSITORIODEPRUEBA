using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerInteractor : MonoBehaviour
{
    [Header("Points")]
    public int points;
    private int[] winpoints = new int[6] { 6, 12, 15, 18, 24, 32 };
    public TMP_Text pointsText;

    [Header("Rigid Body")]
    public Rigidbody[] rb = new Rigidbody[4];

    [Header("Game Objects")]
    public GameObject[] mission = new GameObject[5];
    public GameObject[] lavaWall = new GameObject[7];


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
        mission[3].gameObject.SetActive(false);

        lavaWall[0].gameObject.SetActive(true);
        lavaWall[1].gameObject.SetActive(true);
        lavaWall[2].gameObject.SetActive(true);
        lavaWall[3].gameObject.SetActive(false);
        lavaWall[4].gameObject.SetActive(true);
        lavaWall[5].gameObject.SetActive(true);
        lavaWall[6].gameObject.SetActive(true);
        lavaWall[7].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (points == winpoints[0])
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
            lavaWall[2].gameObject.SetActive(false);
            lavaWall[3].gameObject.SetActive(false);
        }

        else if (points == winpoints[3])
        {
            rb[3].useGravity = true;
            mission[2].gameObject.SetActive(false);
            mission[3].gameObject.SetActive(true);
            lavaWall[4].gameObject.SetActive(false);
            lavaWall[5].gameObject.SetActive(false);
        }

        else if (points == winpoints[4])
        {
            rb[3].useGravity = true;
            mission[3].gameObject.SetActive(false);
            mission[4].gameObject.SetActive(true);
            lavaWall[7].gameObject.SetActive(false);
            lavaWall[8].gameObject.SetActive(false);
        }

        else if (points == winpoints[5])
        {
            SceneManager.LoadScene(2);
        }

        pointsText.text = "Points: " + points.ToString();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("PickUp"))
        {
            points++;
            collider.gameObject.SetActive(false);
            playerCont.PlaySFX(1);
            // The option, that is commented, below this message uses more RAM
            // Destroy(collider.gameObject);
        }

        if (collider.gameObject.CompareTag("Trigger"))
        {
            lavaWall[2].gameObject.SetActive(true);
        }

        if (collider.gameObject.CompareTag("Trigger2"))
        {
            lavaWall[5].gameObject.SetActive(true);
        }

        if (collider.gameObject.CompareTag("Trigger3"))
        {
            lavaWall[3].gameObject.SetActive(true);
        }
    }
}

