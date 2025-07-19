using UnityEngine;

public class Checkout : MonoBehaviour,IInteractable
{
    [SerializeField] PlayerInventory _playerInventory;

    public void OnPlayerDetected(Collider col)
    {
        PlayerInteractions interactions = col.attachedRigidbody.GetComponent<PlayerInteractions>();
        interactions.SetitemToInteract(this);
    }
    public void OnPlayerLeft(Collider col)
    {
        PlayerInteractions interactions = col.attachedRigidbody.GetComponent<PlayerInteractions>();
        interactions.RemoveItemtoInteract(this);
    }

    public void Interact()
    {
        _playerInventory.BuyItems();
    }
    private void Reset()
    {
        _playerInventory = FindFirstObjectByType<PlayerInventory>();
    }
}
