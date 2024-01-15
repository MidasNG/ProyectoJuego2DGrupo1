using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TruckGameController : MonoBehaviour
{
    private float time = 0f, t = 0f, finishTime = 10f;
    private int score = 0, combo = 0, timer = 10;
    private Coroutine coroutine = null;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private TextMeshProUGUI scoreText, timeText;

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

    public void AddScore()
    {
        combo++;
        score += 10 * combo;
        scoreText.text = score.ToString();
    }

    public void SubtractScore()
    {
        combo = 0;
        score-= score / 100 * 33;
        scoreText.text = score.ToString();
    }

    private IEnumerator Stop()
    {
        while (Time.timeScale > 0.1)
        {
            t = t + Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Lerp(1, 0, curve.Evaluate(t));
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("Menu minijuegos");
    }

    private IEnumerator Timer()
    {
        while (timer != 0)
        {
            yield return new WaitForSeconds(1f);
            timer--;
            timeText.text = timer.ToString();
        }
    }
}
