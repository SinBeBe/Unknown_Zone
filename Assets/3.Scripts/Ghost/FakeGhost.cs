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

            if (currentTime < 0 && !agent.hasPath)
            {
                rand = RandomInt(1, 11);
                if (rand > 4 && gi.isPlayerHide)
                {
                    targetPos = GenerateRandomPoint(transform.position, radius);
                    ChangeState(State.Move, 10f);
                }
                else
                {
                    targetPos = GenerateRandomPoint(player.transform.position, 60f);
                    ChangeState(State.Move, 30f);
                }
            }
            else
            {
                return;
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
            currentTime -= Time.deltaTime;

            agent.SetDestination(targetPos);

            if (IsNearDestination(agent) || currentTime <= 0)
            {
                agent.ResetPath();
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
        radius = 70f;
        findRadius = 80f;
        agent.speed = 15f;
        Destroy(this.gameObject, 180f);
    }
}
