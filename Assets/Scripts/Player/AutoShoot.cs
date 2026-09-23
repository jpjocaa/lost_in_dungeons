using UnityEngine;

public class AutoShooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float cooldown = 0.3f;

    private Shoot shooting;
    private Transform target;
    private GameObject shooter;
    private float timer;

    void Start()
    {
        shooting = GetComponentInParent<Shoot>();
        shooter = shooting.gameObject;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (target != null && timer <= 0)
        {
            AutoShoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            target = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            target = null;
        }
    }

    private void AutoShoot()
    {
        Vector2 direction =
            (target.position - firePoint.position).normalized;

        shooting.ShootDirection(
            firePoint,
            direction,
            shooter
        );

        timer = cooldown;
    }
}