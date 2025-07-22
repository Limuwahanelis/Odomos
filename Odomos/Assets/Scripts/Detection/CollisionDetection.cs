using UnityEngine;
using UnityEngine.Events;

public class CollisionDetection : MonoBehaviour
{
    public UnityEvent OnColliderDetected;
    public UnityEvent<Collider> OnColliderDetectedCol;
    [SerializeField] Collider _colliderToDetect;
    [SerializeField] bool _checkForSpecificCollider;
    [SerializeField] bool _disableDetectedGameObjectOnDetection;

    private void OnCollisionEnter(Collision collision)
    {
        if (_checkForSpecificCollider)
        {
            if (collision.collider == _colliderToDetect)
            {
                if (_disableDetectedGameObjectOnDetection) collision.collider.gameObject.SetActive(false);
                OnColliderDetected?.Invoke();
                OnColliderDetectedCol?.Invoke(collision.collider);
            }
        }
        OnColliderDetected?.Invoke();
        OnColliderDetectedCol?.Invoke(collision.collider);
    }
}
