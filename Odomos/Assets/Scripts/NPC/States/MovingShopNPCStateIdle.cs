using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingShopNPCStateIdle : MovingNPCState
{
    public static Type StateType { get => typeof(MovingShopNPCStateIdle); }
    private MovingShopNPCContext _context;
    private float _animDuration;
    private float _time;
    private int _tries = 4;
    public MovingShopNPCStateIdle(GetState function) : base(function)
    {
    }

    public override void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _animDuration)
        {
            _tries--;
            if (_tries == 0)
            {
                ChangeState(MovingShopNPCStateMoving.StateType);
            }
            else
            {
                int num= UnityEngine.Random.Range(0, _tries);
                if(num == _tries-1)
                {
                    ChangeState(MovingShopNPCStateMoving.StateType);
                }
                else _tries--;
                Logger.Log(_tries);
                _time = 0;
            }
        }
    }

    public override void SetUpState(ShopNPCContext context)
    {
        base.SetUpState(context);
        _context = (MovingShopNPCContext)context;
        _time = 0;
        _tries = 4;
        _context.animMan.PlayAnimation("idle");
        _animDuration = _context.animMan.GetAnimationLength("idle");
    }

    public override void InterruptState()
    {
     
    }
}