using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LanternaFlicker : MonoBehaviour
{
    public Light2D luz;

    [Header("Flicker")]
    public float intensidadeMin = 0.7f;
    public float intensidadeMax = 1.2f;
    public float velocidade = 0.05f;

    private bool inimigoPerto = false;

    void Update()
    {
        if (inimigoPerto)
        {
            luz.intensity = Mathf.Lerp(
                luz.intensity,
                Random.Range(intensidadeMin, intensidadeMax),
                velocidade
            );
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo") || other.CompareTag("Boss"))
        {
            inimigoPerto = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo") || other.CompareTag("Boss"))
        {
            inimigoPerto = false;
            luz.intensity = 1f; // volta ao normal
        }
    }
}
