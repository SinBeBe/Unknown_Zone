using UnityEngine;
using UnityEngine.InputSystem;

public class Ending : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Time.timeScale = 0;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (UIManager.instance.IsAskExit())
            {
                GameManager.instance.GameClear();
            }
            else
            {
                Time.timeScale = 1;
                return;
            }
        }
        
    }
}
