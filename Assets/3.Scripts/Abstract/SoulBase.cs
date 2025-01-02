
using UnityEngine;

public class SoulBase : ManagerBase
{
    [SerializeField]
    private GameObject player;

    private LayerMask mask;
    protected float radius = 6f;

    private void Start()
    {
        FindManager();
        mask = (1 << 3);
    }

    private void Update()
    {
        CheckPlayer();
    }

    private void CheckPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, mask);

        if (colliders.Length > 0)
        {
            ai.PlayAudiocilp(ai.SFX, ai.soulClip, false);
            Destroy(this.gameObject);
            ui.SoulIncrease();
            return;
        }
    }
}
