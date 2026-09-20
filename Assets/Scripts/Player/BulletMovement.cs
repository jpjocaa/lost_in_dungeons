using UnityEngine;

public class BulletMovement : MonoBehaviour //Movimenta a bala
{
    [SerializeField] private float velocity = 10f;

    private Vector2 direction;

    public void SetDirection(Vector2 direction, Collider2D shooterCollider)
    {
        this.direction = direction;
        Collider2D bulletCollider = GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(bulletCollider,shooterCollider);
    }
    public void SetShooter(Collider2D shooterCollider)
    {
        Collider2D bulletCollider = GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(bulletCollider,shooterCollider);
    }

    private void Update()
    {
        transform.Translate(direction * velocity * Time.deltaTime);
    }
}
