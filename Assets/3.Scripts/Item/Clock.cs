using System.Collections;
using UnityEngine;

public class Clock : ItemBase
{
    public override IEnumerator ItemUsed()
    {
        Destroy(this.gameObject, 15f);
        gi.isEnemyLimit = true;
        yield return new WaitForSeconds(10f);
        gi.isEnemyLimit = false;
    }
}
