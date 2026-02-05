using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Vida")]
    public int vida = 10;

    [Header("Sons")]
    public AudioClip somMorte;
    public AudioClip somDano;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void TomarDano(int dano)
    {
        vida -= dano;

        if (somDano != null)
            audioSource.PlayOneShot(somDano);

        if (vida <= 0)
            Morrer();
    }

    void Morrer()
    {
        if (somMorte != null)
            AudioSource.PlayClipAtPoint(somMorte, transform.position);

        Destroy(gameObject);
    }
}
