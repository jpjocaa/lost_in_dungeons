using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Unity.VisualScripting;

public class Boacompanhia : MonoBehaviour
{
    public BoxCollider2D collider2d; 
    public MovingState movingstate;

    private void Awake()
    {
        collider2d = GetComponent<BoxCollider2D>();
    }


    IEnumerator Repelir(float seconds, GameObject Inimigo)
    {
        if (collider2d != null)
        {
            //é para ficar executando toda hora certo?
            //StartCoroutine(Routine(10f))
            movingstate = Inimigo.GetComponent<MovingState>();
            var originalSpeed = movingstate.MoveSpeed;
            movingstate.MoveSpeed = -10f;
            yield return new WaitForSeconds(1f);
            movingstate.MoveSpeed = originalSpeed;
            yield return new WaitForSeconds(10f);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(Repelir(1f,other.gameObject));
        }
    }

}
