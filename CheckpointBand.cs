using UnityEngine;

public class CheckpointBand : MonoBehaviour
{
    #region Variables
    public Transform CheckpointPosition;
    #endregion
    #region Methods
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = CheckpointPosition.position;
    }
    #endregion
}
