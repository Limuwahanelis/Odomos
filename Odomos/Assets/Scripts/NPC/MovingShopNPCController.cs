using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class MovingShopNPCController : ShopNPCController
{

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
            positions = _positions,
            navMeshAgent = _agent,
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

    //void Update()
    //{
    //    _currentEnemyState?.Update();
    //}
}
