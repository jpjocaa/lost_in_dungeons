using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Unity.VisualScripting;

public class Boacompanhia : MonoBehaviour
{
    public BoxCollider2D collider2d; 
    public MovingState movingstate;
    public Health health;

    public bool podeUsar = true;
    [SerializeField] public SpriteRenderer Bola;

    private void Awake()
    {
        Bola = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<BoxCollider2D>();
        Bola.enabled = false;
    }


    IEnumerator Repelir(float seconds, GameObject Inimigo)
    {
        if (collider2d != null)
        {
            //é para ficar executando toda hora certo?
            //StartCoroutine(Routine(10f))
            movingstate = new();
            var originalSpeed = movingstate.MoveSpeed;
            movingstate.MoveSpeed = -1000f;


            health = Inimigo.GetComponent<Health>();
            health.TakeDamage(3f);

            
            yield return new WaitForSeconds(2f);
            movingstate.MoveSpeed = originalSpeed;
            Bola.enabled = false;
            yield return new WaitForSeconds(10f);
            podeUsar = true;
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy" ) && podeUsar)
        {
            podeUsar = false;
            Bola.enabled = true;
            StartCoroutine(Repelir(1f,other.gameObject));
        }
    }

}
