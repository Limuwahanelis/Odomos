using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static PlayerInventory;
using static UnityEngine.Rendering.DebugUI.Table;

public class ShoppingListUI : MonoBehaviour
{
    private class RowUIWithToBuyAssociation
    {
        public Buyable buyable;
        public ShoppingListRowUI rowUI;
    }
    List<RowUIWithToBuyAssociation> _rowAsscoiations = new List<RowUIWithToBuyAssociation>();
    [SerializeField] RectTransform _shoppingListEntryParent;
    [SerializeField] ShoppingListRowUI _shoppingListItemUiPrefab;

    public void SetUp(ShoppingListSO shoppingList)
    {
        for (int i = _shoppingListEntryParent.childCount - 1; i >= 0; i--)
        {
            Destroy(_shoppingListEntryParent.GetChild(i).gameObject);
        }

        foreach (ShoppingListSO.ShoppingListEntry entry in shoppingList.ToBuy)
        {
            ShoppingListRowUI instance = Instantiate(_shoppingListItemUiPrefab, _shoppingListEntryParent);
            instance.SetUp(entry);
            _rowAsscoiations.Add(new RowUIWithToBuyAssociation() { rowUI = instance, buyable = entry.toBuy });
        }
    }
    public void SetHeldItemAmount(Item item,int amount)
    {
        RowUIWithToBuyAssociation itemAssociation = _rowAsscoiations.Find(x => x.buyable == item);
        if(itemAssociation!=null)itemAssociation.rowUI.SetHeldItemsAmount(amount);
    }
    public void SetHeldItemCategoryAmount(ItemCategory itemCategory, int amount)
    {
        RowUIWithToBuyAssociation categorAssociation = _rowAsscoiations.Find(x => x.buyable == itemCategory);
        if(categorAssociation!=null)
        {
            categorAssociation.rowUI.SetHeldItemsAmount(amount);
        }
    }
    public void SetBoughtItemsAmounts(List<ItemInInventory> items)
    {
        foreach (ItemInInventory item in items)
        {
            RowUIWithToBuyAssociation itemAssociation = _rowAsscoiations.Find(x => x.buyable == item.item);
            if(itemAssociation!=null) itemAssociation.rowUI.SetBoughtItemsAmount(item.amount);
        }
        List<ItemCategory> categories = items.DistinctBy(x => x.item.ItemCategory).Select(x => x.item.ItemCategory).ToList();
        foreach(ItemCategory cat in categories)
        {
            RowUIWithToBuyAssociation categoryAssociation = _rowAsscoiations.Find(x => x.buyable == cat);
            if (categoryAssociation != null)
            {
                categoryAssociation.rowUI.SetBoughtItemsAmount( items.FindAll(x => x.item.ItemCategory == cat).Sum(x => x.amount));
            }

        }
    }
    public void CrossItemOut(Buyable buyable)
    {
        RowUIWithToBuyAssociation buyableAssociation = _rowAsscoiations.Find(x => x.buyable == buyable);
        if (buyableAssociation != null) buyableAssociation.rowUI.CrossRowOut();
    }
}
