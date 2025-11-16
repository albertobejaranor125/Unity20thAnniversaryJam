using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateCreditsScreen : MonoBehaviour
{
    #region Variables
    public string CreditsSceneName = "CreditsScreen";
    #endregion
    #region Methods
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(CreditsSceneName);
    }
    #endregion
}
