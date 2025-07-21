using Unity.Mathematics;
using UnityEngine;

public class LevelableUpgradeInt : LevelableUpgrade,ISerializationCallbackReceiver
{
    [SerializeField] LevelableUpgradeIntSO _upgrade;
    [SerializeField] LevelableUpgradeLevelUI _upgradeLevellUI;
    private LevelableUpgradeIntSO _upgradeDump;
    public override void BuyUpgrade()
    {
        _upgradeCurrentLevel = _upgradelevelToBuy;
        _upgradeLevellUI.SetUpgradeBuyLevel(_upgradeCurrentLevel);
        UpgradesManager.IncreaseUpgradeLevel(_upgrade.Id, _upgradeCurrentLevel);
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
        if(_upgrade!=null) _upgradeLevellUI.SetUp(_upgrade,$"{_upgrade.PerLevelIncrease}");
    }

    public void OnAfterDeserialize()
    {
        _upgradeDump = _upgrade;
    }

    public void OnBeforeSerialize()
    {
        if (_upgradeDump != default)
        {
            _upgrade = _upgradeDump;
        }
    }
}
