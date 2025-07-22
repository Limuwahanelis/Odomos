using System;
using UnityEngine;

public class PlayerPushComponent : MonoBehaviour, IPushable
{
    [SerializeField] bool _canBePushed;
    [SerializeField] PlayerController _playerController;
    public void Push(PushInfo pushInfo)
    {
        
        if(_canBePushed) _playerController.CurrentPlayerState.Push();
        _canBePushed = false;
    }
}
