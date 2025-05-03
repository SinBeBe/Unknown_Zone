using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSprit : SoulBase
{
    protected override void Init()
    {
        SetRadius(8f);
    }

    protected override void CheckPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        if(colliders.Length > 0 && gi.isFindKnife)
        {
            ai.PlayAudiocilp(ai.SFX, ai.ghostDeathClip, false);
            Destroy(this.gameObject);
            gi.isKilledGhost = true;
        }
    }
}
