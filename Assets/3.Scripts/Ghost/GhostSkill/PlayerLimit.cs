using System.Collections;
using UnityEngine;

public class PlayerLimit : GhostSkillBase
{
    void Start()
    {
        Init();
        Debug.Log("PlayerLimit");
        StartCoroutine(Limit(Random.Range(5f, 10f)));
    }

    IEnumerator Limit(float t)
    {
        gi.SwitchGameObject<PlayerController>("Player", false);
        yield return new WaitForSeconds(t);
        gi.SwitchGameObject<PlayerController>("Player", true);
    }
}
