using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPackages.Scripts.Behaviour;
using DG.Tweening;

public class WallBehaviour : MonoBehaviour
{
    [SerializeField] private int healt;

    public int Healt { get => healt; private set => healt = value; }

    private float _downWallStep = 0;
    private bool _onShake = false;
    private void Start()
    {
    }
    public void TakeDamage(int damage)
    {
        Healt -= damage;
        CheckWallStatus();

        _downWallStep++;
        TakeAction();
    }
    private void TakeAction()
    {
        if (!_onShake && _downWallStep>0)
        {
            _onShake = true;
            transform.DOMoveY(transform.position.y - .4f, .5f).OnComplete(() =>
            {
                _onShake = false;
                _downWallStep--;
                TakeAction();
            });
        }
    }
    private void CheckWallStatus()
    {
        if (healt <= 0) LevelBehaviour.Instance.GameEnd(false);
    }
}
