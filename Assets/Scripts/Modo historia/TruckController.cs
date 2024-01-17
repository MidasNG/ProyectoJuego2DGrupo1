using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TruckController : MonoBehaviour
{
    private float time = 0f, t = 0f, finishTime = 10f, score = 0;
    private int combo = 0, timer = 10;
    private Coroutine coroutine = null;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private TextMeshProUGUI scoreText, timeText;
    [SerializeField] private Canvas pauseCanvas;

    private void Start()
    {
        // Comienza el temporizador
        StartCoroutine(Timer());
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= finishTime)
        {
            if (coroutine == null) coroutine = StartCoroutine(StopGame());
        }
    }

    public void AddScore()
    {
        combo++;
        score += 10 * combo;
        scoreText.text = "Puntos: " + ((int)score).ToString();
    }

    public void SubtractScore()
    {
        combo = 0;
        score -= score / 100 * 33;
        scoreText.text = "Puntos: " + ((int)score).ToString();
    }

    private IEnumerator StopGame()
    {
        pauseCanvas.enabled = false;
        while (Time.timeScale > 0.1)
        {
            t = t + Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Lerp(1, 0, curve.Evaluate(t));
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSecondsRealtime(2f);

        // Cambia la siguiente línea para cargar la siguiente escena en GameManager
        GameManager.instance.StartCoroutine(GameManager.instance.StartNextMinigame());
    }

    private IEnumerator Timer()
    {
        while (timer != 0)
        {
            yield return new WaitForSeconds(1f);
            timer--;
            timeText.text = "Tiempo: " + timer.ToString();
        }
    }
}
