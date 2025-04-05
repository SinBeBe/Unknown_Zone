using System.Collections;
using UnityEngine;

public class Syringe : ItemBase
{
    public override IEnumerator ItemUsed()
    {
        Destroy(this.gameObject, 15f);
        gi.playerSpeed = 14;
        gi.damagePercent = 0.5f;
        yield return new WaitForSeconds(10f);
        Debug.Log("End Item");
        gi.playerSpeed = 7;
        gi.damagePercent = 1;
    }
}
