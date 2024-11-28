using UnityEngine;

public class GhostSkillBase : ManagerBase
{
    void Start()
    {
        FindManager();
        Destroy(this.gameObject, 10f);
    }
}
