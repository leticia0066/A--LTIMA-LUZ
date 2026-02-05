using System.Collections;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager instancia;

    void Awake()
    {
        if (instancia == null)
            instancia = this;
        else
            Destroy(gameObject);
    }

    public void Iniciar(Respawn respawn)
    {
        StartCoroutine(RespawnCoroutine(respawn));
    }

    IEnumerator RespawnCoroutine(Respawn respawn)
    {
        respawn.gameObject.SetActive(false);

        yield return new WaitForSeconds(respawn.tempoParaRespawn);

        respawn.Reativar();
    }
}
