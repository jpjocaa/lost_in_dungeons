using UnityEngine;

public class AutoShooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float cooldown = 0.3f;
    private Shoot shooting;
    private Transform target;
    private float timer;


    void Start()
    {
        shooting = GetComponentInParent<Shoot>();
    }


    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if(target != null && timer <= 0) 
        {
            AutoShoot();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) //entrou no alcance
    {
        if (collision.CompareTag("Enemy"))
        {
            target = collision.transform; //pega a posição do collider, ou seja, do inimigo. Era isso que eu e o kenji fomos incapaz de fazer na sala.
        }
    }


    private void OnTriggerExit2D(Collider2D collision) //saiu do alcance
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

        shooting.ShootDirection(firePoint, direction);

        timer = cooldown;
    }
}
