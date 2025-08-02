using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static PlayerInventory;

public class ShoppingList : MonoBehaviour
{
    [SerializeField] ShoppingListSO _shoppingList;
    [SerializeField] ShoppingListUI _shoppingListUI;
    [SerializeField] NonLevelableUpgradeSO _OneLessItemShoppingList;
    int _numberOfItemsOnTheList;
    int _numberOfCompletedItems=0;
    public UnityEvent<Item, int> OnItemAmountChanged;
    public UnityEvent<ItemCategory, int> OnItemCategoryAmountChanged;
    public UnityEvent<List<ItemInInventory>> OnitemsBought;
    public UnityEvent<Item> OnEnoughItemsBought;
    public UnityEvent<ItemCategory> OnEnoughItemsOfCategoryBought;
    public UnityEvent OnShoppingListCompleted;
    private void Awake()
    {
        _shoppingListUI.SetUp(_shoppingList);
        _numberOfItemsOnTheList = _shoppingList.ToBuy.Count();
    }
    public void UpdateItem(Item item,int amount)
    {
        OnItemAmountChanged?.Invoke(item,amount);
       
    }
    public void UpdateItemCategory(ItemCategory itemCategory, int amount)
    {
        OnItemCategoryAmountChanged?.Invoke(itemCategory, amount);
    }
    public void UpdateBoughtItems(List<ItemInInventory> boughtItems)
    {
        OnitemsBought?.Invoke(boughtItems);
        
        foreach(ItemInInventory itemInInventory in boughtItems)
        {
            ShoppingListSO.ShoppingListEntry entry = _shoppingList.ToBuy.Find(x => x.toBuy == itemInInventory.item);
            if (entry != null)
            {
                if (itemInInventory.amount >= entry.amount)
                {
                    OnEnoughItemsBought?.Invoke(itemInInventory.item);
                    _numberOfCompletedItems++;
                }
            }
        }

        List<ItemCategory> categories = boughtItems.DistinctBy(x => x.item.ItemCategory).Select(x => x.item.ItemCategory).ToList();
        List<int> amounts = new List<int>();
        foreach(ItemCategory cat in categories)
        {
            amounts.Add(boughtItems.FindAll(x => x.item.ItemCategory == cat).Select(x => x.amount).Sum());
        }
        for(int i=0;i<amounts.Count;i++)
        {
            ShoppingListSO.ShoppingListEntry entry = _shoppingList.ToBuy.Find(x => x.toBuy == categories[i]);
            if (entry!=null)
            {
                if (amounts[i] >= entry.amount)
                {
                    OnEnoughItemsOfCategoryBought?.Invoke(categories[i]);
                    _numberOfCompletedItems++;
                }
            }
        }
        if(_numberOfCompletedItems== (UpgradesManager.GetUpgradeStatus(_OneLessItemShoppingList.Id)?_numberOfItemsOnTheList-1: _numberOfItemsOnTheList))
        {
            OnShoppingListCompleted?.Invoke();
        }
        _numberOfCompletedItems = 0;
    }
}
