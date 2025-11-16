using UnityEngine;

public class Audio3DController : MonoBehaviour
{
    #region Variables
    public Transform Player;
    public float MaxDistance = 15f;
    public float MinDistance = 2f;
    private AudioSource _audioSource;
    #endregion

    #region Unity Messages
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if(Player == null && Camera.main != null)
        {
            Player = Camera.main.transform;
        }
        _audioSource.maxDistance = MaxDistance;
        _audioSource.minDistance = MinDistance;
    }
    void Update()
    {
        if (Player == null) return;
        float distanceBetweenObjectAndPlayer = Vector3.Distance(transform.position, Player.transform.position);
        float volumeControl = Mathf.InverseLerp(_audioSource.maxDistance, _audioSource.minDistance, distanceBetweenObjectAndPlayer);
        _audioSource.volume = volumeControl;
    }
    #endregion
}
