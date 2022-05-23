using System.Collections;
using UnityEngine;
using DG.Tweening;
public class BasicEnemyBehaviour : EnemyBase
{
    [SerializeField] private Animator _animator;

    private string _attackCoroutineName = "AttackRoutine";
    private Sequence _seq;

    public override IEnumerator AttackRoutine()
    {
        while (wallBehaviour.Healt >= 0)
        {
            yield return new WaitForSeconds(1);

            wallBehaviour.TakeDamage(damage);

            Debug.Log("Wall Healt ->" + wallBehaviour.Healt);

        }
    }
  

    public override void OnStart()
    {
        _seq = DOTween.Sequence();
        _seq.Append(transform.DOMoveZ(wallBehaviour.transform.position.z+1, arrivalTime).OnComplete(()=>{
            CanMove = false;
            StartCoroutine(_attackCoroutineName); }));
    }

    public override void TriggerOtherBot()
    {
        _seq.Kill();
        StartCoroutine(_attackCoroutineName);
    }
    
 
}
