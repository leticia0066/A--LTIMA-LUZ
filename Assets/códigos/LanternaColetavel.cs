using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LanternaColetavel : MonoBehaviour
{
    public float aumentoLuz = 0.3f;
    public AudioClip somColeta;

    private Respawn respawn;

    void Start()
    {
        respawn = GetComponent<Respawn>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        //  Luz
        Light2D luz = other.GetComponentInChildren<Light2D>();
        if (luz != null)
            luz.intensity += aumentoLuz;

        //  SOM (NO PLAYER)
        AudioSource audio = other.GetComponent<AudioSource>();
        if (audio != null && somColeta != null)
        {
            audio.PlayOneShot(somColeta);
        }
        else
        {
            Debug.LogWarning("Lanterna: AudioSource ou somColeta faltando");
        }

        // RESPAWN
        if (respawn != null)
            respawn.IniciarRespawn();
        else
            gameObject.SetActive(false);
    }
}
