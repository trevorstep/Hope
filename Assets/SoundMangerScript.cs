using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerHitSound, jumpSound, jumpSoundtwo;
    static AudioSource audioSrc;

    void Start()
    {
   
        playerHitSound = Resources.Load<AudioClip>("Death");
        jumpSound = Resources.Load<AudioClip>("Jump1");
        jumpSoundtwo = Resources.Load<AudioClip>("Jump2");
        audioSrc = GetComponent<AudioSource>(); 
    }



    public static void PlaySound(string clip)
    {
 
        switch (clip)
        {
            case "Death":
                audioSrc.PlayOneShot(playerHitSound); 
                break;
            case "Jump1":
                audioSrc.PlayOneShot(jumpSound); 
                break;
            case "Jump2":
                audioSrc.PlayOneShot(jumpSoundtwo); 
                break;
            default:
                Debug.LogWarning("Sound clip not recognized: " + clip); 
                break;
        }
    }
}
