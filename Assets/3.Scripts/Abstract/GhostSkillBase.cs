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
        ai.PlayAudiocilp(ai.SFX, ai.ghostSkillClip, false);
        Destroy(this.gameObject, 10f);
    }
}
