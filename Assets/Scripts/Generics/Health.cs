using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] public float Maxhealth;
    private float health;
    private LevelSystem levelSystem ;

    private bool isDead;


    void Start()
    {
        health = Maxhealth;
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
}
