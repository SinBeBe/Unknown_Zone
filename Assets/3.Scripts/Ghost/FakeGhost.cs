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
            rand = RandomInt(1, 11);

            if (currentTime < 0)
            {
                if (rand > 4)
                {
                    targetPos = GenerateRandomPoint(transform.position, radius);
                    ChangeState(State.Move);
                }
                else
                {
                    targetPos = GenerateRandomPoint(player.transform.position, 60f);
                    ChangeState(State.Move);
                }
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
            if (IsNearDistination(agent))
            {
                ChangeState(State.Idle, GetRandomTime(5f));
            }
            else
            {
                agent.SetDestination(targetPos);
            }
        }
    }
    public override void Attack()
    {
        if (!IsCheckPlayer(findRadius) || gi.isPlayerHide)
        {
            ChangeState(State.Idle, 5f);
        }
        else
        {
            transform.LookAt(player.transform);
            agent.SetDestination(player.transform.position);
        }
    }

    public override void Init()
    {
        base.Init();
        radius = 35f;
        findRadius = 30f;
        agent.speed = 25f;
    }
}
