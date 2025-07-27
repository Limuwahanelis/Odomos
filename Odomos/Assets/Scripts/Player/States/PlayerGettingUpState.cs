using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGettingUpState : PlayerState
{
    private float _time;
    private float _animDuration;
    public static Type StateType { get => typeof(PlayerGettingUpState); }
    public PlayerGettingUpState(GetState function) : base(function)
    {
    }

    public override void Update()
    {
        PerformInputCommand();
        _time += Time.deltaTime;
        if(_time>=_animDuration)
        {
            ChangeState(PlayerIdleState.StateType);
            
        }
    }

    public override void SetUpState(PlayerContext context)
    {
        base.SetUpState(context);
        _animDuration = _context.animationManager.GetAnimationLength("get up");
        _context.animationManager.PlayAnimation("get up");
        _time = 0;
    }

    public override void InterruptState()
    {
     
    }
}