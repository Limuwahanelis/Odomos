using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovingShopNPCContext : ShopNPCContext
{
    public NavMeshAgent navMeshAgent;
    public List<Vector3> positions;
}
