using System.Collections;
using UnityEngine;

public class PlayerLimit : GhostSkillBase
{
    void Start()
    {
        Init();
        Debug.Log("PlayerLimit");
        StartCoroutine(Limit(Random.Range(3f, 5f)));
    }

    IEnumerator Limit(float t)
    {
        gi.isPlayerLimit = true;
        yield return new WaitForSeconds(t);
        gi.isPlayerLimit = false;
    }
}
