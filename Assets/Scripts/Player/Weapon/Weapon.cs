using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _lable;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed = false;
    [SerializeField] private int _damage;

    [SerializeField] protected Bullet Bullet;
    [SerializeField] protected bool _targetIsPlayer;

    protected Vector2 _direction;

    public string Lable => _lable;
    public int Price => _price;
    public Sprite Icon => _icon;
    public int Damage => _damage;
    public bool IsBuyed => _isBuyed;

    public abstract void Shoot(Transform shootPoint);

    public void SellWeapon()
    {
        _isBuyed = true;
    }

    protected void InstantiateBullet(Transform shootPoint)
    {
        var bullet = Instantiate(Bullet, shootPoint.position, Quaternion.identity, shootPoint);
        bullet.SetDamage(Damage);
        bullet.SetFlyDirection(_direction);
    }

    public abstract void InitializeWeapon();
}