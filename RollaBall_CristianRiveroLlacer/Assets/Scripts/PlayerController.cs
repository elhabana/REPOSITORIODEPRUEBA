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

	[Header("Protection")]
	public bool mushroomProtect = false;

	public int lives;
	public GameObject LivesImage;
	public GameObject LivesImage_1;
	public GameObject LivesImage_2;
	public GameObject soundMushroom;
	public GameObject levelMusic;


	void Start()
	{
		lives = 3;
		LivesImage.SetActive(true);
		LivesImage_1.SetActive(true);
		LivesImage_2.SetActive(true);
        soundMushroom.SetActive(false);
		levelMusic.SetActive(true);
    }
	
	//Update is called once per frame void Update()
	void Update()
	{
		if(transform.position.y <= falllimit)
		{
			//I call Damage to protect
			Damage();
			// The player reappears
			Respawn();
		}

		if(lives == 2)
		{
			LivesImage.SetActive(false);
		}

		if(lives == 1)
		{
			LivesImage_1.SetActive(false);
		}

		if(lives == 0)
		{
			SceneManager.LoadScene(3);
			LivesImage_2.SetActive(false);
		}
	}

	void Damage()
	{
		if(mushroomProtect)
		{
			Debug.Log("Mushroom protect you!");
			mushroomProtect = false;
			return;
		}

		//if there isn't a mushroom protect then rest lives:
		--lives;
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
			Damage();
			Respawn();
            soundMushroom.SetActive(false);
            levelMusic.SetActive(true);
        }
	}

	void Respawn()
	{ 
		transform.position = respawnPoint.transform.position;
		playerRb.linearVelocity = Vector3.zero;
		PlaySFX(3);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Mushroom"))
		{
			mushroomProtect = true; //protect active
			Debug.Log("You have a mushroom protect");
			Destroy(other.gameObject); // mushroom desappear
            soundMushroom.SetActive(true);
            levelMusic.SetActive(false);
        }
	}

	public void PlaySFX(int soundToPlay) 
	{ 
		playeraudio.PlayOneShot(soundcollection[soundToPlay]);
	}

	void PhysicalMovement()
	{
		playerRb.AddForce(Vector3.forward * speed * moveInput.y);
		playerRb.AddForce(Vector3.right* speed * moveInput.x);
	}

	void Jump()
	{
		playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
		PlaySFX(0);
	}

	public void OnMove(InputAction.CallbackContext context)
	{
		moveInput=context.ReadValue<Vector2>();
	}

	void CinematicMovement()
	{
		transform.Translate(Vector3.forward * speed * moveInput.y * Time.deltaTime);
		transform.Translate(Vector3.right * speed * moveInput.x * Time.deltaTime);
	}
	
	public void OnJump(InputAction.CallbackContext context)
	{
		if(isGrounded == true && context.performed)
		{
			isGrounded = false; Jump();
		}
	}
}

