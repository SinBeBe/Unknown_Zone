using UnityEngine;

public class Soul : MonoBehaviour
{
    private LayerMask mask;
    private float radius = 4f;

    private void Start()
    {
        mask = 3;
    }

    private void LateUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, mask);

        if (colliders.Length > 0)
        {
            //영혼 사라지는 소리
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnDestroy()
    {
        UIManager.instance.SoulIncrease();
    }
}
