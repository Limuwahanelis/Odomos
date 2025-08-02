using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class NPCManager : MonoBehaviour
{
    [SerializeField] List<Shelf> _shelfs = new List<Shelf>();
    [SerializeField] List<ShopNPCController> _npcs= new List<ShopNPCController>();
    private void Awake()
    {
        if (_npcs == null || _npcs.Count ==0) return;
        
        foreach(ShopNPCController controller in _npcs)
        {
            controller.SetMoveList(_shelfs);
        }
    }
}
