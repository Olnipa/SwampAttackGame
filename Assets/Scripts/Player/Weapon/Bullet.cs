using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float Speed;
    [SerializeField] protected bool TargetIsPlayer;

    protected int Damage;
    protected Vector2 FlyDirection;

    protected void Update()
    {
        transform.Translate(FlyDirection * Speed * Time.deltaTime, Space.World);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (TargetIsPlayer)
        {
            if (collision.TryGetComponent(out Player player))
            {
                player.TakeDamage(Damage);
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(Damage);
                Destroy(gameObject);
            }
        }

        if (collision.TryGetComponent(out MapEdge edge))
            Destroy(gameObject);
    }

    public void SetDamage(int damage)
    {
        Damage = damage;
    }

    public void SetFlyDirection(Vector2 direction)
    {
        FlyDirection = direction;
    }
}