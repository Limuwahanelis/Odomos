using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public static Type StateType { get => typeof(PlayerMoveState); }
    public PlayerMoveState(GetState function) : base(function)
    {
    }

    public override void Update()
    {
        PerformInputCommand();
        
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    public override void SetUpState(PlayerContext context)
    {
        base.SetUpState(context);
        _context.animationManager.PlayAnimation("walk");
    }
    public override void Move(Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            ChangeState(PlayerIdleState.StateType);
            return;
        }
        _context.playerMovement.Move(direction);
    }
    public override void Push()
    {
        ChangeState(PlayerPushedState.StateType);
    }
    public override void InterruptState()
    {
     
    }
}