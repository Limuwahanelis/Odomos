using System;
using UnityEngine;

public abstract class ShopNPCContext
{
    public Action<EnemyState> ChangeEnemyState;
    public AnimationManager animMan;
    public Transform npc;
}
