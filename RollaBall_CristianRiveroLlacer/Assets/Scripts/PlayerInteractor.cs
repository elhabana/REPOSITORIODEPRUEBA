using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections;

public class PlayerInteractor : MonoBehaviour
{
    [Header("Points")]
    public int points;
    public int[] winpoints = new int[7] { 6, 12, 15, 18, 24, 31, 32 };
    public TMP_Text pointsText;
    public TMP_Text WinTxt;
    public int WinNum = 31;

    [Header("Rigid Body")]
    public Rigidbody[] rb = new Rigidbody[4];

    [Header("Game Objects")]
    public GameObject mission;
    public GameObject[] lavaWall = new GameObject[7];
    public GameObject[] lavaFloor = new GameObject[13];
    public GameObject[] LastWall = new GameObject[2];
    public GameObject flechaHard;
    public bool lavaActive;
    public bool lavaActive2;
    public bool winDoorActive;

    [Header("Cronómetro")]
    public GameObject objTimer;
    public TextMeshProUGUI textTimer;
    public float timeTimer;
    public static float finalTime;

    [Header("References")]
    public PlayerController playerCont;

    [Header("Desvanecer")]
    public float timeMission = 2f;
    public float tVisible = 1.5f;
    public TextMeshProUGUI textMission;

    void Start()
    {
        points = 0;
        rb[0].useGravity = false;
        rb[1].useGravity = false;
        rb[2].useGravity = false;

        flechaHard.gameObject.SetActive(false);

        if (mission != null)
        {
            textMission = mission.GetComponent<TextMeshProUGUI>();
            if (textMission != null)
                StartCoroutine(MissionFade());
        }

        textTimer = objTimer.GetComponent<TextMeshProUGUI>();
        timeTimer = 0f;

        lavaWall[3].gameObject.SetActive(false);

        for (int i = 0; i < lavaFloor.Length; i++)
        {
            lavaFloor[i].SetActive(false);
        }
    }

    void Update()
    {
        if (points == winpoints[0])
        {
            rb[0].useGravity = true;
            lavaWall[0].gameObject.SetActive(false);
        }

        else if (points == winpoints[1])
        {
            rb[1].useGravity = true;
            lavaWall[1].gameObject.SetActive(false);
        }

        else if (!lavaActive && points == winpoints[2])
        {
            rb[2].useGravity = true;
            lavaActive = true;
            lavaWall[2].gameObject.SetActive(false);
        }

        else if (!lavaActive2 && points == winpoints[3])
        {
            lavaActive2 = true;
            rb[3].useGravity = true;
            lavaWall[4].gameObject.SetActive(false);
            lavaWall[5].gameObject.SetActive(false);
            lavaWall[6].gameObject.SetActive(false);

        }

        else if (points == winpoints[4])
        {
            rb[4].useGravity = true;
            lavaWall[7].gameObject.SetActive(false);
            lavaWall[8].gameObject.SetActive(false);
        }

        else if (!winDoorActive && points == winpoints[5])
        {
            LastWall[0].gameObject.SetActive(false);
            LastWall[1].gameObject.SetActive(false);
            winDoorActive = true;
        }

        else if (points >= winpoints[6])
        {
            FinishLevel();
        }

        WinTxt.text = WinNum.ToString();

        timeTimer += Time.deltaTime;

        int min = Mathf.FloorToInt(timeTimer / 60);
        int sec = Mathf.FloorToInt(timeTimer % 60);

        textTimer.text = string.Format("{0:00}:{1:00}", min, sec);

        pointsText.text = "Points: " + points.ToString();
    }

    IEnumerator MissionFade()
    {
        yield return new WaitForSeconds(tVisible);

        float t = 0f;
        Color c = textMission.color;

        while (t < timeMission)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / timeMission);
            textMission.color = new Color(c.r, c.g, c.b, alpha);
            yield return null;
        }

        mission.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Trigger"))
        {
            lavaWall[2].gameObject.SetActive(true);
        }

        else if (collider.gameObject.CompareTag("Trigger2"))
        {
            lavaWall[5].gameObject.SetActive(true);
            lavaWall[6].gameObject.SetActive(true);
        }

        else if (collider.gameObject.CompareTag("Trigger3"))
        {
            lavaWall[3].gameObject.SetActive(true);
            playerCont.shortcut = true;
            flechaHard.gameObject.SetActive(true);
        }

        else if (collider.gameObject.CompareTag("Trigger4"))
        {
            for (int i = 0; i < lavaFloor.Length; i++)
            {
                lavaFloor[i].SetActive(true);
            }
        }

        else if (collider.gameObject.CompareTag("Trigger5"))
        {
            LastWall[0].gameObject.SetActive(true);
            LastWall[1].gameObject.SetActive(true);
        }

        else if (collider.CompareTag("PickUp"))
        {
            points++;
            WinNum--;

            if (points >= winpoints[6])
            {
                finalTime = timeTimer;
                FinishLevel();
            }

            collider.gameObject.SetActive(false);
            playerCont.PlaySFX(1);
        }
    }

    public void FinishLevel()
    {
        finalTime = timeTimer;
        UnityEngine.Cursor.visible = true;
        SceneManager.LoadScene(2);
    }
}

