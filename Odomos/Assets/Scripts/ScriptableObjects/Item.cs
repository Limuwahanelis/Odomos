using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Item")]
public class Item : ScriptableObject
{
    public ItemCategory ItemCategory { get => _itemCategory; }
    public int InStock { get => _inStock; }
    public string Name { get => _name; }
    public float Price { get => _price; }
    [SerializeField] ItemCategory _itemCategory;
    [SerializeField] int _inStock;
    [SerializeField] string _name;
    [SerializeField] float _price;

}