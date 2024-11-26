using UnityEngine;

public class Ghost : GhostBase
{
    public override void Idle()
    {
        if (IsCheckPlayer(findRadius))
        {
            agent.ResetPath();
            ChangeState(State.Attack);
        }
        else
        {
            targetPos =  GetRandomPointInRange(radius);
            ChangeState(State.Move);
        }
    }
    public override void Move()
    {
        if (IsCheckPlayer(findRadius))
        {
            agent.ResetPath();
            ChangeState(State.Attack);
        }
        else
        {
            agent.SetDestination(targetPos);
        }
    }
    public override void Attack()
    {
        
    }

    public override void Init()
    {
        base.Init();
        radius = 40f;
        findRadius = 30f;
    }
}
