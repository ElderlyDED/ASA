using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEnemyAttack : MonoBehaviour
{
    public int _attackDamage;
    [SerializeField] float _attackDelay;
    [SerializeField] CloseEnemyAnimator _closeEnemyAnimatorScript;
    [SerializeField] bool _readyPunch;
    [SerializeField] GameObject _attackCollider;
    [SerializeField] float _activTimeAttackCollider;
    [SerializeField] float _animationAttackDelay;
    void Start()
    {
        _closeEnemyAnimatorScript = GetComponent<CloseEnemyAnimator>();
    }
    public void Attack()
    {
        if (_readyPunch == true)
        {
            _readyPunch = false;
            StartCoroutine(PunchDelay());
            _closeEnemyAnimatorScript.AttackAnimation();
            StartCoroutine(OffAttackCollider());
        }
    }
    IEnumerator PunchDelay()
    {
        yield return new WaitForSeconds(_attackDelay);
        _readyPunch = true;
    }

    IEnumerator OffAttackCollider()
    {
        yield return new WaitForSeconds(_animationAttackDelay);
        _attackCollider.SetActive(true);
        yield return new WaitForSeconds(_activTimeAttackCollider);
        _attackCollider.SetActive(false);
    }
}
