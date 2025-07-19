using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ShoppingList")]
public class ShoppingListSO : ScriptableObject
{
    [Serializable]
    public class ShoppingListEntry
    {
        public Buyable toBuy;
        public int amount;
    }

    public List<ShoppingListEntry> ToBuy { get => _toBuy; }

    [SerializeField] List<ShoppingListEntry> _toBuy;


}