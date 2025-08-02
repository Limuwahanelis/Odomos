using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] GameEventSO _stopTime;
    [SerializeField] PlayerController _player;
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] InputActionAsset _controls;
    [SerializeField] bool _useCommands;
    [SerializeField] PlayerInputStack _inputStack;
    [SerializeField] GameEventSO _pauseEvent;
    private Vector2 _direction;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if (!PauseSettings.IsGamePaused)
        {
            _player.CurrentPlayerState.Move(_direction);

        }
    }
    // Update is called once per frame
    void Update()
    {
        //if (_player.IsAlive)
        //{


        //}
    }
    private void OnMove(InputValue value)
    {
        _direction = value.Get<Vector2>();
        Logger.Log(_direction);
    }
    void OnJump(InputValue value)
    {
        if (PauseSettings.IsGamePaused) return;
        if (_useCommands) _inputStack.CurrentCommand= new JumpInputCommand(_player.CurrentPlayerState);
        else _player.CurrentPlayerState.Jump();

    }
    void OnVertical(InputValue value)
    {
        _direction = value.Get<Vector2>();
    }
    private void OnCancel()
    {
        _pauseEvent.Raise();
    }
    private void OnInteract(InputValue value)
    {
        _player.Interact();
    }
    private void OnReturn(InputValue value)
    {
        _player.ReturnItem();
    }
    private void OnSprint(InputValue value)
    {
        _playerMovement.SetSprint(value.Get<float>() > 0);
    }
    private void OnChangeBuyAmount(InputValue value)
    {
        int amount = (int)value.Get<float>();
        _player.ChangeBuyAmount(amount);
    }
    private void OnStopTime(InputValue value)
    {
       _player.StopTime();
    }
    private void OnAttack(InputValue value)
    {
        if (PauseSettings.IsGamePaused) return;
        if (_useCommands)
        {
            _inputStack.CurrentCommand = new AttackInputCommand(_player.CurrentPlayerState);
            if (_direction.y > 0) _inputStack.CurrentCommand = new AttackInputCommand(_player.CurrentPlayerState, PlayerCombat.AttackModifiers.UP_ARROW);
            if (_direction.y < 0) _inputStack.CurrentCommand = new AttackInputCommand(_player.CurrentPlayerState, PlayerCombat.AttackModifiers.DOWN_ARROW);
        }
        else
        {
            
            if(_direction.y==0) _player.CurrentPlayerState.Attack();
            else if (_direction.y > 0) _player.CurrentPlayerState.Attack(PlayerCombat.AttackModifiers.UP_ARROW);
            else if (_direction.y < 0) _player.CurrentPlayerState.Attack(PlayerCombat.AttackModifiers.DOWN_ARROW);
        }
    }
}
