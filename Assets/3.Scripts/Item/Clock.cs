using System.Collections;
using UnityEngine;

public class Clock : ItemBase
{
    public override IEnumerator ItemUsed()
    {
        gi.isEnemyLimit = true;
        yield return new WaitForSeconds(10f);
        gi.isEnemyLimit = false;
        gi.isUsedItem = false;
        Destroy(this.gameObject);
    }
}
