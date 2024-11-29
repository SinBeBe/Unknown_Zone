
using UnityEngine;

public class Fake : GhostSkillBase
{
    [SerializeField]
    private GameObject fakeGhostPre;

    [SerializeField]
    private Transform centerPos;

    private Transform[] generationPos;


    void Start()
    {
        int rand = Random.Range(1, 6);
        generationPos = new Transform[rand];

        for (int i = 0; i < rand; i++)
        {
            generationPos[i].position = GeneratePosition(transform.position, 80f);
            Instantiate(fakeGhostPre, generationPos[i]);
        }
    }

    private Vector3 GeneratePosition(Vector3 pos, float range)
    {
        float x = Random.Range(pos.x - range, pos.x + range);
        float z = Random.Range(pos.z - range, pos.z + range);

        return new Vector3(x, 5f, z);
    }
}
