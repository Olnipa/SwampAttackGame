using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(Animator))]
public class DistanceAttackState : State
{
    [SerializeField] private Transform _shootPoint;

    private Enemy _shooter;
    private Animator _animator;

    private const string _attackAnimation = "Attack";

    private void Start()
    {
        _shooter = GetComponent<Enemy>();
        _animator = GetComponent<Animator>();
        _animator.Play(_attackAnimation);
    }

    public void TryShoot()
    {
        if (_shooter.EnemyDistanceWeapon != null)
        {
            _shooter.EnemyDistanceWeapon.Shoot(_shootPoint);
        }
    }
}