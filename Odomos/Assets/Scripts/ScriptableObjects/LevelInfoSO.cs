using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="LevelInfo")]
public class LevelInfoSO : ScriptableObject
{
    public float FlatLevelBonus { get => _flatLevelBonus;}
    public float RemainingTimeBonus { get => _remainingTimeBonus; }
    public List<float> QuaterBonuses { get => _quaterBonuses;}
    [SerializeField] float _flatLevelBonus;
    [SerializeField] float _remainingTimeBonus;
    [SerializeField] List<float> _quaterBonuses= new List<float>();

    
}