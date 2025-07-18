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
    }
    public override void Move(Vector2 direction)
    {
        _context.playerMovement.Move(direction);
    }
    public override void InterruptState()
    {
     
    }
}