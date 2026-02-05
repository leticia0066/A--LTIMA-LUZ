using UnityEngine;

public class Bala : MonoBehaviour
{
    public int dano = 1;
    public float tempoVida = 2f;

    void Start()
    {
        Destroy(gameObject, tempoVida);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Vida vida = other.GetComponent<Vida>();

        if (vida != null)
        {
            vida.TomarDano(dano);
            Destroy(gameObject);
        }
    }
}
