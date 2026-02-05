using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LanternaPerigo : MonoBehaviour
{
    public Light2D luz;

    [Header("Tremida")]
    public float intensidadeNormal = 1f;
    public float intensidadeMin = 0.7f;
    public float intensidadeMax = 1.3f;
    public float velocidade = 0.1f;

    private int inimigosPerto = 0;

    void Update()
    {
        if (inimigosPerto > 0)
        {
            luz.intensity = Mathf.Lerp(
                luz.intensity,
                Random.Range(intensidadeMin, intensidadeMax),
                velocidade
            );
        }
        else
        {
            luz.intensity = Mathf.Lerp(
                luz.intensity,
                intensidadeNormal,
                velocidade
            );
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Vida>() != null)
            inimigosPerto++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Vida>() != null)
            inimigosPerto--;
    }
}
