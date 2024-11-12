using System.Collections;
using UnityEngine;

public class Syringe : ItemBase
{
    public override IEnumerator ItemUsed()
    {
        //gi.Player.playerData.WalkSpeed =
        yield return new WaitForSeconds(15f);
        gi.isUsedItem = false;
    }
}
