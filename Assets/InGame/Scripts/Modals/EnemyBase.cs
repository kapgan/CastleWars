using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPackages.Scripts.Behaviour;
public abstract class EnemyBase : MonoBehaviour
{
    public Color color;
    public int healt;
    public int damage;
    public float arrivalTime;
    public float attackCouldown;
    public WallBehaviour wallBehaviour;

    public void SetEnemyData(Color _color, int _healt, int _damage, float _arrivalTime, float _attackCouldown, WallBehaviour _target)
    {
        color = _color;
        healt = _healt;
        arrivalTime = _arrivalTime;
        attackCouldown = _attackCouldown;
        wallBehaviour = _target;

    }
    public abstract IEnumerator AttackRoutine();
    public abstract void OnStart();
    public void Start()
    {
        LevelBehaviour.OnComplete += OnGameEnd;
        OnStart();
    }
    public virtual void OnGameEnd(bool v) { 
        LevelBehaviour.OnComplete -= OnGameEnd;

    }
}
