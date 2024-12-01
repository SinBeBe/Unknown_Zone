using System.Collections;
using UnityEngine;

public class PlayerLimit : GhostSkillBase
{
    void Start()
    {
        StartCoroutine(Limit(Random.Range(0.5f, 10f)));
    }

    IEnumerator Limit(float t)
    {
        gi.SwitchGameObject("Player", false);
        yield return new WaitForSeconds(t);
        gi.SwitchGameObject("Player", true);
    }
}
