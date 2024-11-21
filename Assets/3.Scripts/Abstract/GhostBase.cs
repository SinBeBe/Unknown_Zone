using UnityEngine;

public enum State 
{ 
    Idle,
    Move,
}

public abstract class GhostBase : ManagerBase
{
    private State currentState;

    protected virtual void Update()
    {
        switch (currentState) 
        { 
            case State.Idle:
                Idle();
                break;
            case State.Move:
                Move();
                break;
        }
    }

    public abstract void Idle();
    public abstract void Move();
}
