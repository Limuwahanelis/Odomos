using UnityEngine;

public class UpgradesShop : MonoBehaviour
{
    public void LeveleableUpgradeBought(LevelableUpgradeSO upgrade,int level)
    {
        UpgradesManager.IncreaseUpgradeLevel(upgrade.Id, level);
    }
}
