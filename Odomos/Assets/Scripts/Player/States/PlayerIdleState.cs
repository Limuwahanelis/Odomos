using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public static Type StateType { get => typeof(PlayerIdleState); }
    public PlayerIdleState(GetState function) : base(function)
    {
    }

    public override void Update()
    {
        PerformInputCommand();
    }

    public override void SetUpState(PlayerContext context)
    {
        base.SetUpState(context);
        _context.animationManager.PlayAnimation("idle");
        _context.playerMovement.Stop();
        _context.pushComponent.SetCanBePushed(true);
    }
    public override void Move(Vector2 direction)
    {
        if (direction == Vector2.zero) return;
        ChangeState(PlayerMoveState.StateType);
    }
    public override void InterruptState()
    {
     
    }
}