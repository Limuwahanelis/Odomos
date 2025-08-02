using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class MovingShopNPCController : ShopNPCController
{
    [SerializeField] GameEventSO _timeResumed;
    [SerializeField] GameEventSO _timePaused;
    [SerializeField] NavMeshAgent _agent;
    public override void Awake()
    {
        base.Awake();
        _agent.isStopped = true;
    }
    public void Initialize()
    {
        _agent.isStopped = false;
        List<Type> states = AppDomain.CurrentDomain.GetAssemblies().SelectMany(domainAssembly => domainAssembly.GetTypes())
.Where(type => typeof(EnemyState).IsAssignableFrom(type) && !type.IsAbstract).ToArray().ToList();

        _context = new MovingShopNPCContext
        {
            ChangeEnemyState = ChangeState,
            animMan = _enemyAnimationManager,
            shelfs = _shelfs,
            navMeshAgent = _agent,
            npc = transform,
        };
        EnemyState.GetState getState = GetState;
        foreach (Type state in states)
        {
            _enemyStates.Add(state, (EnemyState)Activator.CreateInstance(state, getState));
        }

        _currentEnemyState=GetState(MovingShopNPCStateIdle.StateType);
        _currentEnemyState.SetUpState(_context);
    }
    public void StartNpc()
    {
        Initialize();
    }
    public void SwitchNavMesh()
    {
        _agent.isStopped = !_agent.isStopped;
    }
    public void OnTimeStopped()
    {
        _enemyAnimationManager.Animator.SetFloat("MyTimeScale", 0);
        _agent.isStopped = true;
    }
    public void OnTimeResumed()
    {
        _enemyAnimationManager.Animator.SetFloat("MyTimeScale", 0);
        _agent.isStopped = false;
    }
    //void Update()
    //{
    //    _currentEnemyState?.Update();
    //}
}
