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
    public void Move(Vector2 direction)
    {

        Vector3 pos = _rb.position + new Vector3(direction.x * _speed * Time.deltaTime, 0, direction.y * _speed * Time.deltaTime);
        _mainBody.position = pos;
    }
}
