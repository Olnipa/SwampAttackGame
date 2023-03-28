using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;
    
    private int _currentHealth;
    private Weapon _currentWeapon;
    private int _currentWeaponIndex;
    private Animator _animator;

    private const string _animationShoot = "Shoot";
    private const string _animationDead = "Dead";

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> CoinsCountChanged;

    public bool IsAlive { get; private set; }
    public int Money { get; private set; }

    private void Start()
    {
        IsAlive = true;
        _currentHealth = _maxHealth;
        _animator = GetComponent<Animator>();
        SetWeapon(_currentWeaponIndex);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsAlive)
        {
            _currentWeapon.Shoot(_shootPoint);
            _animator.SetTrigger(_animationShoot);
        }

        if (Input.GetKeyDown(KeyCode.Q))
            SetPreviousWeapon();

        if (Input.GetKeyDown(KeyCode.E))
            SetNextWeapon();
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _currentHealth -= damage;
            HealthChanged?.Invoke(_currentHealth, _maxHealth);
        }

        if (_currentHealth <= 0 && IsAlive)
        {
            IsAlive = false;
            _animator.SetTrigger(_animationDead);
        }
    }

    private void PayMoney(int money)
    {
        if (money > 0)
        {
            Money -= money;
            CoinsCountChanged?.Invoke(Money);
        }
    }

    public void AddMoney(int money)
    {
        if (money > 0)
        {
            Money += money;
            CoinsCountChanged?.Invoke(Money);
        }
    }

    public void BuyItem(Weapon weapon)
    {
        PayMoney(weapon.Price);
        _weapons.Add(weapon);
    }

    public void SetNextWeapon()
    {
        if (_currentWeaponIndex + 1 == _weapons.Count)
        {
            _currentWeaponIndex = 0;
        }
        else
            _currentWeaponIndex++;

        SetWeapon(_currentWeaponIndex);
    }

    public void SetPreviousWeapon()
    {
        if (_currentWeaponIndex == 0)
        {
            _currentWeaponIndex = _weapons.Count - 1;
        }
        else
            _currentWeaponIndex--;

        SetWeapon(_currentWeaponIndex);
    }

    private void SetWeapon(int weaponIndex)
    {
        _currentWeapon = _weapons[weaponIndex];
        _currentWeapon.InitializeWeapon();
    }
}