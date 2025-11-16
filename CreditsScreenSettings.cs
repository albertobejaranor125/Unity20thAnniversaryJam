using UnityEditor;
using UnityEngine;

public class CreditsScreenSettings : MonoBehaviour
{
    #region Variables
    [Header("Duration Settings")]
    public float CreditsDuration = 10f;
    private float _timerCredits;
    #endregion
    #region Unity Messages
    void Start()
    {
        _timerCredits = 0f;
    }
    void Update()
    {
        _timerCredits += Time.deltaTime;
        Debug.Log("Timer Credtis: " + _timerCredits);
        if (_timerCredits >= CreditsDuration)
        {
            ExitGame();
        }
    }
    #endregion
    #region Methods
    private void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    #endregion
}
