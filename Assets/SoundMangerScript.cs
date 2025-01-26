using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerHitSound, jumpSound, jumpSoundtwo;
    static AudioSource audioSrc;

    void Start()
    {
        // Load the audio clips from Resources folder
        playerHitSound = Resources.Load<AudioClip>("Death");
        jumpSound = Resources.Load<AudioClip>("Jump1");
        jumpSoundtwo = Resources.Load<AudioClip>("Jump2");
        audioSrc = GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject
    }

    void Update()
    {
        // Any update logic goes here if needed
    }

    public static void PlaySound(string clip)
    {
        // Play sound based on the string passed in
        switch (clip)
        {
            case "Death":
                audioSrc.PlayOneShot(playerHitSound); // Play death sound
                break;
            case "Jump1":
                audioSrc.PlayOneShot(jumpSound); // Play first jump sound
                break;
            case "Jump2":
                audioSrc.PlayOneShot(jumpSoundtwo); // Play second jump sound
                break;
            default:
                Debug.LogWarning("Sound clip not recognized: " + clip); // In case the sound is not recognized
                break;
        }
    }
}
