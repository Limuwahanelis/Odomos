using UnityEngine;
using UnityEngine.Events;

public class TriggerDetection : MonoBehaviour
{
    public UnityEvent OnColliderDetected;
    public UnityEvent<Collider> OnColliderDetectedCol;
    public UnityEvent OnColliderLeft;
    public UnityEvent<Collider> OnColliderLeftCol;
    [SerializeField] Collider _colliderToDetect;
    [SerializeField] bool _checkForSpecificCollider;
    [SerializeField] bool _disableDetectedGameObjectOnDetection;

    private void OnTriggerEnter(Collider other)
    {
        if (_checkForSpecificCollider)
        {
            if (other == _colliderToDetect)
            {
                if (_disableDetectedGameObjectOnDetection) other.gameObject.SetActive(false);
                OnColliderDetected?.Invoke();
                OnColliderDetectedCol?.Invoke(other);
            }
        }
        OnColliderDetected?.Invoke();
        OnColliderDetectedCol?.Invoke(other);
    }
    private void OnTriggerExit(Collider other)
    {
        if (_checkForSpecificCollider)
        {
            if (other == _colliderToDetect)
            {
                if (_disableDetectedGameObjectOnDetection) other.gameObject.SetActive(false);
                OnColliderLeft?.Invoke();
                OnColliderLeftCol?.Invoke(other);
            }
        }
        OnColliderLeft?.Invoke();
        OnColliderLeftCol?.Invoke(other);
    }
}
