using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class LevelableUpgradeInt : LevelableUpgrade,ISerializationCallbackReceiver
{
    [SerializeField] LevelableUpgradeIntSO _upgrade;
    [SerializeField] LevelableUpgradeLevelUI _upgradeLevellUI;
    private LevelableUpgradeIntSO _upgradeDump;
    float toPay = 0;
    public override void BuyUpgrade()
    {
        if (_upgradeCurrentLevel >= _upgrade.MaxLevel) return;
        if (toPay >= PlayerStats.savedMoney) return;
        _upgradeCurrentLevel = _upgradelevelToBuy;
        _upgradeLevellUI.SetUpgradeBuyLevel(_upgradeCurrentLevel);
        PlayerStats.savedMoney -= toPay;
        OnUpgradeBought?.Invoke(_upgrade, _upgradeCurrentLevel);
        IncreaseLevelToBuy();
    }

    public override void DecreaseLevelToBuy()
    {
        if (_upgradeCurrentLevel >= _upgrade.MaxLevel) return;
        _upgradelevelToBuy--;
        _upgradelevelToBuy = math.clamp(_upgradelevelToBuy, _upgradeCurrentLevel+1, _upgrade.MaxLevel);

        float pay = 0;
        for (int i = _upgradeCurrentLevel + 1; i <= _upgradelevelToBuy; i++)
        {
            pay += i * _upgrade.CostPerLevel;
        }
        toPay = pay;
        _upgradeLevellUI.SetPreviewLevel(_upgradelevelToBuy);
        _upgradeLevellUI.SetPrice(toPay);
    }

    public override void IncreaseLevelToBuy()
    {
        if (_upgradeCurrentLevel >= _upgrade.MaxLevel) return;
        _upgradelevelToBuy++;
        _upgradelevelToBuy = math.clamp(_upgradelevelToBuy, _upgradeCurrentLevel+1, _upgrade.MaxLevel);

        float pay = 0;
        for (int i = _upgradeCurrentLevel + 1; i <= _upgradelevelToBuy; i++)
        {
            pay += i * _upgrade.CostPerLevel;
        }
        toPay = pay;
        _upgradeLevellUI.SetPreviewLevel(_upgradelevelToBuy);
        _upgradeLevellUI.SetPrice(toPay);
    }
    private void Reset()
    {
        if (_upgradeLevellUI == null)
        {
            _upgradeLevellUI = GetComponent<LevelableUpgradeLevelUI>();
        }
        if(_upgrade!=null) _upgradeLevellUI.SetUp(_upgrade,$"{_upgrade.PerLevelIncrease}",_upgradeCurrentLevel);
    }

    public void OnAfterDeserialize()
    {
        if (_upgradeDump != default)
        {
            _upgrade = _upgradeDump;
        }
        
    }

    public void OnBeforeSerialize()
    {
        _upgradeDump = _upgrade;
    }
    public override void GetCurrentUpgradeLevel()
    {
        _upgradeCurrentLevel = UpgradesManager.GetUpgradeLevel(_upgrade.Id);
        _upgradelevelToBuy = _upgradeCurrentLevel + 1;
        if (_upgradeCurrentLevel == _upgrade.MaxLevel) _upgradelevelToBuy = _upgradeCurrentLevel;
        toPay += _upgrade.CostPerLevel * _upgradelevelToBuy;
        _upgradeLevellUI.SetPreviewLevel(_upgradelevelToBuy);
        _upgradeLevellUI.SetUpgradeBuyLevel(_upgradelevelToBuy-1);
        _upgradeLevellUI.SetPrice(toPay);
    }
}
