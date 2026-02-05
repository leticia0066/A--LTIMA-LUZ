using System.Collections;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float tempoParaRespawn = 5f;

    private Vector3 posicaoInicial;
    private Quaternion rotacaoInicial;

    void Awake()
    {
        posicaoInicial = transform.position;
        rotacaoInicial = transform.rotation;
    }

    public void IniciarRespawn()
    {
        RespawnManager.instancia.Iniciar(this);
    }

    public void Reativar()
    {
        transform.position = posicaoInicial;
        transform.rotation = rotacaoInicial;
        gameObject.SetActive(true);
    }
}
