using UnityEngine;

public class GhostSkillBase : ManagerBase
{
    protected Transform centerPos;

    void Start()
    {
        FindManager();
        centerPos = GameObject.Find("Ghost").transform;
        Destroy(this.gameObject, 10f);
    }
}
