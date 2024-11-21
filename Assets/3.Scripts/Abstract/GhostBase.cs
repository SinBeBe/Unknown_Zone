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

    private void Start()
    {
        FindTerrain();
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

    public void FindTerrain()
    {
        terrain = transform.Find("Ground").GetComponent<Terrain>();
    }
}
