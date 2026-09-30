using System.Collections.Generic;
using UnityEngine;

public class AutoShooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float cooldown = 0.3f;
    [SerializeField] private string TargetString;

    private Shoot shooting;
    private List<Transform> targets = new List<Transform>();
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

            shooting.ShootDirection(
                firePoint,
                direction,
                shooter
            );
        }

        timer = cooldown;
    }
}