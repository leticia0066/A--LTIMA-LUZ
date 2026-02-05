using UnityEngine;

public class CameraSeguirPlayer : MonoBehaviour
{
    public Transform player;      // arraste o Player aqui no Inspector
    public float suavidade = 0.15f;  // velocidade de atraso da câmera

    private Vector3 velocidadeSuave = Vector3.zero;

    void LateUpdate()
    {
        if (player == null)
            return;

        // Posição desejada da câmera (mantém o Z atual)
        Vector3 posicaoAlvo = new Vector3(player.position.x, player.position.y, transform.position.z);

        // Movimento suave até o alvo
        transform.position = Vector3.SmoothDamp(
            transform.position,
            posicaoAlvo,
            ref velocidadeSuave,
            suavidade
        );
    }
}
