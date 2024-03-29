using System.Collections;
using UnityEngine;

public class Autodestruir : MonoBehaviour
{
    [SerializeField] private float tiempoVida;

    void Start()
    {
        // Invocar el m�todo de autodestrucci�n despu�s de un tiempo espec�fico
        StartCoroutine(DestruirDespuesDeTiempo());
    }

    private IEnumerator DestruirDespuesDeTiempo()
    {
        // Esperar el tiempo especificado
        yield return new WaitForSeconds(tiempoVida);

        // Destruir el objeto de puntuaci�n despu�s del tiempo especificado
        Destroy(gameObject);
    }
}
