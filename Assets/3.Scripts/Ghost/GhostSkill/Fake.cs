
using UnityEngine;
using UnityEngine.AI;

public class Fake : GhostSkillBase
{
    [SerializeField]
    private GameObject fakeGhostPre;

    void Start()
    {
        Init();
        Debug.Log("Fake");
        int rand = Random.Range(1, 6);

        for (int i = 0; i < rand; i++)
        {
            Vector3 pos;
            GameObject ghost;
            NavMeshAgent agent;

            do
            {
                pos = GeneratePosition(transform.position, 40f);
                ghost = Instantiate(fakeGhostPre, pos, Quaternion.identity);
                agent = ghost.GetComponent<NavMeshAgent>();

                if (agent.pathStatus == NavMeshPathStatus.PathInvalid)
                {
                    Destroy(ghost);
                }

            } while (agent == null || agent.pathStatus == NavMeshPathStatus.PathInvalid || !agent.hasPath);
        }

    }

    private Vector3 GeneratePosition(Vector3 pos, float range)
    {
        float x = Random.Range(pos.x - range, pos.x + range);
        float z = Random.Range(pos.z - range, pos.z + range);
        float y = pos.y;

        return new Vector3(x, y, z);
    }
}
