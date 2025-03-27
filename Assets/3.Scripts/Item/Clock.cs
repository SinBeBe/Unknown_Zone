using System.Collections;
using UnityEngine;

public class Clock : ItemBase
{
    public override IEnumerator ItemUsed()
    {
        gi.SwitchGameObject<Ghost>("Enemy", false);
        yield return new WaitForSeconds(10f);
        gi.SwitchGameObject<Ghost>("Enemy", true);
    }
}
