using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class UpgradesShop : MonoBehaviour
{
    [SerializeField]List<LevelableUpgrade> _levelableUpgrades;
    [SerializeField] TMP_Text _playerMoneyTextField;
    private void OnEnable()
    {
        _playerMoneyTextField.text = PlayerStats.savedMoney.ToString("0.00", CultureInfo.InvariantCulture) + " $";
    }
    public void LeveleableUpgradeBought(LevelableUpgradeSO upgrade,int level)
    {
        UpgradesManager.IncreaseUpgradeLevel(upgrade.Id, level);
        _playerMoneyTextField.text = PlayerStats.savedMoney.ToString("0.00", CultureInfo.InvariantCulture) + " $";
    }
    private void Start()
    {
        foreach (var upgrade in _levelableUpgrades)
        {
            upgrade.GetCurrentUpgradeLevel();
        }
    }
}
