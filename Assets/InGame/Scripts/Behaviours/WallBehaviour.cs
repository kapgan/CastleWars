using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPackages.Scripts.Behaviour;

public class WallBehaviour : MonoBehaviour
{
   [SerializeField] private int healt;

    public int Healt { get => healt; set => healt = value; }

    public void TakeDamage(int damage)
    {
        healt -= damage;
        CheckWallStatus();
    }
    private void CheckWallStatus()
    {
        if (healt <= 0) LevelBehaviour.Instance.GameEnd(false);
            
    }
}
