using UnityEngine;

public class Vida : MonoBehaviour
{
    public int vida = 3;
    public AudioClip somMorte;

    private int vidaMaxima;
    private Respawn respawn;

    void Start()
    {
        vidaMaxima = vida;
        respawn = GetComponent<Respawn>();
    }

    void OnEnable()
    {
        vida = vidaMaxima;

        if (CompareTag("Boss"))
        {
            AudioManager.instancia.TocarMusicaBoss();
        }
    }

    public void TomarDano(int dano)
    {
        vida -= dano;

        if (vida <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
       GameObject player = GameObject.FindGameObjectWithTag("Player");
       if (player != null)
       {
        AudioSource audio = player.GetComponent<AudioSource>();
        if (audio != null && somMorte != null)
        audio.PlayOneShot(somMorte);
       }
       
       if(respawn != null)
       respawn.IniciarRespawn();
       else
       Destroy(gameObject);
    }
}
