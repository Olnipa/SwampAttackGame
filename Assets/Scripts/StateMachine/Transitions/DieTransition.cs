using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class DieTransition : Transition
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        _enemy.Died += SetDieTransition;
    }

    private void SetDieTransition(Enemy enemy)
    {
        needToTransit = true;
        enemy.Died -= SetDieTransition;
    }
}