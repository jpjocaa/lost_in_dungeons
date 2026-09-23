using UnityEngine;


public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float velocity = 10f;
    [SerializeField] private float lifeTime = 1f;

    private Vector2 direction;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void Initialize(Vector2 direction, GameObject shooter)
    {
        this.direction = direction;

        Collider2D bulletCollider = GetComponent<Collider2D>();

        Collider2D[] shooterColliders =
            shooter.GetComponentsInChildren<Collider2D>();

        foreach (Collider2D collider in shooterColliders)
        {
            Physics2D.IgnoreCollision(
                bulletCollider,
                collider
            );
        }
    }

    private void Update()
    {
        transform.Translate(
            direction * velocity * Time.deltaTime
        );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable =
            collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(10);
        }

        Destroy(gameObject);
    }
}