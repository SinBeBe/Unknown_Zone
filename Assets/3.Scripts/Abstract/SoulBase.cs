
using UnityEngine;

public abstract class SoulBase : ManagerBase
{
    [SerializeField]
    private GameObject player;

    private LayerMask mask;
    protected float radius;

    private void Start()
    {
        Init();
        FindManager();
        mask = (1 << 3);
    }

    private void Update()
    {
        CheckPlayer();
    }

    protected virtual void CheckPlayer()
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

    protected void SetRadius(float radius)
    {
        this.radius = radius;
    }

    protected abstract void Init();
}
