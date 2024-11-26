using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public enum State 
{ 
    Idle,
    Move,
    Attack
}

public abstract class GhostBase : ManagerBase, IFindTerrain
{
    private State currentState;

    private LayerMask playerLayer;
    protected Vector3 targetPos;

    [SerializeField]
    private Terrain terrain;
    protected NavMeshAgent agent;

    protected float currentTime;

    protected float radius;
    protected float findRadius;


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
            case State.Attack: 
                Attack(); 
                break;
        }
    }

    public abstract void Idle();
    public abstract void Move();
    public abstract void Attack();

    public virtual void Init()
    {
        FindTerrain();
        ChangeState(State.Idle);

        playerLayer = (1 << 3);
    }

    public void FindTerrain()
    {
        terrain = GameObject.Find("Ground").GetComponent<Terrain>();
    }

    public Vector3 GetRandomPointInRange(float radius)
    {
        Vector3 randomPoint = GenerateRandomPoint(radius, radius);
        return randomPoint;
    }

    public Vector3 GenerateRandomPoint(float x, float z)
    {
        while (true)
        {
            float randomX = Random.Range(-x, x);
            float randomZ = Random.Range(-z, z);
            float y = terrain.SampleHeight(new Vector3(randomX, 0, randomZ));

            if (y <= 10f)
            {
                return new Vector3(randomX, y, randomZ);
            }
        }
    }

    public float GetRandomTime(float max)
    {
        return Random.Range(1f, max);
    }

    public bool IsCheckPlayer(float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, playerLayer);
        return colliders.Length > 0 ? true : false;
    }

    public bool IsNearDistination(NavMeshAgent agent)
    {
        return agent.remainingDistance <= 1.5f ? true : false;
    }

    public void ChangeState(State state, float time)
    {
        currentState = state;
        currentTime = time;
    }

    public void ChangeState(State state)
    {
        currentState = state;
    }
}
