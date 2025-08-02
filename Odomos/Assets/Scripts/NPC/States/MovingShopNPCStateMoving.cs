using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingShopNPCStateMoving : EnemyState
{
    public static Type StateType { get => typeof(MovingShopNPCStateMoving); }
    private MovingShopNPCContext _context;
    private int selectedShelfIndex = 0;
    private float _safetTimer;
    private float _maxMovingTime = 10f;
    public MovingShopNPCStateMoving(GetState function) : base(function)
    {
    }

    public override void Update()
    {
        if(_context.navMeshAgent.remainingDistance<=_context.navMeshAgent.stoppingDistance)
        {
             _context.navMeshAgent.updateRotation = false;
            _context.npc.LookAt(_context.shelfs[selectedShelfIndex].transform);
            ChangeState(MovingShopNPCStateIdle.StateType);
        }
        _safetTimer += Time.deltaTime;
        if(_safetTimer>=_maxMovingTime)
        {
            ChangeState(MovingShopNPCStateIdle.StateType);
            _context.navMeshAgent.isStopped = true;
        }
    }

    public override void SetUpState(ShopNPCContext context)
    {
        base.SetUpState(context);
        _context = (MovingShopNPCContext)context;
        _safetTimer = 0;
        _context.animMan.PlayAnimation("walk");
        selectedShelfIndex = UnityEngine.Random.Range(0, _context.shelfs.Count);
        _context.navMeshAgent.destination = _context.shelfs[selectedShelfIndex].NpcPos.position;
        _context.navMeshAgent.updateRotation = true;
        _context.navMeshAgent.isStopped = false;
    }

    public override void InterruptState()
    {
     
    }
}