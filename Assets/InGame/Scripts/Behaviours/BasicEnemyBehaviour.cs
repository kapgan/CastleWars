using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BasicEnemyBehaviour : EnemyBase
{
    [SerializeField] private Animator _animator;

    private string _attackCoroutineName = "AttackRoutine";
 

    public override IEnumerator AttackRoutine()
    {
        while (wallBehaviour.Healt <= 0)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("Wall Healt>" + wallBehaviour.Healt);

            wallBehaviour.TakeDamage(damage);
        }
    }
  

    public override void OnStart()
    {
        transform.DOMoveZ(wallBehaviour.transform.position.z-2, arrivalTime).OnComplete(()=>{ StartCoroutine(_attackCoroutineName); });
    }


}
