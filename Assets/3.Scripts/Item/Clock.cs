using System.Collections;
using UnityEngine;

public class Clock : ItemBase
{
    public override IEnumerator ItemUsed()
    {
        gi.SwitchGameObject("Enemy", false);
        yield return new WaitForSeconds(10f);
        gi.SwitchGameObject("Enemy", true);
    }
}
