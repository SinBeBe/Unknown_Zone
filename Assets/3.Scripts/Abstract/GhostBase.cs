using UnityEngine;
using UnityEngine.AI;

public enum State 
{ 
    Idle,
    Move,
}

public abstract class GhostBase : ManagerBase, IFindTerrain
{
    private State currentState;

    private Terrain terrain;

    protected float radius;

    protected NavMeshAgent agent;

    protected void Start()
    {
        Init();
        agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void Update()
    {
        switch (currentState) 
        { 
            case State.Idle:
                Idle();
                break;
            case State.Move:
                Move();
                break;
        }
    }

    public abstract void Idle();
    public abstract void Move();

    public virtual void Init()
    {
        FindTerrain();
    }

    public void FindTerrain()
    {
        terrain = transform.Find("Ground").GetComponent<Terrain>();
    }

    public Vector3 GetRandomPointInRange(float radius)
    {
        Vector3 randomPoint = GenerateRandomPoint(radius, radius);
        return randomPoint;
    }

    public Vector3 GenerateRandomPoint(float x, float z)
    {
        float randomX = Random.Range(-x, x);
        float randomZ = Random.Range(-z, z);
        float y = terrain.SampleHeight(new Vector3(randomX, 0, randomZ));

        return new Vector3(randomX, y, randomZ);
    }
}
