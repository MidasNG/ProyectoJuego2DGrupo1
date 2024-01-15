using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingEnd : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private bool skippable = false;
    private TextMeshProUGUI text;
    private float t = 0;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.color = new Color(0, 0, 0, 0);
        StartCoroutine(ColorAnim());
    }

    private void Update()
    {
        if (skippable && Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private IEnumerator ColorAnim()
    {
        yield return new WaitForSeconds(2);
        skippable = true;
        while (t < 1)
        {
            t += Time.deltaTime;
            text.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, t));
            yield return new WaitForEndOfFrame();
        }
    }
}
