using UnityEngine;

public class FakeGhost : GhostBase
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
            currentTime -= Time.deltaTime;
            rand = RandomInt(0, 10);

            if (currentTime < 0)
            {
                targetPos = GetRandomPointInRange(radius);
                ChangeState(State.Move, GetRandomTime(7f));
            }
            else if (currentTime < 0)
            {
                targetPos = PlayerNearRandomPoint(40f, 10f);
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
        radius = 30f;
        findRadius = 20f;
        agent.speed = 15f;
    }
}
