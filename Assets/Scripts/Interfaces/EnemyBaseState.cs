using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateManager boss);

    public abstract void UpdateState(EnemyStateManager boss);

    public abstract void OnCollisionEnter(EnemyStateManager boss, Collision collision);

    public abstract void OnTriggerEnter(EnemyStateManager boss, Collider2D collider);
}
