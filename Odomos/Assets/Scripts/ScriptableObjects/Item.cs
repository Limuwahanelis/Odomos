using System.Collections;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu(menuName ="Item")]
public class Item : Buyable
{
    
    public ItemCategory ItemCategory { get => _itemCategory; }
    public int InStock { get => _inStock; }
    public string Name { get => _name; }
    public float Price { get => _price; }
    [SerializeField] ItemCategory _itemCategory;
    [SerializeField] int _inStock;
    [SerializeField] string _name;
    [SerializeField] float _price;
    private void Awake()
    {
        _name = name;
    }
#if UNITY_EDITOR
    private void Reset()
    {
        
       _name= Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(this));
    }
#endif
}