using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private int _minBulletsCount;
    [SerializeField] private int _maxBulletsCount;
    [SerializeField] private float _bulletSpread;

    private int _bulletsCount;

    public override void InitializeWeapon()
    {
        if (_targetIsPlayer)
            _direction.x = -1;
        else
            _direction.x = 1;
    }

    public override void Shoot(Transform shootPoint)
    {
        _bulletsCount = Random.Range(_minBulletsCount, _maxBulletsCount);
        float distanceBetweenBullets = (_bulletSpread * 2) / _bulletsCount;

        for (int i = 0; i < _bulletsCount; i++)
        {
            _direction.y = _bulletSpread - distanceBetweenBullets * i;
            InstantiateBullet(shootPoint);
        }
    }
}