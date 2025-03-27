using System.Collections;
using UnityEngine;

public class Syringe : ItemBase
{
    public override IEnumerator ItemUsed()
    {
        gi.playerSpeed = 14;
        gi.damagePercent = 0.5f;
        yield return new WaitForSeconds(10f);
        gi.playerSpeed = 7;
        gi.damagePercent = 1;
    }
}
