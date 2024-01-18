using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<string> minigameScenes = new List<string>();
    [SerializeField] private string creditsScene;
    public static GameManager instance;

    private void Awake()
    {
        // Asegúrate de que solo haya una instancia de GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Evita que el objeto GameManager se destruya al cargar nuevas escenas
        }
        else
        {
            Destroy(gameObject); // Si ya hay una instancia, destruye este objeto
        }
    }

    public void Start()
    {
        instance = this;
       // // Agrega todas las escenas de minijuegos a la lista al inicio del juego
       // //print(SceneManager.sceneCount);
       ////     for (int i = 0; i < SceneManager.sceneCount; i++)
       // {
       //     Scene scene = SceneManager.GetSceneAt(i);
       //     if (scene.name != "Menu historia" && scene.name != creditsScene && !scene.name.StartsWith("Instrucciones_"))
       //     {
       //         minigameScenes.Add(scene.name);
       //     }
       // }

        // Comienza el primer minijuego
        StartCoroutine(StartNextMinigame());
    }

    public IEnumerator StartNextMinigame()
    {
        while (minigameScenes.Count > 0)
        {
            // Elige una escena aleatoria de la lista
            int randomIndex = Random.Range(0, minigameScenes.Count);
            string nextMinigameScene = minigameScenes[randomIndex];

            // Elimina la escena de la lista
            minigameScenes.RemoveAt(randomIndex);

            // Carga la escena del minijuego
            SceneManager.LoadScene(nextMinigameScene);

            // Espera hasta que el minijuego termine
            yield return new WaitForSeconds(20f); // Ajusta el tiempo según el minijuego

            // Puedes agregar aquí lógica adicional si es necesario
        }

        // Si no hay más minijuegos, carga la escena de créditos
        SceneManager.LoadScene(creditsScene);
    }
}
