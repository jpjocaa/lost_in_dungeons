using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovingState : EnemyBaseState
{
    private Transform playerPosition;
    public float MoveSpeed = 3;

    public override void EnterState(EnemyStateManager enemy)
    {
        playerPosition = enemy.Controller.playerPosition;
    }

    public override void OnCollisionEnter(EnemyStateManager boss, Collision collision)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerEnter(EnemyStateManager boss, Collider2D collider)
    {
        //Se for o player que atingiu, ataque o player!
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.Controller.MoveToDirection(playerPosition, MoveSpeed);
    }
}