using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using static PlayerInventory;

public class PlayerInventory : MonoBehaviour
{

    [Serializable]
    public class ItemInInventory
    {
        public Item item;
        public int amount;
    }

    private float money = 1.00f;
    private float toPay=0f;
    [SerializeField] ShoppingList _shoppingList;
    [SerializeField]private List<ItemInInventory> _itemsInInventory;
    [SerializeField] private List<ItemInInventory> _itemsBought;
    public void Additem(Item item,int amount)
    {
        ItemInInventory itemInInventory = _itemsInInventory.Find(x => x.item == item);
        if (itemInInventory == null)
        {
            itemInInventory = new ItemInInventory() { item = item, amount = amount };
            _itemsInInventory.Add(itemInInventory);
        }
        else
        {
            itemInInventory.amount+= amount;
        }
        _shoppingList.UpdateItem(itemInInventory.item, itemInInventory.amount);
        _shoppingList.UpdateItemCategory(itemInInventory.item.ItemCategory,GetAmountOfItemsInCategory(itemInInventory.item.ItemCategory));
        toPay = _itemsInInventory.Sum(x => x.amount*x.item.Price);
    }
    public void TakeItem(Item item)
    {
        ItemInInventory itemInInventory = _itemsInInventory.Find(x => x.item == item);
        if (itemInInventory == null)
        {
            Logger.Error($"Item to be removed {item.Name} from invenory is not in it!");
        }
        else
        {
            itemInInventory.amount -= itemInInventory.amount;
            _itemsInInventory.Remove(itemInInventory);
        }
        _shoppingList.UpdateItem(itemInInventory.item, itemInInventory.amount);
        _shoppingList.UpdateItemCategory(itemInInventory.item.ItemCategory, GetAmountOfItemsInCategory(itemInInventory.item.ItemCategory));
        toPay = _itemsInInventory.Sum(x => x.amount * x.item.Price);
    }
    public void BuyItems()
    {
        if(money>=toPay)
        {
            foreach (ItemInInventory item in _itemsInInventory)
            {
                ItemInInventory tmp = _itemsBought.Find(x => x.item == item.item);
                if (tmp == null) _itemsBought.Add(item);
                else tmp.amount += item.amount;
                _shoppingList.UpdateItem(item.item, 0);
                _shoppingList.UpdateItemCategory(item.item.ItemCategory, 0);
            }
            
            _shoppingList.UpdateBoughtItems(_itemsBought);
            _itemsInInventory.Clear();
        }
    }
    public bool ChekItem(Item item)
    {
        return _itemsInInventory.Find(x => x.item == item) != null;
    }
    public int GetItemAmountIninventory(Item item)
    {
        return _itemsInInventory.Find(x => x.item == item).amount;
    }
    public int GetAmountOfItemsInCategory(ItemCategory category)
    {
        return _itemsInInventory.FindAll(x => x.item.ItemCategory == category).Sum(x => x.amount);
    }
}
