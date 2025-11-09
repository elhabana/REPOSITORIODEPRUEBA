using UnityEngine;

public class LevelMusic : MonoBehaviour

{
    [Header("Level Music Parameters")]
    public AudioSource levelMusic;

    void Start()
    {
        GetComponent<AudioSource>().mute = false;
    }

    void Update()
    {
    
    }
}
