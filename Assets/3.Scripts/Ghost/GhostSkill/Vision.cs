using UnityEngine;
using UnityEngine.AI;

public class Vision : GhostSkillBase
{
    void Start()
    {
        Debug.Log("Vision");
        FindPlayerPos();
    }

    private void FindPlayerPos()
    {
        GameObject ghostPre = GameObject.Find("Ghost");
        NavMeshAgent agent = ghostPre.GetComponent<NavMeshAgent>();
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        agent.SetDestination(playerPos);
    }
}
