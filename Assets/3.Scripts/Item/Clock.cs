using System.Collections;
using UnityEngine;

public class Clock : ItemBase
{
    public override IEnumerator ItemUsed()
    {
        gi.SwitchGhost(false);
        yield return new WaitForSecondsRealtime(10f);
        gi.SwitchGhost(true);
    }
}
