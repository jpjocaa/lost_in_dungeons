using UnityEngine;

public class BulletMovement : MonoBehaviour //Movimenta a bala
{
    [SerializeField] private float velocity = 10f;
    [SerializeField] private float lifeTime = 1f;

    private Vector2 direction;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    public void SetDirection(Vector2 direction, Collider2D shooterCollider)
    {
        this.direction = direction;
        Collider2D bulletCollider = GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(bulletCollider,shooterCollider);
    }


    private void Update()
    {
        transform.Translate(direction * velocity * Time.deltaTime);
    }


}
