using System.Runtime.Serialization.Json;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Vector3 PositionToFollow => _positionToFollow;
    [SerializeField, Tooltip("If set camera will try to always follow tis transform")] Transform _transformToFollow;
    [SerializeField] Vector3 offset;


    [SerializeField] bool CheckForBorders = true;
    [SerializeField] Transform leftScreenBorder;
    [SerializeField] Transform rightScreenBorder;
    [SerializeField] Transform upperScreenBorder;
    [SerializeField] Transform lowerScreenBorder;
    [SerializeField] Transform forwardScreenBorder;
    [SerializeField] Transform backScreenBorder;

    [SerializeField] float smoothTime = 0.3f;

    private bool _followOnXAxis = true;
    private bool _followOnYAxis = true;
    private bool _followOnZAxis = true;
    private Vector3 _targetPos;
    private Vector3 _positionToFollow;
    //private float _horizontalMax;
    //private float _verticalMax;
    private Vector3 _velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //_horizontalMax = Camera.main.orthographicSize * Screen.width / Screen.height;
        //_verticalMax = Camera.main.orthographicSize;
        if (_transformToFollow) _positionToFollow = _transformToFollow.position;
        else _positionToFollow = transform.position;
        transform.position = _transformToFollow.position + offset;
    }
    private void Update()
    {
        if (_transformToFollow) SetPositionToFollow(_transformToFollow.position);
    }
    private void FixedUpdate()
    {
        if (_transformToFollow == null) return;
        if (CheckForBorders)
        {
            _targetPos = _positionToFollow;
            if (_followOnXAxis)
            {
                _targetPos = new Vector3(_positionToFollow.x, _targetPos.y, _positionToFollow.z);
            }
            if (_followOnYAxis)
            {
                _targetPos = new Vector3(_targetPos.x, _positionToFollow.y, _positionToFollow.z);
            }
            if(_followOnZAxis)
            {
                _targetPos = new Vector3(_targetPos.x, _targetPos.y, _positionToFollow.z);
            }
        }
        else
        {
            _targetPos = _positionToFollow;
        }
        _targetPos += offset;
        transform.position = Vector3.SmoothDamp(transform.position, _targetPos, ref _velocity, smoothTime);
    }
    /// <summary>
    /// Sets camera position omitting the dampening effect.
    /// </summary>
    /// <param name="pos"></param>
    public void SetPositionToFollowRaw(Vector3 pos)
    {
        _positionToFollow = pos;
        if (CheckForBorders)
        {
            if (_positionToFollow.x < leftScreenBorder.position.x)
            {
                _followOnXAxis = false;
                _positionToFollow = new Vector3(leftScreenBorder.position.x , _positionToFollow.y);
            }
            else
            {
                CheckIfPlayerIsOnRightScreenBorder();
            }

            if (_positionToFollow.y < lowerScreenBorder.position.y)
            {
                _followOnYAxis = false;
                _positionToFollow = new Vector3(_positionToFollow.x, lowerScreenBorder.position.y, _positionToFollow.z);

            }
            else
            {
                CheckIfPlayerIsOnUpperScreenBorder();
            }
        }
        _targetPos = _positionToFollow;
        _targetPos += offset;
        transform.position = _targetPos;
    }
    public void SetPositionToFollow(Vector3 pos)
    {
        _positionToFollow = pos;
        if (CheckForBorders)
        {
            if (_positionToFollow.x  < leftScreenBorder.position.x)
            {
                _followOnXAxis = false;
                _positionToFollow = new Vector3(leftScreenBorder.position.x, _positionToFollow.y, _positionToFollow.z);
            }
            else
            {
                CheckIfPlayerIsOnRightScreenBorder();
            }

            if (_positionToFollow.y < lowerScreenBorder.position.y)
            {
                _followOnYAxis = false;
                _positionToFollow = new Vector3(_positionToFollow.x, lowerScreenBorder.position.y, _positionToFollow.z);

            }
            else
            {
                CheckIfPlayerIsOnUpperScreenBorder();
            }
            if(_positionToFollow.z <backScreenBorder.position.z)
            {
                _followOnZAxis = false;
                _positionToFollow = new Vector3(_positionToFollow.x, _positionToFollow.y, backScreenBorder.position.z);
            }
            else
            {
                CheckIfPlayerIsOnForwardScreenBorder();
            }
        }

    }
    private void CheckIfPlayerIsOnRightScreenBorder()
    {
        if (_positionToFollow.x > rightScreenBorder.position.x)
        {
            _followOnXAxis = false;
            _positionToFollow = new Vector3(rightScreenBorder.position.x , _positionToFollow.y, _positionToFollow.z);
        }
        else
        {
            _followOnXAxis = true;
        }
    }
    private void CheckIfPlayerIsOnForwardScreenBorder()
    {
        if (_positionToFollow.z > forwardScreenBorder.position.z)
        {
            _followOnZAxis = false;
            _positionToFollow = new Vector3(_positionToFollow.x, _positionToFollow.y, forwardScreenBorder.position.z);
        }
        else
        {
            _followOnZAxis = true;
        }
    }
    private void CheckIfPlayerIsOnUpperScreenBorder()
    {
        if (_positionToFollow.y > upperScreenBorder.position.y)
        {
            _followOnYAxis = false;
            _positionToFollow = new Vector3(_positionToFollow.x, upperScreenBorder.position.y, _positionToFollow.y);
        }
        else
        {
            _followOnYAxis = true;
        }
    }
}
