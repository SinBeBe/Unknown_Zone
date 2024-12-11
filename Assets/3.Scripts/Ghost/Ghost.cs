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

            if (currentTime < 0 && !agent.hasPath)
            {
                rand = RandomInt(1, 12);
                Debug.Log(rand);
                if (rand == 11)
                {
                    Debug.Log("Ghost Skill!");
                    GhostSkill();
                    ChangeState(State.Idle, 5f);
                }
                else if (rand <= 4)
                {
                    targetPos = GenerateRandomPoint(player.transform.position, radius + 20f);
                    ChangeState(State.Move);
                }
                else
                {
                    targetPos = GenerateRandomPoint(transform.position, radius);
                    ChangeState(State.Move);
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
            agent.SetDestination(targetPos);

            if (IsNearDestination(agent))
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
        radius = 80f;
        findRadius = 100f;
        agent.speed = 20f;
    }

    public void GhostSkill()
    {
        int rand = RandomInt(0, ghostSkill.Count);
        Instantiate(ghostSkill[rand], transform);
    }
}
