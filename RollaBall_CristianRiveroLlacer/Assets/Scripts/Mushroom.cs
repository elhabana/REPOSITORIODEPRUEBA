using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [Header("Visual Rotate")]
    public float rotationSpeed = 50f;

    [Header("Respawn Optional")]
    public bool canRespawn = false; //If mushroom can reappear
    public float respawnTime = 10f; //Time in seconds for reappear
    public bool isCollected=false;

    [Header("Shield Properties")]
    public int shield = 0;
    public GameObject shieldImage;

    private Vector3 originalPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPosition = transform.position;
        shieldImage.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        // Rotate for attractive visual effect
        transform.Rotate(Vector3.up*rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Only react if player touch it
        if (other.CompareTag("Player")&& !isCollected)
        {
            
            PlayerController player =other.GetComponent<PlayerController>();

            if (player != null)
            {
                player.mushroomProtect = true; //Actives protection in player
                ShieldAdd();
            }

            isCollected = true;
            gameObject.SetActive(false); //disappear visually
        }
    }

    public void ShieldAdd()
    {
        ++shield;
        if (shield == 1)
        {
            shieldImage.gameObject.SetActive(true);
        }

        else if (shield == 0)
        {
            shieldImage.gameObject.SetActive(false);
        }
    }
}
