using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _reward;
    [SerializeField] private Weapon _distanceWeapon;

    private int _currentHealth;
    private Player _target;
    private BoxCollider2D _collider;
    
    public event UnityAction<Enemy> Died;

    public bool IsAlive { get; private set; }
    public Weapon EnemyDistanceWeapon => _distanceWeapon;
    public int Reward => _reward;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _currentHealth = _maxHealth;
    
        if (_distanceWeapon != null)
            _distanceWeapon.InitializeWeapon();
    }
    
    public void Initialise(Player target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                IsAlive = false;
                _collider.enabled = false;
                Died?.Invoke(this);
            }
        }
    }

    public Player GetTarget()
    {
        return _target;
    }
}