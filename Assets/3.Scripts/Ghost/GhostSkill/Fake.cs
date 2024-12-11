
using UnityEngine;

public class Fake : GhostSkillBase
{
    [SerializeField]
    private GameObject fakeGhostPre;

    void Start()
    {
        int rand = Random.Range(1, 6);

        for (int i = 0; i < rand; i++)
        {
            Vector3 pos = GeneratePosition(transform.position, 70f);
            Instantiate(fakeGhostPre, pos, Quaternion.identity);
        }
    }

    private Vector3 GeneratePosition(Vector3 pos, float range)
    {
        float x = Random.Range(pos.x - range, pos.x + range);
        float z = Random.Range(pos.z - range, pos.z + range);

        return new Vector3(x, 5f, z);
    }
}
