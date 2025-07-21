using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelableUpgradeSO : UpgradeSO
{
    public int MaxLevel { get => _maxLevel;  }
    public float CostPerLevel { get => _costPerLevel;  }
    public string UpgradeDescription { get => _upgradeDescription;}

    [SerializeField] int _maxLevel;
    [SerializeField] float _costPerLevel;
    [SerializeField] string _upgradeDescription;

    
}