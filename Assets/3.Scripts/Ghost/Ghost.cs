using UnityEngine;

public class Ghost : GhostBase
{
    private bool isMoved = false;

    public override void Idle()
    {
        if (IsCheckPlayer(findRadius))
        {
            agent.ResetPath();
            ChangeState(State.Attack);
        }
        else
        {
            currentTime -= Time.deltaTime;

            if(currentTime < 0)
            {
                targetPos = GetRandomPointInRange(radius);
                ChangeState(State.Move, GetRandomTime(7f));
            }
            else if(currentTime < 0)
            {
                targetPos = PlayerNearRandomPoint();
                ChangeState(State.Move);
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
            isMoved = true;
            agent.SetDestination(targetPos);
            currentTime -= Time.deltaTime;
            if (IsNearDistination(agent) && currentTime < 0)
            {
                ChangeState(State.Idle, GetRandomTime(5f));
                isMoved = false;
            }
        }
    }
    public override void Attack()
    {
        transform.LookAt(player.transform);
        agent.SetDestination(player.transform.position);
        
        if (!IsCheckPlayer(findRadius))
        {
            ChangeState(State.Idle, 5f);
        }
    }

    public override void Init()
    {
        base.Init();
        radius = 40f;
        findRadius = 30f;
        agent.speed = 10f;
    }
}
