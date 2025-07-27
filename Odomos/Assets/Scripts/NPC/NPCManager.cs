using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] List<Shelf> _shelfs = new List<Shelf>();
    [SerializeField] List<ShopNPCController> _npcs= new List<ShopNPCController>();
    private void Awake()
    {
        List<Vector3> posList = _shelfs.Select(x=>x.NpcPos.position).ToList();
        foreach(ShopNPCController controller in _npcs)
        {
            controller.SetMoveList(posList);
        }
    }
}
