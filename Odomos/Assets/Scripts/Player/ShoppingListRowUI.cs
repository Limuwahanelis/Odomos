using TMPro;
using UnityEngine;

public class ShoppingListRowUI : MonoBehaviour
{
    [SerializeField] ShoppingListItemUI _shoppingListItemUI;
    [SerializeField] TMP_Text _boughtItemsTextField;
    [SerializeField] TMP_Text _heldItemsTextField;
    [SerializeField] GameObject _crossOutLine;

    public void SetUp(ShoppingListSO.ShoppingListEntry entry)
    {
        _shoppingListItemUI.SetUp(entry);
    }
    public void SetBoughtItemsAmount(int amount)
    {
        _boughtItemsTextField.text = amount.ToString();
    }
    public void SetHeldItemsAmount(int amount)
    {
        _heldItemsTextField.text = amount.ToString();
    }
    public void CrossRowOut()
    {
        _crossOutLine.SetActive(true);
    }
}
