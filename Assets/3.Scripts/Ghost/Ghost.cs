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
            currentTime -= Time.deltaTime;

            if(currentTime < 0)
            {
                ChangeState(State.Move, GetRandomTime(7f));
            }
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
            currentTime -= Time.deltaTime;
            if (IsNearDistination(agent) && currentTime < 0)
            {
                ChangeState(State.Idle, GetRandomTime(5f));
            }
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
