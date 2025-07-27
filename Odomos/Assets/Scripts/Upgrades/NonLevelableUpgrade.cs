using UnityEngine;
using UnityEngine.Events;

public class NonLevelableUpgrade : MonoBehaviour
{
    public UnityEvent<UpgradeSO> OnUpgradeBought;
    [SerializeField] NonLevelableUpgradeSO _upgrade;
    private NonLevelableUpgradeSO _upgradeDump;
    public  void BuyUpgrade()
    {
        if (_upgrade.Cost >= PlayerStats.savedMoney) return;
        UpgradesManager.UnlockUpgrade(_upgrade.Id);
        OnUpgradeBought?.Invoke(_upgrade);
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
