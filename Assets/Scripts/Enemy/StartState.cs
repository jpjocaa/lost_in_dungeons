using UnityEngine;

public class StartState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        MoveToPlayer(enemy);
        Debug.Log("Inimigo iniciado!");
    }

    public override void OnCollisionEnter(EnemyStateManager boss, Collision collision)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerEnter(EnemyStateManager boss, Collider2D collider)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(EnemyStateManager boss)
    {
        throw new System.NotImplementedException();
    }

    public void MoveToPlayer(EnemyStateManager enemy)
    {
        enemy.SwitchState(enemy.movingState);
    }
}