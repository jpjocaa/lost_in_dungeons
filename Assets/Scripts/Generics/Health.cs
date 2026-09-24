using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] public float Maxhealth;
    private float health;

    void Start()
    {
        health = Maxhealth;
    }

    public void TakeDamage(float damage)
    {
       health -= damage;
       Debug.Log("AI");

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
            //sei lá, menu da morte do player??
            Debug.Log("Player morreu!");
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
