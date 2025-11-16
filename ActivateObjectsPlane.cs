using UnityEngine;

public class ActivateObjectsPlane : MonoBehaviour
{
    #region Variables
    public GameObject ObjectsPlane;
    #endregion
    #region Methods
    private void OnTriggerEnter(Collider other)
    {
        ObjectsPlane.SetActive(true);
    }
    #endregion
}
