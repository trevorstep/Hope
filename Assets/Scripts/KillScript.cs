using UnityEngine;

public class KillScript : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

   void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
            SoundManagerScript.PlaySound("Death");
        col.transform.position = spawnPoint.position;
    }
}
