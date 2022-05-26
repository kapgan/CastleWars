using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPackages.Scripts.Behaviour;
using DG.Tweening;
using MyPackages.Scripts;
public abstract class EnemyBase : MonoBehaviour
{
    public bool CanMove = true;
    [SerializeField] protected ObjectPool.BulletType bulletType;
    [SerializeField] protected Color color;
    [SerializeField] protected int healt;
    [SerializeField] protected int damage;
    [SerializeField] protected float arrivalTime;
    [SerializeField] protected float attackCouldown;
    [SerializeField] protected GameObject bullet;
    protected ObjectPool objectPool;
    protected WallBehaviour wallBehaviour;
    protected int lineIndex;
    public abstract IEnumerator AttackRoutine();
    public abstract void OnStart();
    public abstract void TriggerOtherBot();
    public abstract void TakeDamage(int damage);
    public virtual void KillEnemy() {
        LevelBehaviour.Instance.SpawnController.KillEnemy(lineIndex);
    }
    public void Start()
    {
        LevelBehaviour.OnComplete += OnGameEnd;
        objectPool = LevelBehaviour.Instance.PoolObject;
        OnStart();
    }

    public virtual void OnGameEnd(bool v)
    {
        LevelBehaviour.OnComplete -= OnGameEnd;
    }
    public void SetData(WallBehaviour wall,int index)
    {
        lineIndex = index;
        wallBehaviour = wall;
    }
   
}
