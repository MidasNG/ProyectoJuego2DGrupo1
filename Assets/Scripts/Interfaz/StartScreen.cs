using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaInicio : MonoBehaviour
{
    [SerializeField] private float tiempoEspera; // Tiempo de espera en segundos
    [SerializeField] private string nombreDeLaSiguienteEscena; // Nombre de la siguiente escena

    private bool permitirCambioDeEscena = false;

    private void Start()
    {
        // Invocar el método para permitir el cambio de escena después del tiempo de espera
        Invoke("PermitirCambio", tiempoEspera);
    }

    private void Update()
    {
        // Cambiar de escena solo si se permite el cambio y se presiona cualquier tecla
        if (permitirCambioDeEscena && Input.anyKeyDown)
        {
            CambiarDeEscena();
        }
    }

    private void PermitirCambio()
    {
        permitirCambioDeEscena = true;
    }

    private void CambiarDeEscena()
    {
        if (!string.IsNullOrEmpty(nombreDeLaSiguienteEscena))
        {
            SceneManager.LoadScene(nombreDeLaSiguienteEscena);
        }
        else
        {
            Debug.LogWarning("Nombre de la siguiente escena no especificado en el inspector.");
        }
    }
}
