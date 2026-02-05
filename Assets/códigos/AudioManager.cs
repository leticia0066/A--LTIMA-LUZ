using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instancia;

    [Header("Musicas")]
    public AudioClip musicaNormal;
    public AudioClip musicaBoss;

    private AudioSource audioSource;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        TocarMusicaNormal();
    }

    public void TocarMusicaNormal()
    {
        if (audioSource.clip == musicaNormal) return;

        audioSource.clip = musicaNormal;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void TocarMusicaBoss()
    {
        if (audioSource.clip == musicaBoss) return;

        audioSource.clip = musicaBoss;
        audioSource.loop = true;
        audioSource.Play();
    }
}
