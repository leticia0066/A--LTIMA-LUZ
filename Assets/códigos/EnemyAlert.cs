using UnityEngine;

public class EnemyAlert : MonoBehaviour
{
    public AudioSource audioSource;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Light"))
        {
            audioSource.Play();
        }
    }
}
