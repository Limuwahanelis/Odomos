using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private IInteractable _interactable;
    private IReturnable _returnable;
    private IBuyAmountChangable _buyAmountChangable;

    public void SetShelfToInteract(Shelf shelf)
    {
        _returnable = shelf;
        _interactable = shelf;
        if((shelf as IBuyAmountChangable)!=null)
        {
            _buyAmountChangable = shelf;
        }
    }
    public void RemoveShellfToInteract(Shelf shelf)
    {
        _returnable = null;
        _interactable = null;
        if ((shelf as IBuyAmountChangable) != null)
        {
            _buyAmountChangable = null;
        }
    }
    public void SetReturnable(IReturnable returnable)
    {
        _returnable = returnable;
    }
    public void RemoveReturnable(IReturnable returnable)
    {
        if (_returnable == returnable) _returnable = null;
    }
    public void SetitemToInteract(IInteractable interactable)
    {
        _interactable = interactable;
    }
    public void RemoveItemtoInteract(IInteractable interactable)
    {
        if (_interactable == interactable) _interactable = null;
    }

    public void Interact()
    {
        if (_interactable == null) return;
        _interactable.Interact();
    }
    public void ReturnItem()
    {
        if (_returnable == null) return;
        _returnable.Return();
    }
    public void ChangeBuyAmount(int value)
    {
        if (_buyAmountChangable == null) return;
        _buyAmountChangable.ChangeBuyAmount(value);
    }
}
