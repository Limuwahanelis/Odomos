using TMPro;
using UnityEngine;

public class ItemDescription : MonoBehaviour
{
    [SerializeField] TMP_Text _itemNameTextField;
    [SerializeField] TMP_Text _itemPriceTextField;
    [SerializeField] TMP_Text _itemCategoryNameTextField;
    [SerializeField] TMP_Text _itemInStockTextField;
    [SerializeField] TMP_Text _itemToTakeTextField;

    public void SetUp(Item _item,int amount)
    {
        _itemNameTextField.text = _item.Name;
        _itemCategoryNameTextField.text = _item.ItemCategory.name;
        _itemPriceTextField.text = _item.Price.ToString(System.Globalization.CultureInfo.InvariantCulture);
        _itemInStockTextField.text = amount.ToString();
        _itemToTakeTextField.text = 1.ToString();
    }

    public void Refresh(Shelf.ItemInfo itemInfo)
    {
        _itemInStockTextField.text= itemInfo.inStock.ToString();
        _itemToTakeTextField.text = itemInfo.toTake.ToString();
        
    }
}
