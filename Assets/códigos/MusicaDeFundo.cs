using UnityEngine;

public class MusicaDeFundo : MonoBehaviour
{
    [Header("Música de Fundo")]
    public AudioClip musica;
    [Range(0f, 1f)]
    public float volume = 0.5f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = musica;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.volume = volume;

        if (musica != null)
            audioSource.Play();
    }
}
