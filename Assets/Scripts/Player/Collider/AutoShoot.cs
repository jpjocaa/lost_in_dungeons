using System.Collections.Generic;
using UnityEngine;

public class AutoShooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float cooldown = 0.3f;
    [SerializeField] private string TargetString;

    private Shoot shooting;
    private PlayerBaseStats stats;
    private List<Transform> targets = new List<Transform>();
    private GameObject shooter;
    private float timer;

    void Start()
    {
        shooting = GetComponentInParent<Shoot>();
        shooter = shooting.gameObject;

        if (CompareTag("PlayerAutoShoot"))
        {
            this.stats = GetComponentInParent<PlayerBaseStats>();
            Debug.Log(stats);
        }
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (targets.Count > 0 && timer <= 0)
        {
            AutoShoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TargetString))
        {
            targets.Add(collision.transform);
            Debug.Log("ENCONTREI!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(TargetString))
        {
            targets.Remove(collision.transform);
        }
    }

    private void AutoShoot()
    {
        foreach (Transform target in targets)
        {
            Vector2 direction =
                (target.position - firePoint.position).normalized;

            if (CompareTag("PlayerAutoShoot"))
            {
                shooting.ShootDirection(firePoint,direction,shooter, stats.BaseDamage);
                Debug.Log("Player Atirando");
            }
            else if (CompareTag("EnemyAutoShoot"))
            {
               shooting.ShootDirection(firePoint,direction,shooter, 10); 
               Debug.Log("Inimigo atirando");
            }
            else
            {
                Debug.Log("Tag errada kkkk");
            }
            
        }

        timer = cooldown;
    }
}