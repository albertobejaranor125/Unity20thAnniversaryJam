using UnityEngine;

public class ConfettiSettings : MonoBehaviour
{
    #region Variables
    public ParticleSystem ConfettiParticle;
    private bool _isInstantiated;
    #endregion
    #region Unity Messages
    void Start()
    {
        _isInstantiated = false;
    }
    #endregion
    #region Methods
    private void OnTriggerEnter(Collider other)
    {
        if (_isInstantiated) return;
        if (!_isInstantiated)
        {
            Instantiate(ConfettiParticle, ConfettiParticle.transform.position, 
                ConfettiParticle.transform.rotation);
            _isInstantiated = true;
        }
    }
    #endregion
}
