using System.Collections;
using UnityEngine;
using DG.Tweening;
using System;

public class BasicEnemyBehaviour : EnemyBase
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _bulletParticle;
    private string _attackCoroutineName = "AttackRoutine";
    private Sequence _seq;

    public override IEnumerator AttackRoutine()
    {
        while (wallBehaviour.Healt >= 0)
        {
            yield return new WaitForSeconds(1);
            if (wallBehaviour.Healt > 0)
            {
                var bullet = objectPool.GetPooledObject((int)Enum.Parse(typeof(ObjectPool.BulletType), bulletType.ToString()));
                bullet.transform.position = transform.position;
                Vector3 target = wallBehaviour.transform.position;
                target.x = transform.position.x;


                bullet.transform.DOJump(target, 1, 1, 1)
                    .OnComplete(() => { 
                        wallBehaviour.TakeDamage(damage);
                        _bulletParticle.transform.position = bullet.transform.position;
                        bullet.gameObject.SetActive(false);
                        _bulletParticle.SetActive(true);
                    });

            }
            else
            {
                StopCoroutine(AttackRoutine());
            }

            Debug.Log("Wall Healt ->" + wallBehaviour.Healt);

        }
    }
    public override void TakeDamage(int damage)
    {

    }

    public override void OnStart()
    {
        _seq = DOTween.Sequence();
        _seq.Append(transform.DOMoveZ(wallBehaviour.transform.position.z + 3, arrivalTime).OnComplete(() =>
        {
            CanMove = false;
            StartCoroutine(_attackCoroutineName);
        }));
    }

    public override void TriggerOtherBot()
    {
        _seq.Kill();
        StartCoroutine(_attackCoroutineName);
    }


}
