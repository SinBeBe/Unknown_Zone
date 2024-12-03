using UnityEngine;
using UnityEngine.AI;

public class Vision : GhostSkillBase
{
    [SerializeField]
    GameObject ghostPre;

    void Start()
    {
        FindPlayerPos();
    }

    private void FindPlayerPos()
    {
        NavMeshAgent agent = ghostPre.GetComponent<NavMeshAgent>();
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        agent.SetDestination(playerPos);
    }
}
