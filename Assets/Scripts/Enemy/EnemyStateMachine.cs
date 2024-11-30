public class EnemyStateMachine
{
    public EnemyState CurrentState { get; private set; }

    public void InitializeState(EnemyState _startState)
    {
        CurrentState = _startState;
        CurrentState.Enter();
    }

    public void ChangeState(EnemyState _newState)
    {
        CurrentState.Exit();
        CurrentState = _newState;
        CurrentState.Enter();
    }
}
