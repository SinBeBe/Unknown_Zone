using UnityEngine;

public class Soul : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private LayerMask mask;
    private float radius = 6f;

    private void Start()
    {
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
            //영혼 사라지는 소리
            Destroy(this.gameObject);
            UIManager.instance.SoulIncrease();
            return;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
