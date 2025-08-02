using System.Globalization;
using TMPro;
using UnityEngine;

public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField] TMP_Text _itemsHeldTextField;
    [SerializeField] TMP_Text _maxItemsHeldTextField;
    [SerializeField] TMP_Text _moneyTextField;
    [SerializeField] TMP_Text _toPayTextField;
    public void SetItemsHeldNum(int num)
    {
        _itemsHeldTextField.text = $"{num}/{PlayerStats.maxHeldItems}";
    }
    public void SetMaxItemsHeldNum(int num)
    {
        _itemsHeldTextField.text = $"{num}/{PlayerStats.maxHeldItems}";
    }
    public void SetMoney(float num)
    {
        _moneyTextField.text = num.ToString("0.00", CultureInfo.InvariantCulture) + " $";
    }
    public void SetToPay(float toPay)
    {
        if (toPay > PlayerStats.currentMoney)
        {
            _toPayTextField.color = Color.red;
        }
        else _toPayTextField.color = Color.white;
        _toPayTextField.text=toPay.ToString("0.00", CultureInfo.InvariantCulture) + " $";
    }
}
