using UnityEngine;

public class Soul : SoulBase
{
    protected override void Init()
    {
        SetRadius(6f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
