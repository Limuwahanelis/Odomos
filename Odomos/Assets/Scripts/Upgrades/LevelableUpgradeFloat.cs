using Unity.Mathematics;
using UnityEngine;

public class LevelableUpgradeFloat : LevelableUpgrade,ISerializationCallbackReceiver
{
    [SerializeField] LevelableUpgradeFloatSO _upgrade;
    [SerializeField] LevelableUpgradeLevelUI _upgradeLevellUI;
    private LevelableUpgradeFloatSO _upgradeDump;
    public override void BuyUpgrade()
    {
        _upgradeCurrentLevel = _upgradelevelToBuy;
        _upgradeLevellUI.SetUpgradeBuyLevel(_upgradeCurrentLevel);
        UpgradesManager.IncreaseUpgradeLevel(_upgrade.Id, _upgradeCurrentLevel);
        OnUpgradeBought?.Invoke(_upgrade,_upgradeCurrentLevel);
    }

    public override void DecreaseLevelToBuy()
    {
        _upgradelevelToBuy--;
        _upgradelevelToBuy = math.clamp(_upgradelevelToBuy, _upgradeCurrentLevel, _upgrade.MaxLevel);
        _upgradeLevellUI.SetPreviewLevel(_upgradelevelToBuy);
    }

    public override void IncreaseLevelToBuy()
    {
        _upgradelevelToBuy++;
        _upgradelevelToBuy = math.clamp(_upgradelevelToBuy, _upgradeCurrentLevel, _upgrade.MaxLevel);
        _upgradeLevellUI.SetPreviewLevel(_upgradelevelToBuy);
    }
    private void Reset()
    {
        if (_upgradeLevellUI == null)
        {
            _upgradeLevellUI = GetComponent<LevelableUpgradeLevelUI>();
        }
        if (_upgrade != null) _upgradeLevellUI.SetUp(_upgrade,$"{_upgrade.PerLevelIncrease*100}%");
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
}
