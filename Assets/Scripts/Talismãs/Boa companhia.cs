using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Boacompanhia : MonoBehaviour

{
    public BoxCollider2D collider2d; 
    public MovingState movingstate;

    public void repelir()
    {
        if (collider2d = true)
        {
            StartCoroutine(wait(10f));
            movingstate = GetComponent<MovingState>();
            movingstate.MoveSpeed = -10f;
                StartCoroutine(wait(1f));
            movingstate.MoveSpeed = 5f; 
        }
    }
    IEnumerator wait(float segundos)
    {
        yield return new WaitForSeconds(segundos);
    }
    public void checkcollision()
    {
       collider2d = GetComponent<BoxCollider2D>();
    }
}
