using UnityEngine;

public class Ending : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            //�÷��̾�� �������� ����� ����
            GameManager.instance.GameClear();
        }
    }
}
