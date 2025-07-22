using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPushedState : PlayerState
{
    public static Type StateType { get => typeof(PlayerPushedState); }
    private float _time = 0;
    private float _animDuration;
    public PlayerPushedState(GetState function) : base(function)
    {
    }

    public override void Update()
    {
        PerformInputCommand();
        _time += Time.deltaTime;
        if(_time>=_animDuration)
        {
            ChangeState(PlayerGettingUpState.StateType);
        }
    }

    public override void SetUpState(PlayerContext context)
    {
        base.SetUpState(context);
        _context.animationManager.PlayAnimation("die");
        _animDuration = _context.animationManager.GetAnimationLength("die");
        _time = 0;
    }
    public override void Push()
    {
        
    }
    public override void InterruptState()
    {
     
    }
}