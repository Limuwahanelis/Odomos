using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Shelf : MonoBehaviour,IInteractable,IReturnable,IBuyAmountChangable
{
    public class ItemInfo
    {
        public int inStock;
        public int toTake=1;
    }
    [SerializeField] Animator _anim;
    [SerializeField] AnimationManager _animMan;
    [SerializeField] Canvas _canvas;
    [SerializeField] Item _item;
    [SerializeField] ItemDescription _description;
    [SerializeField] PlayerInventory _playerInventory;
    private ItemInfo _itemInfo;
    private Coroutine _timerCor = null;
    private void Awake()
    {
        _description.SetUp(_item);
        _itemInfo = new ItemInfo() {inStock=_item.InStock };
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region player detection
    public void SetPlayerInteraction(Collider col)
    {
        PlayerInteractions playerInteractions= col.attachedRigidbody.GetComponent<PlayerInteractions>();
        playerInteractions.SetShelfToInteract(this);
    }
    public void RemovePlayerInteraction(Collider col)
    {
        PlayerInteractions playerInteractions = col.attachedRigidbody.GetComponent<PlayerInteractions>();
        playerInteractions.RemoveShellfToInteract(this);
    }
    public void OnPlayerDetected()
    {
        _canvas.enabled = true;
        _anim.enabled = true;
        _anim.SetTrigger("open");
        if (_timerCor != null)
        {
            StopCoroutine(_timerCor);
            _timerCor = null;
        }
    }

    public void OnPlayerLeft()
    {
        _anim.SetTrigger("close");
        _timerCor=StartCoroutine(HelperClass.DelayedFunction(_animMan.GetAnimationLength("close") + 0.01f, () =>
        { 
            _anim.enabled = false; 
            _canvas.enabled = false; 
        }));
    }
    #endregion

    #region interactions
    public void ChangeBuyAmount(int value)
    {
        _itemInfo.toTake += value;
        _itemInfo.toTake = math.clamp(_itemInfo.toTake, 0, 99);
        _description.Refresh(_itemInfo);
    }
    public void ChangeAmountToreturn(int amount)
    {
        _itemInfo.toTake += amount;
        _description.Refresh(_itemInfo);
    }

    public void Interact()
    {
        if (_itemInfo.inStock == 0) return;
        int toTakeAmount = math.clamp(_itemInfo.toTake, 1, _itemInfo.inStock);
        _playerInventory.Additem(_item, toTakeAmount);

        _itemInfo.inStock-= toTakeAmount;
        _description.Refresh(_itemInfo);
    }

    public void Return()
    {
        if(_playerInventory.ChekItem(_item))
        {
            _itemInfo.inStock+=_playerInventory.GetItemAmountIninventory(_item);
            _playerInventory.TakeItem(_item);
        }
        _description.Refresh(_itemInfo);
    }
    #endregion

    private void Reset()
    {
        _playerInventory = FindFirstObjectByType<PlayerInventory>();
    }


}
