
using UnityEngine;

public class Fake : GhostSkillBase
{
    [SerializeField]
    private GameObject fakeGhostPre;

    [SerializeField]
    private Transform centerPos;

    private Vector3[] generationPos;


    void Start()
    {
        int rand = Random.Range(1, 6);
        generationPos = new Vector3[rand];

        for (int i = 0; i < rand; i++)
        {
            generationPos[i] = GeneratePosition();
        }
    }

    private Vector3 GeneratePosition()
    {
        return centerPos.position;
    }
}
