using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	[Header("Sound Configuration")]
	public AudioClip[] soundcollection;

	[Header("References")]
	public Rigidbody playerRb;
	public AudioSource playeraudio;
    public GameObject levelMusic;
	public AudioSource levelAudio;
	public PlayerInteractor playerInteractor;

    [Header("Movement Parameters")]
	public float speed = 5;
	public Vector2 moveInput;

	[Header("Jump Parameters")]
	public float jumpforce = 5.0f;
	public bool isGrounded;

	[Header("Respawns")]
	public Transform[] respawnPoints = new Transform[8];
	public float falllimit = -3;
	public bool shortcut;

	[Header("Mushroom Properties")]
	public bool mushroomProtect = false;
	public Mushroom shieldImg;

    [Header("Lives")]
	public int lives;
	public GameObject[] LivesImage = new GameObject[3];

	void Start()
	{
		lives = 3;
        LivesImage[0].SetActive(true);
        LivesImage[1].SetActive(true);
        LivesImage[2].SetActive(true);
		levelMusic.SetActive(true);
		shortcut = false;
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
			LivesImage[0].SetActive(false);
		}

		if(lives == 1)
		{
			LivesImage[1].SetActive(false);
		}

		if(lives == 0)
		{
			SceneManager.LoadScene(3);
			PlayerPoints.points = 0;
			print(PlayerPoints.points);
			LivesImage[2].SetActive(false);
		}
	}

	public void Damage()
	{
		if (mushroomProtect)
		{
			mushroomProtect = false;
            shieldImg.shieldImage.SetActive(false);
            return;
		}
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
        }
	}

	void Respawn()
	{
		if (playerInteractor.points < 6)
		{
			transform.position = respawnPoints[0].transform.position;
		}

		else if (playerInteractor.points < 12)
		{
			transform.position = respawnPoints[1].transform.position;
		}

		else if (playerInteractor.points <= 15)
		{
			transform.position = respawnPoints[2].transform.position;
		}

        else if (playerInteractor.points < 18 && !shortcut)
        {
            transform.position = respawnPoints[3].transform.position;
        }

        else if (playerInteractor.points < 18 && shortcut == true)
        {

            transform.position = respawnPoints[6].transform.position;
        }

        else if (playerInteractor.points < 24)
        {
            transform.position = respawnPoints[4].transform.position;
        }

		else if (playerInteractor.points < 29)
		{
			transform.position = respawnPoints[7].transform.position;
		}

		else if (playerInteractor.points <= 31)
		{
			transform.position = respawnPoints[5].transform.position;
		}

        playerRb.linearVelocity = Vector3.zero;
		PlaySFX(3);
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Mushroom"))
		{
			mushroomProtect = true; //protect active
			Debug.Log("You have a mushroom protect");
			Destroy(other.gameObject); // mushroom disappear
            PlaySFX(5);
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

