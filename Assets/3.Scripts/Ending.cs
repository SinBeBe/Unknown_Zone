using UnityEngine;

public class Ending : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            //플레이어에게 나갈건지 물어보는 로직
            GameManager.instance.GameClear();
        }
    }
}
