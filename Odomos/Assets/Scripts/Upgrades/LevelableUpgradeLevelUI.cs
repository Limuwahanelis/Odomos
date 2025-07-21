using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelableUpgradeLevelUI : MonoBehaviour
{
    [SerializeField] RectTransform _levelImgsParent;
    [SerializeField] TMP_Text _descriptionRextField;
    [SerializeField] LevelablleUpgradeLevelIndicator _levelIndicatorPrefab;
    [SerializeField] List<LevelablleUpgradeLevelIndicator> _levelIndicators= new List<LevelablleUpgradeLevelIndicator>();

    private void Start()
    {
        _levelIndicators.AddRange(_levelImgsParent.GetComponentsInChildren<LevelablleUpgradeLevelIndicator>());
    }
    public void SetPreviewLevel(int previewLevel)
    {
        for(int i=0;i<_levelIndicators.Count;i++)
        {
            if (i < previewLevel) _levelIndicators[i].SetPreviewImage(true);
            else _levelIndicators[i].SetPreviewImage(false);
        }
    }
    public void SetUpgradeBuyLevel(int upgradeLevel)
    {
        for (int i = 0; i < upgradeLevel; i++)
        {
            _levelIndicators[i].SetPreviewImage(false);
            _levelIndicators[i].SetFillImage(true);
        }
    }
    public void SetUp(LevelableUpgradeSO upgradeSO,string upgradableAmount)
    {
        
        _levelIndicators.Clear();
        int indicatorsToSpawn = upgradeSO.MaxLevel- _levelImgsParent.childCount;
        _levelIndicators.AddRange(_levelImgsParent.GetComponentsInChildren<LevelablleUpgradeLevelIndicator>());
        _descriptionRextField.text = $"Upgrades {upgradeSO.UpgradeDescription} by {upgradableAmount} per level";
        for(int i=0;i< indicatorsToSpawn; i ++)
        {
            LevelablleUpgradeLevelIndicator indicator= Instantiate(_levelIndicatorPrefab, _levelImgsParent);
            LayoutRebuilder.ForceRebuildLayoutImmediate(_levelImgsParent);
        }
    }
}
