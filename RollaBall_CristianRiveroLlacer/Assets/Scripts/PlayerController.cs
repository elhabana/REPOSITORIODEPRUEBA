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
	public Transform[] respawnPoints = new Transform[5];
	public GameObject[] respawnDespawn = new GameObject[4];
    public float falllimit = -3;


	[Header("Mushroom Properties")]
	public bool mushroomProtect = false;
	public Mushroom shieldBreak;
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
			LivesImage[2].SetActive(false);
		}
	}

	public void Damage()
	{
		if (mushroomProtect && shieldBreak.shield == 1)
		{
			mushroomProtect = false;
			--shieldBreak.shield;
			ShieldBreak();
			return;
		}

		//if there isn't a mushroom protect then rest lives:
		--lives;
	}

	void ShieldBreak()
	{
		if (shieldBreak.shield == 0)
		{
            shieldImg.shieldImage.SetActive(false);
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

		else if (playerInteractor.points >= 6)
        {
            respawnDespawn[0].gameObject.SetActive(false);
			transform.position = respawnPoints[1].transform.position;
        }

		else if (playerInteractor.points >= 12)
        {
            respawnDespawn[1].gameObject.SetActive(false);
            transform.position = respawnPoints[2].transform.position;
        }

        else if (playerInteractor.points >= 18)
        {
            respawnDespawn[2].gameObject.SetActive(false);
            transform.position = respawnPoints[3].transform.position;
        }

		else if (playerInteractor.points >= 23)
        {
            respawnDespawn[3].gameObject.SetActive(false);
            transform.position = respawnPoints[4].transform.position;
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
			Destroy(other.gameObject); // mushroom desappear
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

