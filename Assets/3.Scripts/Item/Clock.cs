using System.Collections;
using UnityEngine;

public class Clock : ItemBase
{
    public override IEnumerator ItemUsed()
    {
        gi.SwitchGhost("Enemy", false);
        yield return new WaitForSeconds(10f);
        gi.SwitchGhost("Enemy", true);
    }
}
