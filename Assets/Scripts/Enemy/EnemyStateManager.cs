using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;
    public StartState startState = new();
    public MovingState movingState = new();



    public Enemy_Controller Controller;

    void Start()
    {
        Controller = GetComponent<Enemy_Controller>();
        currentState = startState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);  
    }
    
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        currentState.OnTriggerEnter(this, collider2D);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
