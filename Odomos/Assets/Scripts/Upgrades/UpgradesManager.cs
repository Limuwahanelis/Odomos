using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    public class NonLevelableUpgradeData
    {
        public string id;
        public bool isUnlocked;
    }
    public class LevelableUpgradeData
    {
        public string id;
        public int level;
    }
    public class UpgradeData
    {
        public string id;
        public bool isUnlocked;
    }
    public static List<LevelableUpgradeData> LevelableUpgradeDatas
    {
        get
        {
            if (_levelableUpgradeDatas == null)
            {
                _levelableUpgradeDatas = new List<LevelableUpgradeData>();
                List<LevelableUpgradeSO> tmp= Resources.LoadAll<LevelableUpgradeSO>($"{ScriptPaths.ResourcesLevelableUpgradesPath}/").ToList();
                foreach (LevelableUpgradeSO upgrade in tmp)
                {
                    _levelableUpgradeDatas.Add(new LevelableUpgradeData() { id = upgrade.Id, level=0 });
                }
            }
            return _levelableUpgradeDatas;
        }
    }
    public static List<NonLevelableUpgradeData> NonLevelableUpgradeDatas
    {
        get
        {
            if (_nonLevelableUpgradeDatas == null)
            {
                _nonLevelableUpgradeDatas = new List<NonLevelableUpgradeData>();
                List<LevelableUpgradeSO> tmp = Resources.LoadAll<LevelableUpgradeSO>($"{ScriptPaths.ResourcesNonLevelableUpgradesPath}/").ToList();
                foreach (LevelableUpgradeSO upgrade in tmp)
                {
                    _nonLevelableUpgradeDatas.Add(new NonLevelableUpgradeData() { id = upgrade.Id, isUnlocked = false });
                }
            }
            return _nonLevelableUpgradeDatas;
        }
    }
    private static List<LevelableUpgradeData> _levelableUpgradeDatas;
    private static List<NonLevelableUpgradeData> _nonLevelableUpgradeDatas;
    public static List<UpgradeData> UpgradeDatas;

    public static void IncreaseUpgradeLevel(string id,int level)
    {
        LevelableUpgradeDatas.Find(x => x.id == id).level = level;
    }
    public static int GetUpgradeLevel(string id)
    {
        return LevelableUpgradeDatas.Find(x => x.id == id).level;
    }
    public static void UnlockUpgrade(string id)
    {
        NonLevelableUpgradeDatas.Find(x=>x.id == id).isUnlocked = true;
    }

}
