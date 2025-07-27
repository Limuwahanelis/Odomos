using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool IsPlayerFalling { get => _rb.linearVelocity.y < 0; }
    public Rigidbody PlayerRB => _rb;
    [Header("Common")]
    [SerializeField] Rigidbody _rb;
    [SerializeField] Transform _mainBody;
    [SerializeField] PlayerController _player;
    [SerializeField] float _normalGravityForce;
    [SerializeField] float _speed;
    [SerializeField] float _sprintSpeedIncrease;
    private bool _isSprinting;
    public void IncreaseSpeed(float pct)
    {
        _speed *= (1 + pct);
    }
    public void Stop()
    {
        _rb.linearVelocity = Vector3.zero;
    }
    public void Move(Vector2 direction)
    {

       // Vector3 pos = _rb.position + new Vector3(direction.x * _speed*(_isSprinting?1+_sprintSpeedIncrease:1) * Time.deltaTime, 0, direction.y * _speed * (_isSprinting ? 1 + _sprintSpeedIncrease : 1) * Time.deltaTime);
        //_rb.MovePosition(pos);
        _rb.linearVelocity = new Vector3(direction.x * _speed * (_isSprinting ? 1 + _sprintSpeedIncrease : 1), _rb.linearVelocity.y, direction.y*_speed * (_isSprinting ? 1 + _sprintSpeedIncrease : 1));
        //_mainBody.position = pos;
        Quaternion targetRot = Quaternion.identity;
        Quaternion camRot = Quaternion.identity;
        //camRot.eulerAngles = new Vector3(0, _cam.transform.rotation.eulerAngles.y, 0);
        targetRot.eulerAngles = new Vector3(0, MathF.Atan2(direction.y, -direction.x) * (180 / Mathf.PI) - 90, 0);
        //targetRot *= camRot;
        _rb.rotation = targetRot;// Quaternion.RotateTowards(_rb.rotation, targetRot, Time.deltaTime * _rotationSpeed);
        //if (Quaternion.Dot(_rb.rotation, targetRot) < 0.98) return true;
        //else return false;
    }
    public void SetSprint(bool value)
    {
        _isSprinting = value;
    }
}
