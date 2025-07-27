using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class MovingShopNPCStateMoving : EnemyState
{
    public static Type StateType { get => typeof(MovingShopNPCStateMoving); }
    private MovingShopNPCContext _context;
    public MovingShopNPCStateMoving(GetState function) : base(function)
    {
    }

    public override void Update()
    {
        if(_context.navMeshAgent.remainingDistance<=_context.navMeshAgent.stoppingDistance && _context.navMeshAgent.isStopped)
        {
            ChangeState(MovingShopNPCStateIdle.StateType);
        }
    }

    public override void SetUpState(ShopNPCContext context)
    {
        base.SetUpState(context);
        _context = (MovingShopNPCContext)context;
        //_context.animMan.PlayAnimation("walk");
        _context.navMeshAgent.destination = _context.positions[UnityEngine.Random.Range(0, _context.positions.Count)];
    }

    public override void InterruptState()
    {
     
    }
}