using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Boacompanhia : MonoBehaviour
{
    public BoxCollider2D collider2d; 
    public MovingState movingstate;

    private void Awake()
    {
        Checkcollision();
    }

    public void Repelir()
    {
        if (collider2d == true)
        {
            //é para ficar executando toda hora certo?
            //StartCoroutine(Routine(10f));
            StartCoroutine(Wait(10f));
            movingstate = GetComponent<MovingState>();
            var originalSpeed = movingstate.MoveSpeed;
            movingstate.MoveSpeed = -10f;
            StartCoroutine(Wait(1f));
            movingstate.MoveSpeed = originalSpeed; 
        }
    }
    IEnumerator Wait(float segundos)
    {
        yield return new WaitForSeconds(segundos);
    }
    public void Checkcollision()
    {
       collider2d = GetComponent<BoxCollider2D>();
    }

    IEnumerator Routine(float segundos)
    {
        movingstate = GetComponent<MovingState>();
        while(true)
        {
            yield return new WaitForSeconds(segundos);
            var originalSpeed = movingstate.MoveSpeed;
            movingstate.MoveSpeed = -10f;
            yield return new WaitForSeconds(1f);
            movingstate.MoveSpeed = originalSpeed;
            
        }
    }
}
