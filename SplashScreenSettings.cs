using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashScreenSettings : MonoBehaviour
{
    #region Variables
    [Header("Splash Settings")]
    public string NextScene = "MainGame";
    public float FadeDuration = 1.2f;
    public float WaitTime = 2.0f;
    private CanvasGroup _canvasGroup;
    #endregion
    #region Unity Messages
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0f;
    }
    private void Start()
    {
        StartCoroutine(WorkSplash());
    }
    #endregion
    #region Coroutines
    private IEnumerator WorkSplash()
    {
        yield return Fade(0f, 1f);
        yield return new WaitForSeconds(WaitTime);
        yield return Fade(1f, 0f);
        SceneManager.LoadScene(NextScene);
    }
    private IEnumerator Fade(float start, float end)
    {
        float timerFade = 0f;
        while (timerFade < FadeDuration)
        {
            timerFade += Time.deltaTime;
            float alpha = Mathf.Lerp(start, end, timerFade/FadeDuration);
            _canvasGroup.alpha = alpha;
            yield return null;
        }
    }
    #endregion
}
