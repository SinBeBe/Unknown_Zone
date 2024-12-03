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
    [SerializeField]
    private Transform centerPos;

    protected GameObject player;
    protected NavMeshAgent agent;

    protected float currentTime;

    protected float radius;
    protected float findRadius;

    protected float speed;

    protected int rand;

    protected void Start()
    {
        Init();
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

        player = GameObject.Find("Player");
        playerLayer = (1 << 3);

        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    public void FindTerrain()
    {
        terrain = GameObject.Find("Ground").GetComponent<Terrain>();
    }

    public Vector3 GenerateRandomPoint(Vector3 pos, float range, float maxHeight)
    {
        for(int i = 0; i < 100; i++)
        {
            float randomX = Random.Range(pos.x - range, pos.x + range);
            float randomZ = Random.Range(pos.z - range, pos.z + range);
            float y = terrain.SampleHeight(new Vector3(randomX, 0, randomZ));

            if (y < maxHeight)
            {
                return new Vector3(randomX, y, randomZ);
            }
        }
        
        return new Vector3(0, 0, 0);
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
        return agent.remainingDistance <= 1.5f;
    }

    public int RandomInt(int min, int max)
    {
        return Random.Range(min, max);
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
