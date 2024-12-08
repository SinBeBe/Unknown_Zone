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
                if (rand > 3)
                {
                    targetPos = GenerateRandomPoint(transform.position, radius, 10f);
                    ChangeState(State.Move, GetRandomTime(7f));
                }
                else if (rand < 10)
                {
                    targetPos = GenerateRandomPoint(player.transform.position, 60f, 10f);
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
        radius = 30f;
        findRadius = 20f;
        agent.speed = 20f;
    }
}
