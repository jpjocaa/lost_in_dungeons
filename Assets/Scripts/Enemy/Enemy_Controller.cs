using System.Security;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    //      Inimigo que ande em direção ao player,atire quando estiver no alcance,leve dano e morra.     //

    [Header("Atributos externos")]
    [SerializeField] public Transform playerPosition;
    private Vector2 MoveDirection;
    [Header("Atributos do inimigo")]
    [SerializeField] public Rigidbody2D rb;


    public void MoveToDirection(Transform target, float MoveSpeed)
    {
        MoveDirection = new Vector2(target.position.x , target.position.y);
        Debug.Log(MoveDirection);
        rb.linearVelocity = MoveDirection * 1;
    }
}
