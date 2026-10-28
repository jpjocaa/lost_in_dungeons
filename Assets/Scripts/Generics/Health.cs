using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] public float Maxhealth;
    private float health;
    private LevelSystem levelSystem ;

    private PlayerBaseStats stats;

    private bool isDead;


    void Start()
    {
        stats = GetComponent<PlayerBaseStats>();

        if (CompareTag("Player"))
        {
            health = stats.MaxHealth;
        } 
        else if (CompareTag("Enemy"))
        {
            health = Maxhealth;
        }

        LevelSystem levelSystem = FindFirstObjectByType<LevelSystem>();
    }

    public void TakeDamage(float damage)
    {
       health -= damage;

       if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (isDead)
            return;

        isDead = true;

        if (CompareTag("Player"))
        {
            Debug.Log("Player morreu!");

            SceneManager.LoadScene("Menu");
        }
        else
        {
            if (CompareTag("Enemy"))
            {
                LevelSystem levelSystem =
                    FindFirstObjectByType<LevelSystem>();

                if (levelSystem != null)
                    levelSystem.RegisterKill();
            }

            Destroy(gameObject);
        }
    }

    public void Heal(float amount)
    {
        health =+ amount;
        health = Mathf.Min(health, Maxhealth);//ainda não muda nada pois o player não se regenera.
    }
}
