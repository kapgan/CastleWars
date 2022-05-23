using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerBehaviour : MonoBehaviour
{
    public EnemyBase Enemy; 
    private void OnTriggerStay(Collider other)
    {
        if (Enemy.CanMove==true && other.TryGetComponent(out EnemyTriggerBehaviour enemyTriggerBehaviour))
        {
            Enemy.CanMove = false;
            Enemy.TriggerOtherBot();
        }
    }
}
