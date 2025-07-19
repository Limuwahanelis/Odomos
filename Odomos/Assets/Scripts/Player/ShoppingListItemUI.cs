using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingListItemUI : MonoBehaviour
{
    [SerializeField] TMP_Text _itemNameTextField;
    [SerializeField] TMP_Text _itemAmountTextField;

    public void SetUp(ShoppingListSO.ShoppingListEntry entry)
    {
        _itemNameTextField.text = $"{entry.toBuy.name}:";
        _itemAmountTextField.text = entry.amount.ToString();
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
}
