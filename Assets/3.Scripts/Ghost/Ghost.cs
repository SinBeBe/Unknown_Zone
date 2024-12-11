using System.Collections.Generic;
using UnityEngine;

public class Ghost : GhostBase
{
    public List<GameObject> ghostSkill = new List<GameObject>();
    private bool hasTarget = false;

    public override void Idle()
    {
        if (IsCheckPlayer(findRadius))
        {
            agent.ResetPath();
            ChangeState(State.Attack);
            hasTarget = false;
        }
        else
        {
            currentTime -= Time.deltaTime;

            if (currentTime < 0 && !hasTarget)
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
                    hasTarget = true; 
                }
                else
                {
                    targetPos = GenerateRandomPoint(transform.position, radius);
                    ChangeState(State.Move);
                    hasTarget = true;
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
            hasTarget = false;
        }
        else
        {
            agent.SetDestination(targetPos);

            if (IsNearDistination(agent))
            {
                ChangeState(State.Idle, GetRandomTime(5f));
                hasTarget = false;
            }
        }
    }

    public override void Attack()
    {
        if (!IsCheckPlayer(findRadius) || gi.isPlayerHide)
        {
            ChangeState(State.Idle, 5f);
            hasTarget = false;
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
        radius = 50f;
        findRadius = 60f;
        agent.speed = 20f;
    }

    public void GhostSkill()
    {
        int rand = RandomInt(0, ghostSkill.Count);
        Instantiate(ghostSkill[rand], transform);
    }
}
