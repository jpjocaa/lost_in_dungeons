using System.Security;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public Transform playerPosition;

    public Rigidbody2D rb;

    void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerPosition = player.transform;
            Debug.Log("Player encontrado: " + playerPosition.name);
        }
        else
        {
            Debug.LogError("Player não encontrado!");
        }
    }

    public void MoveToDirection(Transform target, float moveSpeed)
    {
        Vector2 direction =
            (target.position - transform.position).normalized;

        rb.linearVelocity = direction * moveSpeed;
    }
}
