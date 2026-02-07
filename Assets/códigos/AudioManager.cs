using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // 🔹 Singleton (funciona com instance e instancia)
    public static AudioManager instance;
    public static AudioManager instancia;

    [Header("Fontes de Áudio")]
    public AudioSource musicaFundo;
    public AudioSource musicaBoss;
    public AudioSource sfx;

    [Header("Clipes")]
    public AudioClip musicaNormal;
    public AudioClip musicaBossClip;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        instancia = this;
        DontDestroyOnLoad(gameObject);

        // 🔹 garante que as AudioSources existam
        if (musicaFundo == null)
            musicaFundo = gameObject.AddComponent<AudioSource>();

        if (musicaBoss == null)
            musicaBoss = gameObject.AddComponent<AudioSource>();

        if (sfx == null)
            sfx = gameObject.AddComponent<AudioSource>();

        musicaFundo.loop = true;
        musicaBoss.loop = true;
    }

    void Start()
    {
        TocarMusicaNormal();
    }

    // 🎵 Música normal
    public void TocarMusicaNormal()
    {
        if (musicaNormal == null) return;

        musicaBoss.Stop();
        musicaFundo.clip = musicaNormal;
        musicaFundo.Play();
    }

    // 👹 Música do boss
    public void TocarMusicaBoss()
    {
        if (musicaBossClip == null) return;

        musicaFundo.Stop();
        musicaBoss.clip = musicaBossClip;
        musicaBoss.Play();
    }

    // 🔊 Efeitos sonoros
    public void TocarSFX(AudioClip clip)
    {
        if (clip == null) return;
        sfx.PlayOneShot(clip);
    }
}
