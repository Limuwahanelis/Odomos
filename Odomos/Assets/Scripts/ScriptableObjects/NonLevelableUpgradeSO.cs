using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/NonLevelable Upgrade")]
public class NonLevelableUpgradeSO : UpgradeSO
{
    public string UpgradeDescription { get => _upgradeDescription; }
    public float Cost { get => _cost;  }

    [SerializeField] string _upgradeDescription;
    [SerializeField] float _cost;

}