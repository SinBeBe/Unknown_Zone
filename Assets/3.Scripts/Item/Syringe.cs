using System.Collections;
using UnityEngine;

public class Syringe : ItemBase
{
    public override IEnumerator ItemUsed()
    {
        PlayerData data = gi.Player.playerData;
        data.Speed *= 2;
        data.DamagePercent /= 2;
        yield return new WaitForSeconds(15f);
        data.Speed /= 2;
        data.DamagePercent *= 2;
        gi.isUsedItem = false;
    }
}
