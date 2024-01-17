using System.Collections;
using UnityEngine;

public class Autodestruir : MonoBehaviour
{
    public float tiempoVida = 0.5f;

    void Start()
    {
        // Invocar el método de autodestrucción después de un tiempo específico
        StartCoroutine(DestruirDespuesDeTiempo());
    }

    private IEnumerator DestruirDespuesDeTiempo()
    {
        // Esperar el tiempo especificado
        yield return new WaitForSeconds(tiempoVida);

        // Destruir el objeto de puntuación después del tiempo especificado
        Destroy(gameObject);
    }
}
