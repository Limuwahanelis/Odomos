using UnityEngine;

public class PushEmitter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Push(Collider col)
    {
        col.attachedRigidbody.gameObject.GetComponent<PlayerPushComponent>().Push(new PushInfo(transform.position));
    }
}
