using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [Header("Visual Rotate")]
    public float rotationSpeed = 50f;

    [Header("Respawn optional")]
    public bool canRespawn = false; //If mushroom can reappear
    public float respawnTime = 10f; //Time in seconds for reappear
    private bool isCollected=false;

    private Vector3 originalPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPosition=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate for atractive visual effect
        transform.Rotate(Vector3.up*rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Only react if player touch it
        if (other.CompareTag("Player")&& !isCollected)
        {
            Debug.Log("player touch mushroom");

            PlayerController player =other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.mushroomProtect = true; //activa la proteccion en el player
                Debug.Log("Protected");
            }

            isCollected = true;
            gameObject.SetActive(false);//Desappear visually
        }
    }
}
