using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Sound Configuration")]
    public AudioClip[] soundcollection;

    [Header("Editor References")]
    public Rigidbody playerRb;
    public AudioSource playeraudio;

    [Header("Movement Parameters")]
    public float speed = 5;
    public Vector2 moveInput;

    [Header("Jump Parameters")]
    public float jumpforce = 5.0f;
    public bool isGrounded;

    [Header("Respawn System")]
    public Transform respawnPoint;
    public float falllimit = -10;

    public int lives;
    public GameObject LivesImage;
    public GameObject LivesImage_1;
    public GameObject LivesImage_2;


    void Start()
    {
        lives = 3;
        LivesImage.SetActive(true);
        LivesImage_1.SetActive(true);
        LivesImage_2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= falllimit)
        {
            Respawn();
            -- lives;
        }

        if (lives == 2)
        {
            LivesImage.SetActive(false);
        }

        if (lives == 1)
        {
            LivesImage_1.SetActive(false);
        }

        if (lives == 0)
        {
            SceneManager.LoadScene(3);
            LivesImage_2.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        PhysicalMovement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Respawn();
            -- lives;
        }
    }

    void Respawn()
    {
        transform.position = respawnPoint.transform.position;
        playerRb.linearVelocity = Vector3.zero;
        PlaySFX(2);
    }

    public void PlaySFX(int soundToPlay)
    {
        playeraudio.PlayOneShot(soundcollection[soundToPlay]);
    }

    void CinematicMovement()
    {
        transform.Translate(Vector3.forward * speed * moveInput.y * Time.deltaTime);
        transform.Translate(Vector3.right * speed * moveInput.x * Time.deltaTime);
    }
    void PhysicalMovement()
    {
        playerRb.AddForce(Vector3.forward*speed*moveInput.y);
        playerRb.AddForce(Vector3.right*speed*moveInput.x);

    }
    void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpforce,ForceMode.Impulse);
        PlaySFX(0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput=context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded == true && context.performed)
        { 
            isGrounded = false;
            Jump();
        }
    }
}
