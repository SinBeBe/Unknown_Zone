using UnityEngine;
using UnityEngine.InputSystem;

public class Ending : ManagerBase
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Time.timeScale = 0;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            ui.ImageOnOff(ui.askImage, true);

            //버튼 로직

            ui.ImageOnOff(ui.askImage, false);
        }
        
    }
}
