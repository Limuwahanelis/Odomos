using UnityEngine;

public abstract class MovingNPCState : EnemyState
{
    protected MovingNPCState(GetState function) : base(function)
    {
    }
}
