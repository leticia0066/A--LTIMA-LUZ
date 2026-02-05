using UnityEngine;

public class Arma : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform pontoTiro;
    public float velocidadeBala = 10f;
    public AudioClip somTiro;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Atirar();
        }
    }

    void Atirar()
    {
        if (balaPrefab == null || pontoTiro == null)
        {
            Debug.LogError("BalaPrefab ou PontoTiro NAO configurado!");
            return;
        }

        GameObject bala = Instantiate(balaPrefab, pontoTiro.position, pontoTiro.rotation);
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        rb.linearVelocity = pontoTiro.right * velocidadeBala;

        if (somTiro != null)
            audioSource.PlayOneShot(somTiro);
    }
}
