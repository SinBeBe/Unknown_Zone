using UnityEditor;
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
    
    private Transform centerPos;

    protected GameObject player;
    protected NavMeshAgent agent;

    protected float currentTime;

    protected float radius;
    protected float nearRadius;
    protected float findRadius;

    protected float speed;

    protected int rand;

    protected void Start()
    {
        Init();
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, nearRadius);
    }

    protected virtual void Update()
    {
        if(IsCheckPlayer(nearRadius))
        {
            if (!ai.ghostSFX.isPlaying)
            {
                ai.PlayAudiocilp(ai.ghostSFX, ai.ghostNearClip, true);
            }
        }
        else
        {
            ai.ghostSFX.clip = null;
        }

        if (!gi.isEnemyLimit)
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
        else
        {
            agent.ResetPath();
        }
    }

    public abstract void Idle();
    public abstract void Move();
    public abstract void Attack();

    public virtual void Init()
    {
        FindTerrain();
        FindManager();
        ChangeState(State.Idle);

        centerPos = this.transform;

        player = GameObject.Find("Player");
        playerLayer = (1 << 3);

        agent = this.GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    public void FindTerrain()
    {
        terrain = GameObject.Find("Ground").GetComponent<Terrain>();
    }

    public Vector3 GenerateRandomPoint(Vector3 pos, float range)
    {
        Vector3 randomPoint;
        float y;
        bool isValid;

        do
        {
            float angle = Random.Range(0, Mathf.PI * 2);
            float distance = Random.Range(0, range);
            float randomX = pos.x + distance * Mathf.Cos(angle);
            float randomZ = pos.z + distance * Mathf.Sin(angle);

            float sampledY = terrain.SampleHeight(new Vector3(randomX, 0, randomZ)) + terrain.transform.position.y;

            y = Mathf.Min(sampledY, 5f);
            randomPoint = new Vector3(randomX, y, randomZ);

            NavMeshHit hit;
            isValid = NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas);

        } while (y > 5f && isValid);

        return randomPoint;
    }


    public float GetRandomTime(float max)
    {
        return Random.Range(1f, max);
    }

    public bool IsCheckPlayer(float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, radius, playerLayer);
        return colliders.Length > 0;
    }

    public bool IsNearDestination(NavMeshAgent agent)
    {
        if (agent == null)
        {
            Debug.LogWarning("NavMeshAgent is null!");
            return false;
        }

        if (!agent.hasPath || agent.pathPending)
        {
            return false;
        }

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
