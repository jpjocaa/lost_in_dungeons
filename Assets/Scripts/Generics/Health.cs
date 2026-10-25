using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] public float Maxhealth;
    private float health;
    private LevelSystem levelSystem ;


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

        //O die tá bem ruim por enquanto, mas já que não tem muita coisa então tanto faz.
        if (CompareTag("Player"))
        {
            
            SceneManager.LoadScene("Menu");
            Debug.Log("Player morreu!\n Por enquanto n tem uma animação de morte nem menu, ent vai ficar assim msm.");
        }
        else
        {
            Destroy(gameObject);
            LevelSystem levelSystem =FindFirstObjectByType<LevelSystem>();

            if (CompareTag("Enemy") && levelSystem != null)
            {
                levelSystem.RegisterKill();
            }
        }
    }
}
