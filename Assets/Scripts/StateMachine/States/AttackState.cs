using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDelay;

    private Animator _animator;
    private Coroutine _attackCoroutine;
    private WaitForSeconds _delay;

    private const string _attackAnimation = "Attack";

    private void Start()
    {
        _delay = new WaitForSeconds(_attackDelay);
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_attackCoroutine == null)
            Attack();
    }

    private void Attack()
    {
        _attackCoroutine = StartCoroutine(AttackJob());
    }

    private IEnumerator AttackJob()
    {
        _animator.Play(_attackAnimation);
        Target.TakeDamage(_damage);

        yield return _delay;
        
        _attackCoroutine = null;
    }
}