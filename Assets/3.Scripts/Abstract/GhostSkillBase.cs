using UnityEngine;

public class GhostSkillBase : ManagerBase
{
    protected Transform centerPos;

    void Start()
    {
        Init();
    }

    protected void Init()
    {
        FindManager();
        Destroy(this.gameObject, 5f);
    }
}
