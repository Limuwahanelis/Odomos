using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UpgradesShop : MonoBehaviour
{
   
    [SerializeField]List<LevelableUpgrade> _levelableUpgrades;
    [SerializeField] List<NonLevelableUpgrade> _nonLevelableUpgrades;
    [SerializeField] TMP_Text _playerMoneyTextField;
    private void OnEnable()
    {
        PlayerStats.savedMoney = PlayerStats.savedMoneyAtLevelStart;
        //PlayerStats.savedMoney = 4f;
        UpgradesManager.SetLevelAtStart();
        UpgradesManager.SetUnlockAtStart();
       
        _playerMoneyTextField.text = PlayerStats.savedMoney.ToString("0.00", CultureInfo.InvariantCulture) + " $";
    }
    public void LeveleableUpgradeBought(LevelableUpgradeSO upgrade,int level)
    {
        UpgradesManager.IncreaseUpgradeLevel(upgrade.Id, level);
        _playerMoneyTextField.text = PlayerStats.savedMoney.ToString("0.00", CultureInfo.InvariantCulture) + " $";
    }
    public void NonLevelableUpgradeBought(NonLevelableUpgradeSO upgrade)
    {

        UpgradesManager.UnlockUpgrade(upgrade.Id);
        _playerMoneyTextField.text = PlayerStats.savedMoney.ToString("0.00", CultureInfo.InvariantCulture) + " $";
    }
    public void ResetUpgradesLevel()
    {
        UpgradesManager.ResetLevelAtStart();
        UpgradesManager.ReSetUnlockAtStart();
    }
    private void Start()
    {
        foreach (var upgrade in _levelableUpgrades)
        {
            upgrade.GetCurrentUpgradeLevel();
        }
        foreach (var upgrade in _nonLevelableUpgrades)
        {
            upgrade.CheckStatus();
        }
    }
}
