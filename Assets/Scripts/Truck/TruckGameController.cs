using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TruckGameController : MonoBehaviour
{
    private float time = 0f, t = 0f, finishTime = 10f;
    private int score = 0, combo = 0;
    private Coroutine coroutine = null;
    [SerializeField] private AnimationCurve curve;

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
        print(score);
    }

    public void SubtractScore()
    {
        combo = 0;
        score-= 30;
        print(score);
    }

    private IEnumerator Stop()
    {
        while (Time.timeScale > 0)
        {
            t = Mathf.Clamp01(t + Time.unscaledDeltaTime);
            Time.timeScale = Mathf.Lerp(1, 0, curve.Evaluate(t));
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("Menu minijuegos");
    }
}
