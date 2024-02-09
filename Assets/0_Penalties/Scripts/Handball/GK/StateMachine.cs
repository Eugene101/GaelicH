using UnityEngine;
public class StateMachine
{
    public State currentState;

    public void Intialize(State NewState)
    {
        currentState = NewState;
        currentState.Enter();
    }

    public void ChangeState(State NewState)
    {
        currentState.Exit();
        currentState = NewState;
        currentState.Enter();
    }
}
