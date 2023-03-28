using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DeathState : State
{
    [SerializeField] private float _sleepBeforeDestroy;

    private Animator _animator;

    private const string _deathAnimation = "Death";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _animator.Play(_deathAnimation);
        StartCoroutine(DestroyEnemyJob());
    }

    private IEnumerator DestroyEnemyJob()
    {
        yield return new WaitForSeconds(_sleepBeforeDestroy);
        Destroy(gameObject);
    }
}