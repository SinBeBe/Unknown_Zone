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

            if (hasTarget) return;

            if (currentTime < 0)
            {
                rand = RandomInt(1, 12);
                Debug.Log(rand);
                if (rand > 3)
                {
                    targetPos = GenerateRandomPoint(transform.position, radius, 10f);
                    ChangeState(State.Move, GetRandomTime(7f));
                    hasTarget = true;
                }
                else if (rand < 10)
                {
                    targetPos = GenerateRandomPoint(player.transform.position, 60f, 10f);
                    ChangeState(State.Move);
                    hasTarget = true; 
                }
                else if (rand < 11)
                {
                    Debug.Log("Ghost Skill!");
                    GhostSkill();
                    ChangeState(State.Idle, 5f);
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
            hasTarget = false;
        }
        else
        {
            agent.SetDestination(targetPos);
            currentTime -= Time.deltaTime;

            if (IsNearDistination(agent) && currentTime < 0)
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
        radius = 40f;
        findRadius = 30f;
        agent.speed = 15f;
    }

    public void GhostSkill()
    {
        int rand = RandomInt(0, ghostSkill.Count);
        Instantiate(ghostSkill[rand], transform);
    }
}
