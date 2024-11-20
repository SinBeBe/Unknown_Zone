using System.Collections;
using UnityEngine;

public class Syringe : ItemBase
{
    public override IEnumerator ItemUsed()
    {
        gi.playerSpeed *= 2;
        gi.damagePercent /= 2;
        yield return new WaitForSeconds(15f);
        gi.playerSpeed /= 2;
        gi.damagePercent *= 2;
    }
}
