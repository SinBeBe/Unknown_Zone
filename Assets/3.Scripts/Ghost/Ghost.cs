using System.Collections.Generic;
using UnityEngine;

public class Ghost : GhostBase
{
    public List<GameObject> ghostSkill = new List<GameObject>();

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
            rand = RandomInt(0, 12);

            if(currentTime < 0 && rand < 3)
            {
                targetPos = GetRandomPointInRange(radius);
                ChangeState(State.Move, GetRandomTime(7f));
            }
            else if(currentTime < 0 && rand > 3 && rand <= 10)
            {
                targetPos = PlayerNearRandomPoint(60f, 10f);
                ChangeState(State.Move);
            }
            else if(currentTime < 0 && rand == 11)
            {
                GhostSkill();
                ChangeState(State.Idle);
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
        radius = 40f;
        findRadius = 30f;
        agent.speed = 15f;
    }

    public void GhostSkill()
    {
        int rand = RandomInt(0, 3);
        Instantiate(ghostSkill[rand], transform);
    }
}
