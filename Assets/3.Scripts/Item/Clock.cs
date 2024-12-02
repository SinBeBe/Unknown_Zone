using System.Collections;
using UnityEngine;

public class Clock : ItemBase
{
    public override IEnumerator ItemUsed()
    {
        gi.SwitchGameObject<GhostBase>("Enemy", false);
        yield return new WaitForSeconds(10f);
        gi.SwitchGameObject<GhostBase>("Enemy", true);
    }
}
