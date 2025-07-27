using System.Globalization;
using TMPro;
using UnityEngine;

public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField] TMP_Text _itemsHeldTextField;
    [SerializeField] TMP_Text _moneyTextField;

    public void SetItemsHeldNum(int num)
    {
        _itemsHeldTextField.text =$"{num}/{PlayerStats.maxHeldItems}" ;
    }
    public void SetMoney(float num)
    {
        _moneyTextField.text = num.ToString("0.00",CultureInfo.InvariantCulture)+" $";
    }
}
