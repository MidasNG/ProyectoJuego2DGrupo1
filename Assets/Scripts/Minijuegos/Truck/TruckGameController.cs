using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TruckGameController : MonoBehaviour
{
    private float time = 0f, t = 0f, finishTime = 20f;
    private int timer = 20;
    private Coroutine coroutine = null;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private TextMeshProUGUI scoreText, timeText;
    [SerializeField] private Canvas pauseCanvas;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= finishTime)
        {
            if (coroutine == null ) coroutine = StartCoroutine(Stop());
        }
    }

    private IEnumerator Stop()
    {
        pauseCanvas.enabled = false;
        while (Time.timeScale > 0.1)
        {
            t = t + Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Lerp(1, 0, curve.Evaluate(t));
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu minijuegos");
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
