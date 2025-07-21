using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public abstract class LevelableUpgrade : MonoBehaviour
{
    public UnityEvent<LevelableUpgradeSO, int> OnUpgradeBought;

    protected int _upgradelevelToBuy=0;
    protected int _upgradeCurrentLevel = 0;
    public abstract void IncreaseLevelToBuy();
    public abstract void DecreaseLevelToBuy();
    public abstract void BuyUpgrade();

}
